﻿using AutoMapper;
using Database;
using Domain.Entities.Appointments;
using Domain.Entities.Settings.Practice;
using Domain.Entities.Settings.Templates;
using Microsoft.EntityFrameworkCore;
using Services.Features.Settings.Dtos;
using Shared.Wrapper;

namespace Services.Features.Settings.Service;

public class SettingService(ApplicationDbContext context, IMapper mapper)
    : ISettingService
{
    #region Sms Templates

    public async Task<List<SmsTemplate>> GetSmsTemplates()
    {
        return await context.SmsTemplates.ToListAsync();
    }

    public async Task<IResult<SmsTemplate>> GetSmsTemplate(Guid id)
    {
        var smsTemplate = context.SmsTemplates.FirstOrDefault(x => x.Id == id);
        if (smsTemplate == null)
            return await Result<SmsTemplate>.FailAsync("template not found.");

        return await Result<SmsTemplate>.SuccessAsync(smsTemplate);
    }

    public async Task<IResult> SaveSmsTemplate(Guid id, SmsTemplate request)
    {
        if (id == Guid.Empty)
        {
            await context.SmsTemplates.AddAsync(request);
        }
        else
        {
            context.SmsTemplates.Update(request);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Sms template saved.");
    }

    public async Task<IResult> DeleteSmsTemplate(Guid id)
    {
        var smsTemplate = context.SmsTemplates.FirstOrDefault(x => x.Id == id);
        if (smsTemplate == null)
            return await Result.FailAsync("template not found.");
        context.SmsTemplates.Remove(smsTemplate);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Sms template deleted.");
    }

    #endregion

    #region Clinics

    public async Task<List<ClinicDto>> GetClinics()
    {
        var data = await context.Clinics.ToListAsync();
        var mappedData = mapper.Map<List<ClinicDto>>(data);
        return mappedData;
    }

    public async Task<IResult<ClinicDto>> GetClinic(int id)
    {
        var clinic = context.Clinics.FirstOrDefault(x => x.Id == id);

        if (clinic == null)
            return await Result<ClinicDto>.FailAsync("clinic not found.");
        var mappedData = mapper.Map<ClinicDto>(clinic);
        return await Result<ClinicDto>.SuccessAsync(mappedData);
    }

    public async Task<IResult> SaveClinic(int id, ClinicDto request)
    {
        if (id == 0)
        {
            var mappedData = mapper.Map<Clinic>(request);

            await context.Clinics.AddAsync(mappedData);
        }
        else
        {
            var clinic = context.Clinics.FirstOrDefault(x => x.Id == id);

            if (clinic == null)
                return await Result<ClinicDto>.FailAsync("clinic not found.");

            var updatedData = mapper.Map(request, clinic);
            context.Clinics.Update(updatedData);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Clinic saved.");
    }

    public async Task<IResult> DeleteClinic(int id)
    {
        var clinic = context.Clinics.FirstOrDefault(x => x.Id == id);
        if (clinic == null)
            return await Result.FailAsync("clinic not found.");

        context.Clinics.Remove(clinic);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Clinic deleted.");
    }

    public async Task<List<ClinicSiteDto>> GetClinicSites()
    {
        var data = await context.ClinicSites.ToListAsync();
        var mappedData = mapper.Map<List<ClinicSiteDto>>(data);
        return mappedData;
    }
    public async Task<List<ClinicSiteDto>> GetSitesByClinic(int clinicId)
    {
        var data = await context.ClinicSites.Where(x => x.ClinicId == clinicId).ToListAsync();
        var mappedData = mapper.Map<List<ClinicSiteDto>>(data);
        return mappedData;
    }
    public async Task<IResult<ClinicSiteDto>> GetClinicSite(int id)
    {
        var clinic = context.ClinicSites.FirstOrDefault(x => x.Id == id);

        if (clinic == null)
            return await Result<ClinicSiteDto>.FailAsync("clinic not found.");
        var mappedData = mapper.Map<ClinicSiteDto>(clinic);
        return await Result<ClinicSiteDto>.SuccessAsync(mappedData);
    }
    public async Task<IResult> SaveClinicSite(int id, ClinicSiteDto request)
    {
        if (id == 0)
        {
            var mappedData = mapper.Map<ClinicSite>(request);
            await context.ClinicSites.AddAsync(mappedData);
        }
        else
        {
            var clinic = context.ClinicSites.FirstOrDefault(x => x.Id == id);

            if (clinic == null)
                return await Result<ClinicSiteDto>.FailAsync("clinic site not found.");

            var updatedData = mapper.Map(request, clinic);
            context.ClinicSites.Update(updatedData);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Clinic site saved.");
    }

    public async Task<IResult> DeleteClinicSite(int id)
    {
        var clinic = context.ClinicSites.FirstOrDefault(x => x.Id == id);
        if (clinic == null)
            return await Result.FailAsync("clinic site not found.");

        context.ClinicSites.Remove(clinic);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Clinic site deleted.");
    }
    #endregion

    #region Email Templates

    public async Task<List<EmailTemplate>> GetEmailTemplates()
    {
        return await context.EmailTemplates.ToListAsync();
    }

    public async Task<IResult<EmailTemplate>> GetEmailTemplate(Guid id)
    {
        var emailTemplate = context.EmailTemplates.FirstOrDefault(x => x.Id == id);
        if (emailTemplate == null)
            return await Result<EmailTemplate>.FailAsync("template not found.");

        return await Result<EmailTemplate>.SuccessAsync(emailTemplate);
    }

    public async Task<IResult> SaveEmailTemplate(Guid id, EmailTemplate request)
    {
        if (id == Guid.Empty)
        {
            await context.EmailTemplates.AddAsync(request);
        }
        else
        {
            context.EmailTemplates.Update(request);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Sms template saved.");
    }

    public async Task<IResult> DeleteEmailTemplate(Guid id)
    {
        var email = context.EmailTemplates.FirstOrDefault(x => x.Id == id);
        if (email == null)
            return await Result.FailAsync("template not found.");
        context.EmailTemplates.Remove(email);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Sms template deleted.");
    }



    #endregion

    #region Appointment Type

    public async Task<List<AppointmentTypeDto>> GetAppointmentTypes()
    {
        var list = await context.AppointmentTypes.ToListAsync();
        var data = mapper.Map<List<AppointmentTypeDto>>(list);
        return data;
    }

    public async Task<IResult<AppointmentTypeDto>> GetAppointmentType(int id)
    {
        var appointmentType = context.AppointmentTypes.FirstOrDefault(x => x.Id == id);

        if (appointmentType == null)
            return await Result<AppointmentTypeDto>.FailAsync("Appointment Type not found.");

        var data = mapper.Map<AppointmentTypeDto>(appointmentType);

        return await Result<AppointmentTypeDto>.SuccessAsync(data);
    }

    public async Task<IResult> SaveAppointmentType(int id, AppointmentTypeDto request)
    {
        if (id == 0)
        {
            var appt = mapper.Map<AppointmentType>(request);
            await context.AppointmentTypes.AddAsync(appt);
        }
        else
        {
            var appt = mapper.Map<AppointmentType>(request);
            context.AppointmentTypes.Update(appt);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Appointment Type saved.");
    }

    public async Task<IResult> DeleteAppointmentType(int id)
    {
        var appointmentType = context.AppointmentTypes.FirstOrDefault(x => x.Id == id);
        if (appointmentType == null)
            return await Result.FailAsync("Appointment Type not found.");
        context.AppointmentTypes.Remove(appointmentType);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Appointment Type deleted.");
    }



    #endregion

    #region Appointment Cancel Reasons

    public async Task<List<AppointmentCancellationReason>> GetAppointmentCancelReasons()
    {
        return await context.AppointmentCancellationReasons.ToListAsync();
    }

    public async Task<IResult<AppointmentCancellationReason>> GetAppointmentCancelReason(int id)
    {
        var appointmentType = context.AppointmentCancellationReasons.FirstOrDefault(x => x.Id == id);

        if (appointmentType == null)
            return await Result<AppointmentCancellationReason>.FailAsync("Appointment reason not found.");

        return await Result<AppointmentCancellationReason>.SuccessAsync(appointmentType);

    }

    public async Task<IResult> SaveAppointmentCancelReason(int id, AppointmentCancellationReason request)
    {
        if (id == 0)
        {
            await context.AppointmentCancellationReasons.AddAsync(request);
        }
        else
        {
            context.AppointmentCancellationReasons.Update(request);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Appointment cancel reason saved.");
    }

    public async Task<IResult> DeleteAppointmentCancelReason(int id)
    {
        var cancellationReason = context.AppointmentCancellationReasons.FirstOrDefault(x => x.Id == id);
        if (cancellationReason == null)
            return await Result.FailAsync("Appointment reason not found..");
        context.AppointmentCancellationReasons.Remove(cancellationReason);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Appointment Cancel Reason deleted.");
    }



    #endregion
}