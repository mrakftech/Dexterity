using AutoMapper;
using Database;
using Services.Contracts.Repositroy;
using Services.Features.Messaging;
using Services.Features.Messaging.SmsTemplate;
using Services.Features.PatientManagement.Service;
using Services.Features.UserAccounts.Service;

namespace Services.Respository;

public class UnitOfWork(
    ApplicationDbContext context,
    IUserRepository user,
    IMapper mapper,
    IPatientRepository patient,
    ISmsTemplateRepository smsTemplate)
    : IUnitOfWork
{
    public ISmsTemplateRepository SmsTemplate
    {
        get
        {
            if (smsTemplate == null)
            {
                smsTemplate = new SmsTemplateRepository(context);
            }

            return smsTemplate;
        }
    }

    public IUserRepository User
    {
        get
        {
            if (user == null)
            {
                user = new UserRepository(context, mapper);
            }

            return user;
        }
    }

    public IPatientRepository Patient
    {
        get
        {
            if (patient == null)
            {
                user = new UserRepository(context, mapper);
            }

            return patient;
        }
    }

    public void Save()
    {
        context.SaveChanges();
    }
}