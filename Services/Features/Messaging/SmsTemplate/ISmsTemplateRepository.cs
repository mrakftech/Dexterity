using Services.Contracts.Repositroy;
using Shared.Wrapper;

namespace Services.Features.Messaging.SmsTemplate;

public interface ISmsTemplateRepository: IRepositoryBase<Domain.Entities.Messaging.SmsTemplate>
{
    #region Sms Template

    public Task<List<Domain.Entities.Messaging.SmsTemplate>> GetSmsTemplates();
    public Task<IResult<Domain.Entities.Messaging.SmsTemplate>> GetSmsTemplate(Guid id);
    public Task<IResult> SaveSmsTemplate(Guid id, Domain.Entities.Messaging.SmsTemplate request);
    public Task<IResult> DeleteSmsTemplate(Guid id);

    #endregion
}