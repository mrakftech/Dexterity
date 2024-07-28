﻿using Domain.Entities.Appointments;
using Domain.Entities.Messaging;
using Domain.Entities.Settings;
using Domain.Entities.Settings.Templates;
using Services.Features.Settings.Dtos;
using Shared.Wrapper;

namespace Services.Features.Settings.Service;

public interface ISettingService
{
    #region Sms Template

    public Task<List<SmsTemplate>> GetSmsTemplates();
    public Task<IResult<SmsTemplate>> GetSmsTemplate(Guid id);
    public Task<IResult> SaveSmsTemplate(Guid id, SmsTemplate request);
    public Task<IResult> DeleteSmsTemplate(Guid id);

    #endregion

    #region Clinic

    public Task<List<ClinicDto>> GetClinics();
    public Task<IResult<ClinicDto>> GetClinic(int id);
    public Task<IResult> SaveClinic(int id, ClinicDto request);


    public Task<IResult> DeleteClinic(int id);


    #endregion
    
    #region Email Template

    public Task<List<EmailTemplate>> GetEmailTemplates();
    public Task<IResult<EmailTemplate>> GetEmailTemplate(Guid id);
    public Task<IResult> SaveEmailTemplate(Guid id, EmailTemplate request);
    public Task<IResult> DeleteEmailTemplate(Guid id);

    #endregion

    #region Appointment Type

    public Task<List<AppointmentTypeDto>> GetAppointmentTypes();
    public Task<IResult<AppointmentTypeDto>> GetAppointmentType(int id);
    public Task<IResult> SaveAppointmentType(int id, AppointmentTypeDto request);
    public Task<IResult> DeleteAppointmentType(int id);

    #endregion

    #region Appointment Cancel Reason

    public Task<List<AppointmentCancellationReason>> GetAppointmentCancelReasons();
    public Task<IResult<AppointmentCancellationReason>> GetAppointmentCancelReason(int id);
    public Task<IResult> SaveAppointmentCancelReason(int id, AppointmentCancellationReason request);
    public Task<IResult> DeleteAppointmentCancelReason(int id);

    #endregion
}