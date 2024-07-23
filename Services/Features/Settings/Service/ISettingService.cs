using Domain.Entities.Messaging;
using Domain.Entities.Settings;
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
}