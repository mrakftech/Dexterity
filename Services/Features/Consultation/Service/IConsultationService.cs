﻿using Services.Features.Consultation.Dto;
using Services.Features.Consultation.Dto.BaselineDetails;
using Services.Features.Consultation.Dto.Reminder;
using Shared.Wrapper;

namespace Services.Features.Consultation.Service;

public interface IConsultationService
{
    Task<IResult> BeginConsultation(int id, BeginConsultationDto request);
    Task<List<GetConsultationDetailDto>> GetConsultationDetails(Guid patientId);


    #region Baseline Details

    Task<List<BaselineDetailDto>> GetBaselineDetails();
    Task<IResult<Guid>> SaveBaselineDetail(Guid id, CreateBaselineDetailDto request);
    Task<IResult<Guid>> DeleteBaselineDetail(Guid id);


    Task<List<GetReminderDto>> GetReminders();
    Task<int> GetActiveRemindersCount();
    Task<IResult> SaveReminders(int id,UpsertReminderDto request);
    Task<IResult> CompleteReminder(int id);
    Task<IResult> DeleteReminder(int id);

    #endregion
}