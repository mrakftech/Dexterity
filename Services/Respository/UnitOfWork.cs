using AutoMapper;
using Database;
using Services.Contracts.Repositroy;
using Services.Features.Messaging.Service;
using Services.Features.PatientManagement.Service;
using Services.Features.Settings.SmsTemplates;
using Services.Features.UserAccounts.Service;

namespace Services.Respository;

public class UnitOfWork(
    ApplicationDbContext context,
    IUserService user,
    IMapper mapper,
    IPatientService patient,
    IMessagingService messaging,
    ISettingService setting)
    : IUnitOfWork
{
    public IMessagingService Messaging
    {
        get
        {
            if (messaging == null)
            {
                messaging = new MessagingService(context, mapper);
            }

            return messaging;
        }
    }

    public ISettingService SmsTemplate
    {
        get
        {
            if (setting == null)
            {
                setting = new SettingService(context);
            }

            return setting;
        }
    }

    public IUserService User
    {
        get
        {
            if (user == null)
            {
                user = new UserService(context, mapper);
            }

            return user;
        }
    }

    public IPatientService Patient
    {
        get
        {
            if (patient == null)
            {
                user = new UserService(context, mapper);
            }

            return patient;
        }
    }

    public void Save()
    {
        context.SaveChanges();
    }
}