﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackOffice.Web.ControllersApi
{
    public class PatientApiController : BaseApiController
    {
        [HttpPost]
        [HttpGet]
        public List<BackOffice.Models.Patient.PatientSearchModel> PatientSearch
            (string SearchCriteria, int PageNumber, int RowCount)
        {
            int oTotalCount;
            List<MedicalCalendar.Manager.Models.Patient.PatientModel> SearchPatient =
                MedicalCalendar.Manager.Controller.Patient.PatientSearch
                (BackOffice.Models.General.SessionModel.CurrentUserAutorization.ProfilePublicId,
                SearchCriteria == null ? string.Empty : SearchCriteria,
                PageNumber,
                RowCount,
                out oTotalCount);

            if (SearchPatient != null && SearchPatient.Count > 0)
            {
                List<BackOffice.Models.Patient.PatientSearchModel> oReturn = SearchPatient.
                    Select(x => new BackOffice.Models.Patient.PatientSearchModel()
                    {
                        SearchPatientCount = oTotalCount,
                        PatientPublicId = x.PatientPublicId,
                        Name = x.Name + " " + x.LastName,
                        Identification = x.PatientInfo.
                            Where(y => y.PatientInfoType == MedicalCalendar.Manager.Models.enumPatientInfoType.IdentificationNumber).
                            Select(y => y.Value).
                            DefaultIfEmpty(string.Empty).FirstOrDefault(),
                        Email = x.PatientInfo.
                            Where(y => y.PatientInfoType == MedicalCalendar.Manager.Models.enumPatientInfoType.Email).
                            Select(y => y.Value).
                            DefaultIfEmpty(string.Empty).FirstOrDefault(),
                        Telephone = x.PatientInfo.
                        Where(y => y.PatientInfoType == MedicalCalendar.Manager.Models.enumPatientInfoType.Telephone).
                        Select(y => y.Value).
                        DefaultIfEmpty(string.Empty).FirstOrDefault(),
                    }).ToList();

                return oReturn;
            }
            else
            {
                return new List<Models.Patient.PatientSearchModel>();
            }
        }


        [HttpPost]
        [HttpGet]
        public List<BackOffice.Models.Appointment.AppointmentListModel> AppointmentList
            (string PatientPublicId)
        {
            List<MedicalCalendar.Manager.Models.Appointment.AppointmentModel> ListAppointment =
                MedicalCalendar.Manager.Controller.Appointment.AppointmentList
                (
                    PatientPublicId
                );
            if(ListAppointment != null && ListAppointment.Count > 0)
            {
                List<BackOffice.Models.Appointment.AppointmentListModel> oReturn = ListAppointment.
                    Select(x => new BackOffice.Models.Appointment.AppointmentListModel()
                    {
                        AppointmentPublicId = x.AppointmentPublicId,
                        StartDate = x.StartDate.ToString(),
                        EndDate = x.EndDate.ToString(),
                        CreateDate = x.CreateDate.ToString(),
                        OfficePublicId = x.OfficePublicId,
                        OfficeName = x.OfficeName,
                    }).ToList();

                return oReturn;
            }
            else
            {
                return new List<Models.Appointment.AppointmentListModel>();
            }
        }
    }
}