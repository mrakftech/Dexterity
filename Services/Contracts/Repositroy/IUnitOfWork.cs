using Services.Features.Messaging.Service;
using Services.Features.PatientManagement.Service;
using Services.Features.Settings.SmsTemplates;
using Services.Features.UserAccounts.Service;

namespace Services.Contracts.Repositroy;

public interface IUnitOfWork
{
    IUserService User { get; }
    IPatientService Patient { get; }
    ISettingService SmsTemplate { get; }
    IMessagingService Messaging { get; }
    void Save();
}