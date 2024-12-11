using Database;
using Microsoft.EntityFrameworkCore;
using Services.State;
using Shared.Constants.Module;

namespace Services.Features.Dashboard;

public class DashboardService(ApplicationDbContext context) : IDashboardService
{
    public async Task<int> GetPatientCount()
    {
        return await context.Patients.CountAsync(x => x.ClinicId == ApplicationState.CurrentUser.ClinicId);
    }

    public async Task<int> GetAppointmentCount()
    {
        return await context.Appointments.CountAsync(x =>
            x.ClinicId == ApplicationState.CurrentUser.ClinicId && x.HcpId == ApplicationState.CurrentUser.UserId);
    }

    public async Task<int> GetWaitingPatientCount()
    {
        return await context.WaitingAppointments.CountAsync(x =>
            x.ClinicId == ApplicationState.CurrentUser.ClinicId &&
            x.Status == AppointmentConstants.WaitingStatus.Arrived);
    }

    public async Task<int> GetTasksCount()
    {
        return await context.UserTasks.CountAsync(x => x.UserId == ApplicationState.CurrentUser.UserId);
    }

    public async Task<int> GetConsultationCount()
    {
        return await context.ConsultationDetails.CountAsync(x => x.HcpId == ApplicationState.CurrentUser.UserId);
    }
}