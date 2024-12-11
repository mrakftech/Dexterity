namespace Services.Features.Dashboard;

public interface IDashboardService
{
    public Task<int> GetPatientCount();
    public Task<int> GetAppointmentCount();
    public Task<int> GetWaitingPatientCount();
    public Task<int> GetTasksCount();
    public Task<int> GetConsultationCount();
}