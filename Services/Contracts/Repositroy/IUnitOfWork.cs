using Services.Features.Messaging;
using Services.Features.Messaging.SmsTemplate;
using Services.Features.PatientManagement.Service;
using Services.Features.UserAccounts.Service;

namespace Services.Contracts.Repositroy;

public interface IUnitOfWork
{
    IUserRepository User { get; }
    IPatientRepository Patient { get; }
    ISmsTemplateRepository SmsTemplate { get; }
    void Save();
}