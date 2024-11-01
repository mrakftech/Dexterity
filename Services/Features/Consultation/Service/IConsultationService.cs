﻿using Domain.Entities.Consultation;
using Domain.Entities.Settings.Consultation;
using Services.Features.Consultation.Dto;
using Services.Features.Consultation.Dto.BaselineDetails;
using Services.Features.Consultation.Dto.Immunisations;
using Services.Features.Consultation.Dto.Notes;
using Services.Features.Consultation.Dto.Reminder;
using Shared.Wrapper;

namespace Services.Features.Consultation.Service;

public interface IConsultationService
{
    Task<IResult> BeginConsultation(BeginConsultationDto request);
    Task<IResult> EditConsultation(int id, EditConsultationDto request);
    Task<List<GetConsultationDetailDto>> GetConsultationDetails(Guid patientId);
    Task<EditConsultationDto> GetConsultationDetail(int id);
    Task<IResult> FinishConsultation(int id);


    #region Baseline Details

    Task<List<BaselineDetailDto>> GetBaselineDetails();
    Task<IResult<Guid>> SaveBaselineDetail(Guid id, CreateBaselineDetailDto request);
    Task<IResult<Guid>> DeleteBaselineDetail(Guid id);

    #endregion

    #region Notes

    Task<List<HealthCode>> GetHealthCodes();
    Task<List<ConsultationNoteDto>> GetConsultationNotes();
    Task<List<ConsultationNoteDto>> GetActiveDiagonsisByPatient();
    Task<List<ConsultationNoteDto>> GetPastMedicalHistory();
    Task<IResult> UpsertConsultationNote(int id, UpsertConsultationNoteDto request);
    Task<UpsertConsultationNoteDto> GetConsultationEditNote(int id);
    Task<ConsultationNoteDto> GetConsultationNote(int id);
    Task<IResult<int>> DeleteConsultationNote(int id);

    #endregion

    #region Immunisations

    Task<IResult> SaveImmunisationSchedule(ImmunisationSchedule request);
    Task<List<ImmunisationScheduleDto>> GetImmunisationSchedule(Guid patientId);
    Task<List<AdministerShot>> GetAdministerShots(Guid scheduleId);
    Task<AdministerShotDto> GetAdministerShot(Guid id);
    Task<IResult> GivenAdministerShot(Guid id, AdministerShotDto request);
    Task<IResult> CancelAdministerShot(Guid id);
    Task<List<AdministerShot>> FilterAdministerShots(Guid scheduleId,string type);
    Task<IResult> SaveReaction(Guid id, Reaction reaction);
    Task<List<Reaction>> GetReactions(Guid administerId);
    Task<IResult> RemoveReaction(Guid id);

    #endregion

    #region Reminder

    Task<List<GetReminderDto>> GetReminders();
    Task<int> GetActiveRemindersCount();
    Task<IResult> SaveReminders(int id, UpsertReminderDto request);
    Task<IResult> CompleteReminder(int id);
    Task<IResult> DeleteReminder(int id);

    #endregion
}