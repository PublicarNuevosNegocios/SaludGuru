﻿/*calendar render method*/
var CalendarObject = {

    /*calendar info*/
    DivId: '',
    CountryId: '',
    ProfilePublicId: '',
    StartDate: new Date(),
    EndDate: new Date(),
    FirstDate: new Date(),
    SecondDate: new Date(),

    /*init meeting calendar variables*/
    Init: function (vInitObject) {
        this.DivId = vInitObject.DivId;
        this.CountryId = vInitObject.CountryId;
        this.ProfilePublicId = vInitObject.ProfilePublicId;
        this.StartDate = vInitObject.StartDate;
        this.EndDate = vInitObject.EndDate;
        this.FirstDate = vInitObject.FirstDate;
        this.SecondDate = vInitObject.SecondDate;
    },

    RenderAsync: function () {
        //make ajax for special days
        $.ajax({
            type: "POST",
            url: '/api/Calendar?CountryId=' + this.CountryId + '&ProfilePublicId=' + this.ProfilePublicId + '&StartDate=' + serverDateToString(this.StartDate) + '&EndDate=' + serverDateToString(this.EndDate)
        }).done(function (data) {

            //left date picker
            CalendarObject.RenderCalendar('-Left', data, CalendarObject.FirstDate);
            //right date picker
            CalendarObject.RenderCalendar('-Right', data, CalendarObject.SecondDate);

        }).fail(function () {
            alert("se ha generado un error en el calendario");
        });
    },

    RenderCalendar: function (vDivId, vlstSpecialDay, vCurrentDate) {

        //render calendar
        $('#' + this.DivId + vDivId).datepicker({
            dateFormat: 'yy-mm-dd',
            locale: $.datepicker.regional['es'],
            defaultDate: vCurrentDate,
            beforeShowDay: function (date) {

                var oReturn = [true, ''];

                //eval selected date
                if (date.getFullYear() >= CalendarObject.StartDate.getFullYear() && date.getMonth() >= CalendarObject.StartDate.getMonth() && date.getDate() >= CalendarObject.StartDate.getDate() && date.getFullYear() <= CalendarObject.EndDate.getFullYear() && date.getMonth() <= CalendarObject.EndDate.getMonth() && date.getDate() < CalendarObject.EndDate.getDate()) {
                    oReturn = [true, ' selected'];
                }

                //eval special day
                if (vlstSpecialDay != null) {
                    $(vlstSpecialDay).each(function (index, value) {
                        if (value.Year == date.getFullYear() && value.Month == (date.getMonth() + 1) && value.Day == date.getDate()) {
                            oReturn = [true, 'specialDay_' + value.SpecialDayType];
                        }
                    });
                }
                return oReturn;
            },
            onSelect: function (date) {
                //delete selected style in continuos calendar
                //$('#' + this.DivId + '-Right .ui-state-active').removeClass('ui-state-active ui-state-hover');
                //alert(date + 'jairo');
                //window.location = '/Appointment/Day?Date=' + date;
            },
        });

        //delete selected style on calendar
        $('#' + this.DivId + vDivId + ' .ui-datepicker-current-day').removeClass('ui-datepicker-days-cell-over ui-datepicker-current-day');
        $('#' + this.DivId + vDivId + ' .ui-state-active').removeClass('ui-state-active ui-state-hover');
    },
};

/*render day calendar*/
var MettingCalendarObject = {

    /*meeting info*/
    DivId: '',
    CurrentAgentType: 'agendaDay',
    StartDateTime: new Date(),
    EndDateTime: new Date(),

    /*full calendar info*/
    dayNamesSp: ['Domingo', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado'],
    dayNamesShortSp: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab'],

    /*office info*/
    lstOffice: new Array(),

    /*init meeting variables*/
    Init: function (vInitObject) {

        //init meeting info
        this.DivId = vInitObject.DivId;
        this.CurrentAgentType = vInitObject.CurrentAgentType;
        this.StartDateTime = vInitObject.StartDateTime;
        this.EndDateTime = vInitObject.EndDateTime;

        //init office info object array
        $.each(vInitObject.OfficeInfo, function (index, value) {
            MettingCalendarObject.lstOffice[value.OfficePublicId] = value;
        });
    },

    /*init meeting calendar by day*/
    RenderAsync: function () {

        var TotalCalendars = 0;

        for (var item in this.lstOffice) {
            //create div to put a calendar
            this.lstOffice[item].OfficeDivId = 'divMetting_' + this.lstOffice[item].OfficePublicId;
            $('#' + this.DivId).append($('#divMetting').html().replace(/divOfficePublicId/gi, this.lstOffice[item].OfficeDivId));

            //init calendar
            this.RenderMettingCalendar(this.lstOffice[item].OfficePublicId);

            //add calendars count
            TotalCalendars = TotalCalendars + 1;
        }

        //TODO: Recalc dimension with bootstrap
        $('#' + this.DivId).width(($('#divOfficePublicId').width() * TotalCalendars) + 1);
    },

    RenderMettingCalendar: function (vOfficePublicId) {

        //get title
        var vTitle = $('#divMettingHeader').html();
        vTitle = vTitle.replace(/{{OfficeScheduleConfigUrl}}/gi, this.lstOffice[vOfficePublicId].OfficeScheduleConfigUrl);
        vTitle = vTitle.replace(/{{OfficeName}}/gi, this.lstOffice[vOfficePublicId].OfficeName);

        //init office metting calendar
        $('#' + this.lstOffice[vOfficePublicId].OfficeDivId).fullCalendar({
            dayNames: this.dayNamesSp,
            dayNamesShort: this.dayNamesShortSp,
            defaultView: this.CurrentAgentType,
            allDaySlot: false,
            allDayText: ' ',
            titleFormat: '\'' + vTitle + '\'',
            weekNumbers: false,
            editable: true,
            header: {
                left: '',
                center: 'title',
                right: '',
            },
            columnFormat: {
                month: ' ',
                week: 'ddd M/d',
                day: 'ddd M/d'
            },
            dayClick: function (date, jsEvent, view) {
                UpsertAppointmentObject.RenderForm(date, vOfficePublicId, null);
            },
            eventClick: function (event, jsEvent, view) {
                UpsertAppointmentObject.RenderForm(null, null, event);
            },
            eventRender: function (event, element) {
                //debugger;
                element.find('.fc-event-title').html(element.find('.fc-event-title').text());
            },
            events: {
                url: '/api/AppointmentApi?OfficePublicId=' + vOfficePublicId + '&StartDateTime=' + serverDateTimeToString(this.StartDateTime) + '&EndDateTime=' + serverDateTimeToString(this.EndDateTime),
            },
        });

        $('#' + this.lstOffice[vOfficePublicId].OfficeDivId).fullCalendar('gotoDate', this.StartDateTime);
    },
};

var UpsertAppointmentObject = {

    /*appointment info*/
    DivId: '',

    /*init appointment variables*/
    Init: function (vInitObject) {

        //init meeting info
        this.DivId = vInitObject.DivId;
    },

    /*render appointment form*/
    RenderForm: function (vStartDate, vOfficeInfo, vAppointmentInfo) {

        //hidde create appointment form
        $('#' + this.DivId).hide();

        //get current values

        //set appointment id
        $('#AppointmentPublicId').val('');
        if (vAppointmentInfo != null) {
            $('#AppointmentPublicId').val(vAppointmentInfo.AppointmentPublicId);
        }

        //current appointment status
        var oCurrentAppointmentStatus = '1201';
        if (vAppointmentInfo != null) {
            oCurrentAppointmentStatus = vAppointmentInfo.AppointmentStatus;
        }

        //current office
        var oCurrentOfficePublicId = '';
        if (vOfficeInfo != null) {
            oCurrentOfficePublicId = vOfficeInfo;
        }
        else if (vAppointmentInfo != null) {
            oCurrentOfficePublicId = vAppointmentInfo.OfficePublicId;
        }

        //current treatment
        var oCurrentTreatmentId = 0;

        if (vAppointmentInfo != null) {
            oCurrentTreatmentId = vAppointmentInfo.TreatmentId;
        }

        //current start date and duration
        var oCurrentStartDate = new Date();
        var oCurrentStartTime = '';
        var oCurrentDuration = 0;

        if (vStartDate != null) {

            //get start date
            oCurrentStartDate = vStartDate;

            //get start time
            var vMin = vStartDate.getMinutes();
            if (vMin < 10) {
                vMin = '0' + vStartDate.getMinutes();
            }

            if (vStartDate.getHours() <= 12) {
                oCurrentStartTime = vStartDate.getHours() + ':' + vMin + ' AM';
            }
            else {
                oCurrentStartTime = (vStartDate.getHours() - 12) + ':' + vMin + ' PM';
            }
        }
        else if (vAppointmentInfo != null) {
            oCurrentStartDate = vAppointmentInfo.StartDate;
            oCurrentStartTime = vAppointmentInfo.StartTime;
            oCurrentDuration = vAppointmentInfo.Duration;
        }

        //render office
        this.RenderOffice(oCurrentOfficePublicId, vStartDate, vAppointmentInfo)

        //render treatment duration startdate and starttime
        this.RenderTreatment(oCurrentOfficePublicId, oCurrentDuration, oCurrentTreatmentId, oCurrentStartDate, oCurrentStartTime);

        //render patient appointment
        this.RenderPatient(vAppointmentInfo);

        //add style for specific appointment status
        $('#' + this.DivId).addClass('AppointmentFormStatus_' + oCurrentAppointmentStatus);

        //disable actions for status
        if (oCurrentAppointmentStatus == 1201) {
            //New
            $('#AppointmentUpsertActions .AppointmentActionsAccept').show();

            if (vAppointmentInfo != null) {
                $('#AppointmentUpsertActions .AppointmentActionsCancel').show();
                $('#AppointmentUpsertActions .AppointmentActionsConfirm').show();
                $('#AppointmentUpsertActions .AppointmentActionsNew').show();
            }
            else {
                $('#AppointmentUpsertActions .AppointmentActionsCancel').hide();
                $('#AppointmentUpsertActions .AppointmentActionsConfirm').hide();
                $('#AppointmentUpsertActions .AppointmentActionsNew').hide();
            }
        }
        else if (oCurrentAppointmentStatus == 1202) {
            //Confirmed
            $('#AppointmentUpsertActions .AppointmentActionsCancel').show();
            $('#AppointmentUpsertActions .AppointmentActionsConfirm').hide();
            $('#AppointmentUpsertActions .AppointmentActionsNew').show();
            $('#AppointmentUpsertActions .AppointmentActionsAccept').show();
        }
        else if (oCurrentAppointmentStatus == 1203) {
            //Canceled
            $('#AppointmentUpsertActions .AppointmentActionsCancel').hide();
            $('#AppointmentUpsertActions .AppointmentActionsConfirm').hide();
            $('#AppointmentUpsertActions .AppointmentActionsNew').show();
            $('#AppointmentUpsertActions .AppointmentActionsAccept').hide();
        }
        else if (oCurrentAppointmentStatus == 1204) {
            //PendientAsistance
            $('#AppointmentUpsertActions .AppointmentActionsCancel').hide();
            $('#AppointmentUpsertActions .AppointmentActionsConfirm').show();
            $('#AppointmentUpsertActions .AppointmentActionsNew').show();
            $('#AppointmentUpsertActions .AppointmentActionsAccept').hide();
        }
        else if (oCurrentAppointmentStatus == 1205) {
            //Attendance
            $('#AppointmentUpsertActions .AppointmentActionsCancel').hide();
            $('#AppointmentUpsertActions .AppointmentActionsConfirm').hide();
            $('#AppointmentUpsertActions .AppointmentActionsNew').show();
            $('#AppointmentUpsertActions .AppointmentActionsAccept').hide();
        }
        else if (oCurrentAppointmentStatus == 1206) {
            //NotAttendance
            $('#AppointmentUpsertActions .AppointmentActionsCancel').hide();
            $('#AppointmentUpsertActions .AppointmentActionsConfirm').hide();
            $('#AppointmentUpsertActions .AppointmentActionsNew').show();
            $('#AppointmentUpsertActions .AppointmentActionsAccept').hide();
        }

        //set action events on click
        $('#AppointmentUpsertActions .AppointmentActionsCancel').unbind('click');
        $('#AppointmentUpsertActions .AppointmentActionsCancel').click(function () { UpsertAppointmentObject.CancelAppointment() });

        $('#AppointmentUpsertActions .AppointmentActionsConfirm').unbind('click');
        $('#AppointmentUpsertActions .AppointmentActionsConfirm').click(function () { UpsertAppointmentObject.ConfirmAppointment() });

        $('#AppointmentUpsertActions .AppointmentActionsNew').unbind('click');
        $('#AppointmentUpsertActions .AppointmentActionsNew').click(function () { UpsertAppointmentObject.DuplicateAppointment() });

        $('#AppointmentUpsertActions .AppointmentActionsAccept').unbind('click');
        $('#AppointmentUpsertActions .AppointmentActionsAccept').click(function () { UpsertAppointmentObject.SaveAppointment() });

        //display create appointment form
        $('#' + this.DivId).fadeIn('slow');
    },

    RenderOffice: function (vCurrentOfficePublicId, vStartDate, vAppointmentInfo) {

        //load office
        $('#OfficePublicId').find('option').remove();
        $('#OfficePublicId').unbind('change');

        for (var item in MettingCalendarObject.lstOffice) {
            $('#OfficePublicId').append($('<option/>', {
                value: MettingCalendarObject.lstOffice[item].OfficePublicId,
                text: MettingCalendarObject.lstOffice[item].OfficeName,
                selected: (MettingCalendarObject.lstOffice[item].OfficePublicId == vCurrentOfficePublicId)
            }));
        }

        $('#OfficePublicId').change(function () {
            UpsertAppointmentObject.RenderForm(vStartDate, $(this).val(), vAppointmentInfo);
        });
    },

    RenderTreatment: function (vCurrentOfficePublicId, vCurrentDuration, vCurrentTreatmentId, vCurrentStartDate, vCurrentStartTime) {

        //init duration spinner
        $('#Duration').spinner({
            min: 10,
            step: 5,
        });

        if (vCurrentDuration != null && vCurrentDuration > 0) {
            $('#Duration').val(vCurrentDuration);
        }

        //load treatment
        $('#TreatmentId').find('option').remove();
        $('#TreatmentId').unbind('change');
        $.each(MettingCalendarObject.lstOffice[vCurrentOfficePublicId].TreatmentList, function (index, value) {

            $('#TreatmentId').append($('<option/>', {
                value: value.TreatmentId,
                text: value.TreatmentName,
                selected: ((vCurrentTreatmentId > 0 && vCurrentTreatmentId == value.TreatmentId) || value.IsDefault),
                officepublicid: vCurrentOfficePublicId,
            }));

            //set input dependencies
            if ((vCurrentTreatmentId > 0 && vCurrentTreatmentId == value.TreatmentId) || value.IsDefault) {
                if (vCurrentDuration != null && vCurrentDuration > 0) { }
                else {
                    //set duration
                    $('#Duration').val(value.Duration);
                }
            }
        });

        $('#TreatmentId').change(function () {
            //get treatment id
            var ovTreatmentId = $(this).val();
            var ovOfficePublicId = $(this).find(':selected').attr('officepublicid');

            //set input dependencies
            $.each(MeetingObject.lstOffice[ovOfficePublicId].TreatmentList, function (index, value) {
                if (value.TreatmentId == ovTreatmentId) {
                    //set duration
                    $('#Duration').val(value.Duration);
                }
            });
        });

        //load start date
        $('#StartDate').datepicker({
            altFormat: "yy-mm-dd"
        });

        $('#StartDate').datepicker("setDate", vCurrentStartDate);

        //load start time
        $('#StartTime').ptTimeSelect({
            hoursLabel: 'Hora',
            minutesLabel: 'Minutos',
            setButtonLabel: 'Aceptar',
        });

        $('#StartTime').val(vCurrentStartTime);

    },

    RenderPatient: function (vAppointmentInfo) {

        //init patient hidden values
        $('#lstPatient').html('');
        $('#PatientAppointmentCreate').val('');
        $('#PatientAppointmentDelete').val('');

        if (vAppointmentInfo != null) {

            //render actual related patient
            $.each(vAppointmentInfo.CurrentPatientInfo, function (index, value) {

                UpsertAppointmentObject.AddPatientAppointment({
                    ProfileImage: value.ProfileImage,
                    Name: value.Name,
                    IdentificationNumber: value.IdentificationNumber,
                    Mobile: value.Mobile,
                    Email: value.Email,
                    PatientPublicId: value.PatientPublicId
                });

            });
        }

        //load patient autocomplete
        $('#getPatient').autocomplete(
        {
            source: function (request, response) {
                $.ajax({
                    url: '/api/PatientApi?SearchCriteria=' + request.term + '&PageNumber=0&RowCount=10',
                    dataType: 'json',
                    success: function (data) {
                        response(data);
                    }
                });
            },
            minLength: 0,
            focus: function (event, ui) {
                $('#getPatient').val(ui.item.Name);
                return false;
            },
            select: function (event, ui) {
                UpsertAppointmentObject.AddPatientAppointment({
                    ProfileImage: ui.item.ProfileImage,
                    Name: ui.item.Name,
                    IdentificationNumber: ui.item.IdentificationNumber,
                    Mobile: ui.item.Mobile,
                    Email: ui.item.Email,
                    PatientPublicId: ui.item.PatientPublicId
                });

                $('#getPatient').val('');
                return false;
            }
        }).data("ui-autocomplete")._renderItem = function (ul, item) {

            var RenderItem = $('#divPatientAcItem').html();
            RenderItem = RenderItem.replace(/{ProfileImage}/gi, item.ProfileImage);
            RenderItem = RenderItem.replace(/{Name}/gi, item.Name);
            RenderItem = RenderItem.replace(/{IdentificationNumber}/gi, item.IdentificationNumber);
            RenderItem = RenderItem.replace(/{Mobile}/gi, item.Mobile);

            return $("<li></li>")
                .data("ui-autocomplete-item", item)
                .append("<a><strong>" + RenderItem + "</strong></a>")
                .appendTo(ul);
        };
    },

    AddPatientAppointment: function (vPatientModel) {
        if ($('#PatientAppointmentCreate').val().indexOf(vPatientModel.PatientPublicId) == -1) {
            var ApPatHtml = $('#ulPatientAppointment').html();
            ApPatHtml = ApPatHtml.replace(/{ProfileImage}/gi, vPatientModel.ProfileImage);
            ApPatHtml = ApPatHtml.replace(/{Name}/gi, vPatientModel.Name);
            ApPatHtml = ApPatHtml.replace(/{IdentificationNumber}/gi, vPatientModel.IdentificationNumber);
            ApPatHtml = ApPatHtml.replace(/{Mobile}/gi, vPatientModel.Mobile);
            ApPatHtml = ApPatHtml.replace(/{Email}/gi, vPatientModel.Email);
            ApPatHtml = ApPatHtml.replace(/{PatientPublicId}/gi, vPatientModel.PatientPublicId);
            $('#lstPatient').append(ApPatHtml);
            $('#PatientAppointmentCreate').val($('#PatientAppointmentCreate').val() + ',' + vPatientModel.PatientPublicId);
            $('#PatientAppointmentDelete').val($('#PatientAppointmentDelete').val().replace(new RegExp(vPatientModel.PatientPublicId, 'gi'), ''));
        }
    },

    RemovePatientAppointment: function (vPatientPublicId) {
        $('#lstPatient').find('#' + vPatientPublicId).remove();
        $('#PatientAppointmentDelete').val($('#PatientAppointmentDelete').val() + ',' + vPatientPublicId);
        $('#PatientAppointmentCreate').val($('#PatientAppointmentCreate').val().replace(new RegExp(vPatientPublicId, 'gi'), ''));
    },

    SaveAppointment: function () {
        alert('SaveAppointment');
        //$("#frmAppointment").submit(function (e) {
        //    var postData = $(this).serializeArray();
        //    var formURL = $(this).attr("action");
        //    $.ajax(
        //    {
        //        url: formURL,
        //        type: "POST",
        //        data: postData,
        //        success: function (data, textStatus, jqXHR) {
        //            window.location.reload();
        //        },
        //        error: function (jqXHR, textStatus, errorThrown) {
        //            alert('Se ha generado un error creando la cita.');
        //        }
        //    });
        //    e.preventDefault(); //STOP default action
        //    e.unbind(); //unbind. to stop multiple form submit.
        //});

        //$("#frmAppointment").submit();
    },

    CancelAppointment: function () {
        alert('CancelAppointment');
    },

    DuplicateAppointment: function () {
        alert('DuplicateAppointment');
    },

    ConfirmAppointment: function () {
        alert('ConfirmAppointment');
    },
};

var MeetingListObject = {
    /*meeting info*/
    StartDateTime: new Date(),
    EndDateTime: new Date(),

    /*office info*/
    lstOffice: new Array(),

    /*init meeting variables*/
    Init: function (vInitObject) {

        //init meeting info
        this.StartDateTime = vInitObject.StartDateTime;
        this.EndDateTime = vInitObject.EndDateTime;

        //init office info object array
        $.each(vInitObject.OfficeInfo, function (index, value) {
            MeetingListObject.lstOffice[value.OfficePublicId] = value;
        });
    },

    /*init list office appointments*/
    InitList: function (DivId) {
        for (var item in this.lstOffice) {
            //create div to put a calendar
            this.lstOffice[item].OfficeDivId = 'divList_' + this.lstOffice[item].OfficePublicId;
            $('#' + DivId).append($('#divListGrid').html().replace(/divOfficePublicId/gi, this.lstOffice[item].OfficeDivId));

            //init list appointment
            this.InitListAppointmentByOffice(this.lstOffice[item].OfficePublicId);
        }
    },

    InitListAppointmentByOffice: function (vOfficePublicId) {

        $('#' + MeetingListObject.lstOffice[vOfficePublicId].OfficeDivId).kendoGrid({
            datasource: {
                type: "json",
                data: MeetingListObject.lstOffice[vOfficePublicId],
            },

        });

        //load treatment
        $.each(this.lstOffice[vOfficePublicId].TreatmentList, function (index, value) {
            var value = value.TreatmentId;
            var text = value.TreatmentName;
            var selected = value.Default;
            var officepublicid = vOfficePublicId;
        });


        $('#' + MeetingListObject.lstOffice[vOfficePublicId].OfficeDivId).html("<p>" + MeetingListObject.lstOffice[vOfficePublicId].OfficeName + "</p>");
        //configure grid
        $('#' + MeetingListObject.lstOffice[vOfficePublicId].OfficeDivId).kendoGrid({
            dataSource: {
                transport: {
                    read: function (options) {
                        $.ajax({
                            url: '/api/AppointmentApi?OfficePublicId=' + vOfficePublicId + '&StartDateTime=' + serverDateTimeToString(MeetingListObject.StartDateTime) + '&EndDateTime=' + serverDateTimeToString(MeetingListObject.EndDateTime),
                            dataType: "json",
                            type: "POST",
                            success: function (result) {
                                options.success(result);
                            },
                            error: function (result) {
                                options.error(result);
                            }
                        });
                    }
                },
            },
            columns: [{
                field: "title",
                title: "Citas",
                template: $('#AppointmentTemplate').html()
            }],
        });
    },
};
