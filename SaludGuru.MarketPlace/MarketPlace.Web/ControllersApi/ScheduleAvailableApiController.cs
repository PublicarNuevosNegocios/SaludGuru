﻿using MarketPlace.Models.Appointment;
using MedicalCalendar.Manager.Models.Appointment;
using MedicalCalendar.Manager.Models.General;
using SaludGuruProfile.Manager.Models.Office;
using SaludGuruProfile.Manager.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MarketPlace.Web.ControllersApi
{
    public class ScheduleAvailableApiController : BaseApiController
    {
        [HttpPost]
        [HttpGet]
        public List<EventAvailableModel> GetEventAvailableWeek
            (string ProfilePublicId,
            string OfficePublicId,
            string TreatmentId,
            string NextAvailableDate,
            string StartDateTime)
        {
            List<EventAvailableModel> oReturn = new List<EventAvailableModel>();

            //get profile configuration
            ProfileModel CurrentProfile = SaludGuruProfile.Manager.Controller.Profile.MPProfileGetFull(ProfilePublicId);

            //get office
            OfficeModel CurrentOffice = CurrentProfile.RelatedOffice.
                Where(of => of.OfficePublicId == OfficePublicId).
                FirstOrDefault();

            //get treatment
            TreatmentOfficeModel CurrentTreatment = CurrentProfile.RelatedOffice.
                        Select(of => of.RelatedTreatment.
                                Where(tr => tr.CategoryId == Convert.ToInt32(TreatmentId)).
                                FirstOrDefault()).
                        FirstOrDefault();

            if (CurrentTreatment == null)
            {
                int oTreatmentId = CurrentOffice.RelatedTreatment.
                            Select(tr => new
                            {
                                CategoryId = tr.CategoryId,
                                TreatmentDuration = tr.TreatmentOfficeInfo.
                                    Where(troi => troi.OfficeCategoryInfoType == SaludGuruProfile.Manager.Models.enumOfficeCategoryInfoType.DurationTime).
                                    Select(troi => Convert.ToInt32(troi.Value)).
                                    DefaultIfEmpty(30).
                                    FirstOrDefault()
                            }).
                            OrderBy(tr => tr.TreatmentDuration).
                            Select(tr => tr.CategoryId).
                            FirstOrDefault();

                CurrentTreatment = CurrentOffice.RelatedTreatment.Where(tr => tr.CategoryId == oTreatmentId).FirstOrDefault();
            }

            //get dates
            bool oNextAvailableDate = !string.IsNullOrEmpty(NextAvailableDate) && NextAvailableDate.Replace(" ", "").ToLower() == "true" ? true : false;
            DateTime oStartDateTime = string.IsNullOrEmpty(StartDateTime) ? DateTime.Now : DateTime.ParseExact(StartDateTime.Replace(" ", ""), "yyyy-M-dTH:m", System.Globalization.CultureInfo.InvariantCulture);
            DateTime oEndDateTime = DateTime.Now;

            oStartDateTime = oStartDateTime.AddDays(((int)DayOfWeek.Sunday - (int)oStartDateTime.DayOfWeek) + 1).Date;
            oEndDateTime = oStartDateTime.AddDays(6).Date;

            //get minutes interval
            int oMinutesInterval = string.IsNullOrEmpty(TreatmentId) ?
                    CurrentProfile.ProfileInfo.
                        Where(pi => pi.ProfileInfoType == SaludGuruProfile.Manager.Models.enumProfileInfoType.MarketPlaceSlotDuration).
                        Select(pi => Convert.ToInt32(pi.Value)).
                        DefaultIfEmpty(30).
                        FirstOrDefault() :
                    CurrentTreatment.TreatmentOfficeInfo.
                        Where(tr => tr.OfficeCategoryInfoType == SaludGuruProfile.Manager.Models.enumOfficeCategoryInfoType.DurationTime).
                        Select(tr => Convert.ToInt32(tr.Value)).
                        DefaultIfEmpty(30).
                        FirstOrDefault();

            //get min treatment interval
            int oMinIntervalMinutes =
                    CurrentTreatment.TreatmentOfficeInfo.
                        Where(troi => troi.CategoryInfoType == SaludGuruProfile.Manager.Models.enumCategoryInfoType.DurationTime).
                        Select(troi => Convert.ToInt32(troi.Value)).
                        DefaultIfEmpty(30).
                        FirstOrDefault();

            if (oMinutesInterval < oMinIntervalMinutes)
            {
                oMinutesInterval = oMinIntervalMinutes;
            }

            //get start time for each day
            TimeSpan MinTime = CurrentOffice.ScheduleAvailable.
                    Select(sa => sa.StartTime).
                    OrderBy(sa => sa).
                    DefaultIfEmpty(new TimeSpan(8, 0, 0)).
                    FirstOrDefault();

            //get end time for each day
            TimeSpan MaxTime = CurrentOffice.ScheduleAvailable.
                    Select(sa => sa.EndTime).
                    OrderByDescending(sa => sa).
                    DefaultIfEmpty(new TimeSpan(17, 0, 0)).
                    FirstOrDefault();



            //get first week available appointments
            if (oNextAvailableDate)
            {
                //get busy schedule
                List<ScheduleBusyModel> lstBusyTime = MedicalCalendar.Manager.Controller.Appointment.GetScheduleBusy
                    (CurrentProfile.ProfilePublicId,
                    CurrentOffice.OfficePublicId,
                    oStartDateTime,
                    null,
                    CurrentTreatment.CategoryId);

                //get next day without busy schedule
                if (lstBusyTime != null && lstBusyTime.Count > 0)
                {
                    bool oExit = false;
                    List<DayOfWeek> lstAvailableDay = CurrentOffice.ScheduleAvailable.
                            GroupBy(sa => sa.Day).
                            Select(sa => sa.Key).
                            ToList();
                    do
                    {
                        lstAvailableDay.All(ad =>
                        {
                            //get date to eval
                            DateTime DateToEval = oStartDateTime.AddDays((int)ad - 1);
                            //eval if date is busy
                            if (lstBusyTime.Any(bt => bt.EvalDate.Date == DateToEval.Date))
                            {
                                if (lstBusyTime.Any(bt => bt.EvalDate.Date == DateToEval.Date && bt.MaxFreeTime.Minutes >= oMinIntervalMinutes))
                                {
                                    oExit = true;
                                }
                            }
                            else
                            {
                                oExit = true;
                            }
                            return true;
                        });

                        if (!oExit)
                        {
                            //eval next week
                            oStartDateTime = oStartDateTime.AddDays(7);
                            oEndDateTime = oStartDateTime.AddDays(6).Date;
                        }
                    }
                    while (!oExit);
                }
            }

            //get Appointments on interval
            List<AppointmentModel> CurrentAppointment = MedicalCalendar.Manager.Controller.Appointment.MPAppointmentGetByOfficeId
                (CurrentOffice.OfficePublicId,
                oStartDateTime,
                oEndDateTime);

            if (CurrentAppointment == null)
                CurrentAppointment = new List<AppointmentModel>();

            //get event model

            //create header
            oReturn.Add(new EventAvailableModel()
            {
                Monday = new EventAvailableDayModel()
                {
                    IsHeader = true,
                    AvailableDate = oStartDateTime,
                },
                Tuesday = new EventAvailableDayModel()
                {
                    IsHeader = true,
                    AvailableDate = oStartDateTime.AddDays(1),
                },
                Wednesday = new EventAvailableDayModel()
                {
                    IsHeader = true,
                    AvailableDate = oStartDateTime.AddDays(2),
                },
                Thursday = new EventAvailableDayModel()
                {
                    IsHeader = true,
                    AvailableDate = oStartDateTime.AddDays(3),
                },
                Friday = new EventAvailableDayModel()
                {
                    IsHeader = true,
                    AvailableDate = oStartDateTime.AddDays(4),
                },
                Saturday = new EventAvailableDayModel()
                {
                    IsHeader = true,
                    AvailableDate = oStartDateTime.AddDays(5),
                },
            });

            //create slots
            for (TimeSpan TimeIntervalStart = MinTime; TimeIntervalStart <= MaxTime; TimeIntervalStart = TimeIntervalStart.Add(new TimeSpan(0, oMinutesInterval, 0)))
            {
                TimeSpan TimeIntervalEnd = TimeIntervalStart.Add(new TimeSpan(0, oMinutesInterval, 0));

                EventAvailableModel oCurrentEventModel = new EventAvailableModel()
                {
                    Monday = new EventAvailableDayModel(),
                    Tuesday = new EventAvailableDayModel(),
                    Wednesday = new EventAvailableDayModel(),
                    Thursday = new EventAvailableDayModel(),
                    Friday = new EventAvailableDayModel(),
                    Saturday = new EventAvailableDayModel(),
                };

                CurrentOffice.ScheduleAvailable.
                    Where(sa => sa.StartTime <= TimeIntervalStart && sa.EndTime >= TimeIntervalEnd).
                    GroupBy(sa => new { sa.Day }).
                    OrderBy(sa => sa.Key.Day).
                    All(sa =>
                    {
                        bool AddSlot = true;
                        EventAvailableDayModel CurrentAvailableDate = new EventAvailableDayModel()
                        {
                            IsHeader = false,
                            AvailableDate = oStartDateTime.Date.AddDays((int)sa.Key.Day - 1).Add(TimeIntervalStart),
                        };

                        //get appointments on interval
                        List<AppointmentModel> appmt = CurrentAppointment.
                            Where(ap => ap.StartDate.Date == oStartDateTime.Date.AddDays((int)sa.Key.Day - 1).Date &&

                                        ((ap.StartDate.TimeOfDay >= TimeIntervalStart &&
                                        ap.StartDate.TimeOfDay <= TimeIntervalEnd) ||

                                        (ap.EndDate.TimeOfDay >= TimeIntervalStart &&
                                        ap.EndDate.TimeOfDay <= TimeIntervalEnd) ||

                                        (TimeIntervalStart >= ap.StartDate.TimeOfDay &&
                                        TimeIntervalStart <= ap.EndDate.TimeOfDay) ||

                                        (TimeIntervalEnd >= ap.StartDate.TimeOfDay &&
                                        TimeIntervalEnd <= ap.EndDate.TimeOfDay))).
                            ToList();

                        //eval if slot is empty
                        if (string.IsNullOrEmpty(TreatmentId))
                        {
                            if (appmt != null && appmt.Count > 0)
                            {
                                appmt.All(ap =>
                                {
                                    if (ap.StartDate.TimeOfDay <= TimeIntervalStart &&
                                        ap.EndDate.TimeOfDay >= TimeIntervalEnd)
                                    {
                                        AddSlot = false;
                                    }
                                    else if (ap.StartDate.TimeOfDay >= TimeIntervalStart &&
                                            ap.EndDate.TimeOfDay <= TimeIntervalEnd &&
                                            ap.StartDate.TimeOfDay.Subtract(TimeIntervalStart).Minutes < oMinIntervalMinutes &&
                                            TimeIntervalEnd.Subtract(ap.EndDate.TimeOfDay).Minutes < oMinIntervalMinutes)
                                    {
                                        AddSlot = false;
                                    }
                                    else if (ap.StartDate.TimeOfDay > TimeIntervalStart &&
                                            ap.EndDate.TimeOfDay > TimeIntervalEnd &&
                                            ap.StartDate.TimeOfDay.Subtract(TimeIntervalStart).Minutes < oMinIntervalMinutes)
                                    {
                                        AddSlot = false;
                                    }
                                    else if (ap.StartDate.TimeOfDay < TimeIntervalStart &&
                                            ap.EndDate.TimeOfDay < TimeIntervalEnd &&
                                            TimeIntervalEnd.Subtract(ap.EndDate.TimeOfDay).Minutes < oMinIntervalMinutes)
                                    {
                                        AddSlot = false;
                                    }
                                    return true;
                                });
                            }
                        }
                        else
                        {
                            if (appmt != null && appmt.Count > 0)
                            {
                                //full for appointment exists between slot duration for specific treatment
                                AddSlot = false;
                            }
                        }

                        if (AddSlot)
                        {
                            switch (sa.Key.Day)
                            {
                                case DayOfWeek.Monday:
                                    oCurrentEventModel.Monday = CurrentAvailableDate;
                                    break;
                                case DayOfWeek.Tuesday:
                                    oCurrentEventModel.Tuesday = CurrentAvailableDate;
                                    break;
                                case DayOfWeek.Wednesday:
                                    oCurrentEventModel.Wednesday = CurrentAvailableDate;
                                    break;
                                case DayOfWeek.Thursday:
                                    oCurrentEventModel.Thursday = CurrentAvailableDate;
                                    break;
                                case DayOfWeek.Friday:
                                    oCurrentEventModel.Friday = CurrentAvailableDate;
                                    break;
                                case DayOfWeek.Saturday:
                                    oCurrentEventModel.Saturday = CurrentAvailableDate;
                                    break;
                            }
                        }
                        return true;
                    });

                //add event model
                if (!oCurrentEventModel.SlotIsEmpty)
                {
                    oReturn.Add(oCurrentEventModel);
                }
            }
            return oReturn;

        }
    }
}