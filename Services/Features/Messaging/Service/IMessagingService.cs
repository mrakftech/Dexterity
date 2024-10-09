using Domain.Entities.Messaging;
using Domain.Entities.PatientManagement.Extra;
using Domain.Entities.PatientManagement.Options;
using Domain.Entities.UserAccounts;
using Services.Features.Messaging.Dtos.Sms;
using Services.Features.Messaging.Dtos.UserTasks;
using Shared.Wrapper;

namespace Services.Features.Messaging.Service;

public interface IMessagingService
{
    #region User Task

    public Task<List<UserTask>> GetUserTasksByPatient(Guid patientId);
    public Task<int> GetUserTasksCountByPatient(Guid patientId);
    public Task<List<UserTask>> GetUserTaskList(string view = "All");
    public Task<IResult> SaveTask(Guid id, UserTaskDto dto);
    public Task<IResult> UpdateTaskStatus(Guid id, string status);
    public Task<UserTaskDto> GetTask(Guid id);
    public Task<IResult> DeleteTask(Guid id);

    #endregion

    #region Sms

    public Task<IResult> SendBulkSms(BulkSmsDto request);
    public Task<IResult> SendSms(SendMessageDto request);

    public Task<List<SmsHistory>> GetSmsHistory(Guid patientId);
    public Task<int> GetSmsHistoryCount(Guid patientId);
    public Task<List<SmsHistory>> FilterSmsHistory(Guid patientId, DateTime from, DateTime to);
    public Task<IResult> AddMessageInPatietnHistory(SmsHistory smsHistory);

    #endregion

    #region Instant Messsaging

    public Task<User> GetUserDetailsAsync(Guid userId);
    public Task<IResult> SaveMessageAsync(ChatMessage message);
    public Task<List<ChatMessage>> GetConversationAsync(Guid contactId);


    #endregion
}