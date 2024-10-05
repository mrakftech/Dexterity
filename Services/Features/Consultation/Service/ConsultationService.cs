using AutoMapper;
using Database;
using Domain.Entities.Consultation;
using Domain.Entities.Settings.Consultation;
using Microsoft.EntityFrameworkCore;
using Services.Features.Consultation.Dto;
using Services.Features.Consultation.Dto.BaselineDetails;
using Services.Features.Consultation.Dto.Notes;
using Services.Features.Consultation.Dto.Reminder;
using Services.State;
using Shared.Wrapper;

namespace Services.Features.Consultation.Service;

public class ConsultationService(ApplicationDbContext context, IMapper mapper) : IConsultationService
{
    public async Task<List<GetConsultationDetailDto>> GetConsultationDetails(Guid patientId)
    {
        var consultations = await context.ConsultationDetails
            .AsNoTracking()
            .Include(x => x.Hcp)
            .Where(x => x.PatientId == patientId)
            .ToListAsync();

        var mappedData = mapper.Map<List<GetConsultationDetailDto>>(consultations);
        return mappedData;
    }

    public async Task<IResult> BeginConsultation(BeginConsultationDto request)
    {
        try
        {
            var consultation = new ConsultationDetail()
            {
                ConsultationDate = request.ConsultationDate,
                ClinicSiteId = request.ClinicSiteId,
                ConsultationClass = request.ConsultationClass,
                PatientId = ApplicationState.SelectedPatientId,
                HcpId = ApplicationState.CurrentUser.UserId,
                ConsultationType = request.ConsultationType
            };
            context.ConsultationDetails.Add(consultation);
            await context.SaveChangesAsync();
            return await Result.SuccessAsync("Consultation has been added.");
        }
        catch (Exception e)
        {
            return await Result<Guid>.FailAsync(e.Message);
        }
    }

    public async Task<IResult> EditConsultation(int id, EditConsultationDto request)
    {
        var consultation = await context.ConsultationDetails.FirstOrDefaultAsync(x => x.Id == id);
        if (consultation is null)
            return await Result.FailAsync("Consultation not found");

        consultation.ConsultationDate = request.ConsultationDate;
        consultation.ConsultationClass = request.ConsultationClass;
        consultation.Pomr = request.Pomr;
        consultation.ConsultationType = request.ConsultationType;
        consultation.ClinicSiteId = request.ClinicSiteId;

        context.ConsultationDetails.Update(consultation);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Consultation has been saved.");
    }

    public async Task<EditConsultationDto> GetConsultationDetail(int id)
    {
        var consultation = await context.ConsultationDetails.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (consultation is null)
            return new EditConsultationDto();

        return new EditConsultationDto()
        {
            ConsultationDate = consultation.ConsultationDate,
            ClinicSiteId = consultation.ClinicSiteId,
            ConsultationClass = consultation.ConsultationClass,
            ConsultationType = consultation.ConsultationType,
            Pomr = consultation.Pomr,
        };
    }

    public async Task<IResult> FinishConsultation(int id)
    {
        var consultation = await context.ConsultationDetails.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (consultation is null)
            return await Result.FailAsync("Consultation not found.");

        consultation.IsFinished = true;
        context.ConsultationDetails.Update(consultation);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Consultation has been finished.");
    }

    public async Task<List<BaselineDetailDto>> GetBaselineDetails()
    {
        var baselineDetails = await context.BaselineDetails
            .Include(x => x.Hcp)
            .Where(x => x.PatientId == ApplicationState.SelectedPatientId)
            .ToListAsync();
        var mapped = mapper.Map<List<BaselineDetailDto>>(baselineDetails);
        return mapped;
    }

    public async Task<IResult<Guid>> SaveBaselineDetail(Guid id, CreateBaselineDetailDto request)
    {
        try
        {
            var baselineDetail = mapper.Map<BaselineDetail>(request);
            if (id == Guid.Empty)
            {
                try
                {
                    context.BaselineDetails.Add(baselineDetail);
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return await Result<Guid>.FailAsync(e.Message);
                }
            }
            else
            {
                var baselineDetailInDb =
                    await context.BaselineDetails.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (baselineDetailInDb is null)
                {
                    return await Result<Guid>.FailAsync("detail not found.");
                }

                context.ChangeTracker.Clear();

                baselineDetailInDb = mapper.Map(request, baselineDetailInDb);
                context.BaselineDetails.Update(baselineDetailInDb);
                await context.SaveChangesAsync();
            }

            return await Result<Guid>.SuccessAsync(request.Id, "Details are saved.");
        }
        catch (Exception e)
        {
            return await Result<Guid>.FailAsync(e.Message);
        }
    }

    public async Task<IResult<Guid>> DeleteBaselineDetail(Guid id)
    {
        var baselineDetailInDb = await context.BaselineDetails.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (baselineDetailInDb is null)
        {
            return await Result<Guid>.FailAsync("detail not found.");
        }

        context.BaselineDetails.Remove(baselineDetailInDb);
        await context.SaveChangesAsync();
        return await Result<Guid>.SuccessAsync("Details are deleted.");
    }


    #region Notes

    public async Task<List<HealthCode>> GetHealthCodes()
    {
        return await context.HealthConditionCodes.ToListAsync();
    }


    public async Task<List<ConsultationNoteDto>> GetConsultationNotes()
    {
        var notes = await context.ConsultationNotes
            .Include(x => x.HealthCode)
            .Include(x => x.ConsultationDetail.Hcp)
            .Where(x => x.ConsultationDetail.PatientId == ApplicationState.SelectedPatientId)
            .ToListAsync();
        var mapped = mapper.Map<List<ConsultationNoteDto>>(notes);
        return mapped;
    }

    public async Task<List<ConsultationNoteDto>> GetActiveDiagonsis()
    {
        var notes = await context.ConsultationNotes
            .Include(x => x.HealthCode)
            .Include(x => x.ConsultationDetail.Hcp)
            .Where(x => x.ConsultationDetail.PatientId == ApplicationState.SelectedPatientId && x.IsActiveCondition)
            .AsNoTracking()
            .ToListAsync();
        var mapped = mapper.Map<List<ConsultationNoteDto>>(notes);
        return mapped;
    }

    public async Task<List<ConsultationNoteDto>> GetPastMedicalHistory()
    {
        var notes = await context.ConsultationNotes
            .Include(x => x.HealthCode)
            .Include(x => x.ConsultationDetail.Hcp)
            .Where(x => x.ConsultationDetail.PatientId == ApplicationState.SelectedPatientId && x.IsPastHistory || x.IsScoialHistory ||
                        x.IsFamilyHistory)
            .AsNoTracking()
            .ToListAsync();
        var mapped = mapper.Map<List<ConsultationNoteDto>>(notes);
        return mapped;
    }

    public async Task<IResult> UpsertConsultationNote(int id, UpsertConsultationNoteDto request)
    {
        try
        {
            if (id == 0)
            {
                var note = mapper.Map<ConsultationNote>(request);
                await context.ConsultationNotes.AddAsync(note);
                await context.SaveChangesAsync();
                return await Result.SuccessAsync("Note has been added.");
            }
            else
            {
                var noteInDb = await context.ConsultationNotes.FirstOrDefaultAsync(x => x.Id == id);
                noteInDb = mapper.Map(request, noteInDb);
                context.ConsultationNotes.Update(noteInDb);
                await context.SaveChangesAsync();
                return await Result.SuccessAsync("Note has been updated.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return await Result.FailAsync(e.Message);
        }
    }

    public async Task<ConsultationNoteDto> GetConsultationNote(int id)
    {
        var note = await context.ConsultationNotes
            .Include(x => x.HealthCode)
            .FirstOrDefaultAsync(x => x.Id == id);
        return note is null ? new ConsultationNoteDto() : mapper.Map<ConsultationNoteDto>(note);
    }

    public async Task<UpsertConsultationNoteDto> GetConsultationEditNote(int id)
    {
        var note = await context.ConsultationNotes
            .FirstOrDefaultAsync(x => x.Id == id);
        return note is null ? new UpsertConsultationNoteDto() : mapper.Map<UpsertConsultationNoteDto>(note);
    }

    public async Task<IResult<int>> DeleteConsultationNote(int id)
    {
        var note = await context.ConsultationNotes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (note is null)
        {
            return await Result<int>.FailAsync("detail not found.");
        }

        context.ConsultationNotes.Remove(note);
        await context.SaveChangesAsync();
        return await Result<int>.SuccessAsync("note deleted.");
    }

    #endregion

    #region Reminders

    public async Task<List<GetReminderDto>> GetReminders()
    {
        var reminders = await context.Reminders
            .Include(x => x.Hcp)
            .Where(x => x.PatientId == ApplicationState.SelectedPatientId)
            .ToListAsync();
        var mapped = mapper.Map<List<GetReminderDto>>(reminders);
        return mapped;
    }

    public async Task<int> GetActiveRemindersCount()
    {
        var reminders = await context.Reminders
            .Where(x => x.PatientId == ApplicationState.SelectedPatientId && x.IsActive)
            .ToListAsync();

        return reminders.Count;
    }

    public async Task<IResult> SaveReminders(int id, UpsertReminderDto request)
    {
        if (id == 0)
        {
            request.IsActive = true;
            var mappedData = mapper.Map<Reminder>(request);
            await context.Reminders.AddAsync(mappedData);
            await context.SaveChangesAsync();
            return await Result.SuccessAsync("Reminder added.");
        }
        else
        {
            var reminderInDb = await context.Reminders
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            if (reminderInDb is null)
            {
                return await Result<Guid>.FailAsync("reminder not found.");
            }

            reminderInDb = mapper.Map(request, reminderInDb);
            context.Reminders.Update(reminderInDb);
            await context.SaveChangesAsync();
            return await Result.SuccessAsync("Reminder saved.");
        }
    }

    public async Task<IResult> CompleteReminder(int id)
    {
        var reminderInDb = await context.Reminders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (reminderInDb is null)
        {
            return await Result<Guid>.FailAsync("reminder not found.");
        }

        reminderInDb.IsActive = false;
        context.ChangeTracker.Clear();
        context.Reminders.Update(reminderInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Reminder mark as completed.");
    }

    public async Task<IResult> DeleteReminder(int id)
    {
        var reminderInDb = await context.Reminders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (reminderInDb is null)
        {
            return await Result<Guid>.FailAsync("reminder not found.");
        }

        context.ChangeTracker.Clear();
        context.Reminders.Remove(reminderInDb);
        await context.SaveChangesAsync();
        return await Result<Guid>.SuccessAsync("Reminder is deleted.");
    }

    #endregion
}