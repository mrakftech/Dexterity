using Domain.Entities.Messaging;
using Services.Contracts.Repositroy;
using Shared.Wrapper;

namespace Services.Features.Settings.SmsTemplates;

public interface ISettingService
{
    #region Sms Template

    public Task<List<SmsTemplate>> GetSmsTemplates();
    public Task<IResult<SmsTemplate>> GetSmsTemplate(Guid id);
    public Task<IResult> SaveSmsTemplate(Guid id, SmsTemplate request);
    public Task<IResult> DeleteSmsTemplate(Guid id);

    #endregion
}