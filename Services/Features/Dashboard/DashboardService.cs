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
        return await context.Users.CountAsync(x =>
            x.UserType == UserTypeConstants.Doctor);
    }
    public async Task<int> GetStaffCount()
    {
        return await context.Users.CountAsync(x =>
            x.UserType == UserTypeConstants.Nurse);
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
}