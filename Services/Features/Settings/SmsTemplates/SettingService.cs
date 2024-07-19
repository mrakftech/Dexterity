using Database;
using Microsoft.EntityFrameworkCore;
using Services.Respository;
using Shared.Wrapper;

namespace Services.Features.Settings.SmsTemplates;

public class SettingService(ApplicationDbContext context) 
    :  ISettingService
{
    public async Task<List<Domain.Entities.Messaging.SmsTemplate>> GetSmsTemplates()
    {
        return await context.SmsTemplates.ToListAsync();
    }

    public async Task<IResult<Domain.Entities.Messaging.SmsTemplate>> GetSmsTemplate(Guid id)
    {
        var smsTemplate = context.SmsTemplates.FirstOrDefault(x => x.Id == id);
        if (smsTemplate == null)
            return await Result<Domain.Entities.Messaging.SmsTemplate>.FailAsync("template not found.");

        return await Result<Domain.Entities.Messaging.SmsTemplate>.SuccessAsync(smsTemplate);
    }

    public async Task<IResult> SaveSmsTemplate(Guid id, Domain.Entities.Messaging.SmsTemplate request)
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
}