using Database;
using Microsoft.EntityFrameworkCore;
using Services.State;
using Shared.Constants.Module;
using Shared.Constants.Role;

namespace Services.Features.Dashboard;

public class DashboardService(ApplicationDbContext context) : IDashboardService
{
    public async Task<int> GetPatientCount(int[] clinicIds)
    {
        if (clinicIds == null || clinicIds.Length == 0) return 0;
        var count = 0;
        foreach (var id in clinicIds)
        {
            var patientCount = await context.Patients.CountAsync(x => x.ClinicId == id);
            count += patientCount;
        }

        return count;
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

    public async Task<int> GetAppointmentCount(int[] clinicIds)
    {
        if (clinicIds == null || clinicIds.Length == 0) return 0;

        var count = 0;
        foreach (var id in clinicIds)
        {
            var apptCount = await context.Appointments.CountAsync(x =>
                x.ClinicId == id && x.HcpId == ApplicationState.Auth.CurrentUser.UserId);
            count += apptCount;
        }

        return count;
    }

    public async Task<int> GetWaitingPatientCount(int[] clinicIds)
    {
        if (clinicIds == null || clinicIds.Length == 0) return 0;

        var count = 0;
        foreach (var id in clinicIds)
        {
            var apptCount = await context.WaitingAppointments.CountAsync(x =>
                x.ClinicId == id &&
                x.Status == AppointmentConstants.WaitingStatus.Expected ||
                x.Status == AppointmentConstants.WaitingStatus.Arrived);
            count += apptCount;
        }

        return count;
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