using AutoMapper;
using Database;
using Domain.Entities.WaitingRoom;
using Microsoft.EntityFrameworkCore;
using Services.Features.Appointments.Service;
using Services.Features.Consultation.Service;
using Services.Features.WaitingRoom.Dtos;
using Services.State;
using Shared.Constants.Module;
using Shared.Wrapper;

namespace Services.Features.WaitingRoom.Service;

public class WaitingRoomService(
    ApplicationDbContext context,
    IMapper mapper,
    IConsultationService consultationService,
    IAppointmentService appointmentService)
    : IWaitingRoomService
{
    public async Task<List<WaitingPatientDto>> GetWaitingRoomPatients(string status)
    {
        if (status == AppointmentConstants.WaitingStatus.Expected)
        {
            //Adding expected patient from appointment table to waiting room table
            await AddExpectedPatients();
        }

        var appointments = await context.WaitingAppointments
            .Include(x => x.Appointment)
            .Include(x => x.Appointment.AppointmentType)
            .Include(x => x.Appointment.Hcp)
            .Include(x => x.Patient)
            .Include(x => x.Patient.PatientAccount)
            .Where(x => x.Appointment.StartTime.Date == DateTime.Now.Date && x.Status == status &&
                        x.ClinicId == ApplicationState.Auth.CurrentUser.ClinicId)
            .ToListAsync();

        var data = mapper.Map<List<WaitingPatientDto>>(appointments);

        return data;
    }


    public async Task<List<WaitingPatientDto>> GetVisitHistory()
    {
        var todayDate = DateTime.Now.Date;
        var appointments = await context.WaitingAppointments
            .Include(x => x.Appointment)
            .Include(x => x.Appointment.AppointmentType)
            .Include(x => x.Appointment.Hcp)
            .Include(x => x.Patient)
            .Include(x => x.Patient.PatientAccount)
            .Where(x => x.ClinicId == ApplicationState.Auth.CurrentUser.ClinicId
                        && x.Appointment.StartTime.Date == todayDate)
            .ToListAsync();


        var data = mapper.Map<List<WaitingPatientDto>>(appointments);
        return data;
    }

    public async Task<IResult> UpdateWaitingAppointment(Guid appointmentId, string status,
        Guid consultationId = default)
    {
        var waitingAppointment = await context.WaitingAppointments
            .FirstOrDefaultAsync(x => x.AppointmentId == appointmentId);
        if (waitingAppointment is null)
        {
            return await Result.FailAsync("Appointment is not found.");
        }

        waitingAppointment.Status = status;


        switch (status)
        {
            case AppointmentConstants.WaitingStatus.InConsultation:
                waitingAppointment.ConsultationId = consultationId;
                break;
            case AppointmentConstants.WaitingStatus.Cancelled:
                await appointmentService.CancelAppointment(waitingAppointment.AppointmentId, 0);
                break;
            case AppointmentConstants.WaitingStatus.Completed:
                await consultationService.FinishConsultation(consultationId);
                break;
        }

        context.ChangeTracker.Clear();
        context.WaitingAppointments.Update(waitingAppointment);
        await context.SaveChangesAsync();


        return await Result.SuccessAsync("Appointment has been updated.");
    }

    private async Task AddExpectedPatients()
    {
        var list = new List<WaitingAppointment>();
        var todayDate = DateTime.Now.Date;
        var appointments = await context.Appointments
            .Where(x => x.StartTime.Date == todayDate && x.Status == AppointmentConstants.Status.Active)
            .ToListAsync();

        foreach (var item in appointments)
        {
            var waitingAppointment =
                await context.WaitingAppointments
                    .Include(x => x.Appointment)
                    .Include(x => x.Patient)
                    .Include(x => x.Patient.PatientAccount)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.AppointmentId == item.Id);


            if (waitingAppointment is null)
            {
                var waitAppt = new WaitingAppointment()
                {
                    PatientId = item.PatientId,
                    AppointmentId = item.Id,
                    ClinicId = ApplicationState.Auth.CurrentUser.ClinicId,
                    Status = AppointmentConstants.WaitingStatus.Expected
                };
                list.Add(waitAppt);
            }
        }

        await context.WaitingAppointments.AddRangeAsync(list);
        await context.SaveChangesAsync();
    }
}