using Database;
using Microsoft.EntityFrameworkCore;
using Services.State;
using Shared.Constants.Module;
using Shared.Constants.Role;

namespace Services.Features.Dashboard;

public class DashboardService(ApplicationDbContext context) : IDashboardService
{
    public async Task<int> GetPatientCount(int clinicId)
    {
        return await context.Patients.CountAsync(x => x.ClinicId == clinicId);
    }

    public async Task<int> GetDoctorsCount()
    {
        var userTypeId = await GetUserType(UserTypeConstants.Doctor);
        return await context.Users.CountAsync(x =>
            x.UserTypeId == userTypeId);
    }
    public async Task<int> GetStaffCount()
    {
        var userTypeId = await GetUserType(UserTypeConstants.Nurse);

        return await context.Users.CountAsync(x =>
            x.UserTypeId == userTypeId);
    }
    public async Task<int> GetAppointmentCount(int clinicId)
    {
        return await context.Appointments.CountAsync(x =>
            x.ClinicId == clinicId && x.HcpId == ApplicationState.Auth.CurrentUser.UserId);
    }

    public async Task<int> GetWaitingPatientCount(int clinicId)
    {
        return await context.WaitingAppointments.CountAsync(x =>
            x.ClinicId == ApplicationState.Auth.CurrentUser.ClinicId &&
            x.Status == AppointmentConstants.WaitingStatus.Arrived);
    }

    public async Task<int> GetTasksCount()
    {
        return await context.UserTasks.CountAsync(x => x.UserId == ApplicationState.Auth.CurrentUser.UserId);
    }

    public async Task<int> GetConsultationCount()
    {
        return await context.ConsultationDetails.CountAsync(x => x.HcpId == ApplicationState.Auth.CurrentUser.UserId);
    }
    
    private async Task<Guid> GetUserType(string userType)
    {
        var userTypeInDb = await context.UserTypes.FirstOrDefaultAsync(x => x.Name == userType);
        return userTypeInDb?.Id ?? Guid.Empty;
    }
}