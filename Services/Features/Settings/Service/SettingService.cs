using AutoMapper;
using Database;
using Domain.Entities.Messaging;
using Domain.Entities.Settings;
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

    #endregion
}