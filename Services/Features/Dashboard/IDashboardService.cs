namespace Services.Features.Dashboard;

public interface IDashboardService
{
    public Task<int> GetPatientCount(int clinicId);
    public Task<int> GetDoctorsCount();
    public Task<int> GetStaffCount();
    public Task<int> GetAppointmentCount(int clinicId);
    public Task<int> GetWaitingPatientCount(int clinicId);
    public Task<int> GetTasksCount();
    public Task<int> GetConsultationCount();
}