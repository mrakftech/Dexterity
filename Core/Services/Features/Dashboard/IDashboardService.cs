namespace Services.Features.Dashboard;

public interface IDashboardService
{
    public Task<int> GetPatientCount(int[] clinicIds);
    public Task<int> GetAppointmentCount(int[] clinicIds);
    public Task<int> GetWaitingPatientCount(int[] clinicIds);
    public Task<int> GetDoctorsCount();
    public Task<int> GetStaffCount();
  
    public Task<int> GetTasksCount();
    public Task<int> GetConsultationCount();
}