﻿using Domain.Entities.Appointments;
using Domain.Entities.Messaging;
using Domain.Entities.Settings;
using Domain.Entities.Settings.Consultation;
using Domain.Entities.Settings.Consultation.Immunisation;
using Domain.Entities.Settings.Drugs;
using Domain.Entities.Settings.Templates;
using Services.Features.Settings.Dtos;
using Services.Features.Settings.Dtos.Immunisations;
using Shared.Constants.Module;
using Shared.Wrapper;

namespace Services.Features.Settings.Service;

public interface ISettingService
{
    #region Sms Template

    public Task<List<SmsTemplate>> GetSmsTemplates();
    public Task<IResult<SmsTemplate>> GetSmsTemplate(Guid id);
    public Task<IResult> SaveSmsTemplate(Guid id, SmsTemplate request);
    public Task<IResult> DeleteSmsTemplate(Guid id);

    #endregion

    #region Hospital

    public Task<List<ClinicDto>> GetClinics();
    public Task<IResult<ClinicDto>> GetClinic(int id);
    public Task<IResult> SaveClinic(int id, ClinicDto request);
    public Task<IResult> DeleteClinic(int id);


    public Task<List<ClinicSiteDto>> GetClinicSites();
    public Task<List<ClinicSiteDto>> GetSitesByClinic(int clinicId);
    public Task<IResult<ClinicSiteDto>> GetClinicSite(int id);

    public Task<IResult> SaveClinicSite(int id, ClinicSiteDto request);
    public Task<IResult> DeleteClinicSite(int id);

    #endregion

    #region Email Template

    public Task<List<EmailTemplate>> GetEmailTemplates();
    public Task<IResult<EmailTemplate>> GetEmailTemplate(Guid id);
    public Task<IResult> SaveEmailTemplate(Guid id, EmailTemplate request);
    public Task<IResult> DeleteEmailTemplate(Guid id);

    #endregion

    #region Appointment Type

    public Task<List<AppointmentTypeDto>> GetAppointmentTypes();
    public Task<IResult<AppointmentTypeDto>> GetAppointmentType(int id);
    public Task<IResult> SaveAppointmentType(int id, AppointmentTypeDto request);
    public Task<IResult> DeleteAppointmentType(int id);

    #endregion

    #region Appointment Cancel Reason

    public Task<List<AppointmentCancellationReason>> GetAppointmentCancelReasons();
    public Task<IResult<AppointmentCancellationReason>> GetAppointmentCancelReason(int id);
    public Task<IResult> SaveAppointmentCancelReason(int id, AppointmentCancellationReason request);
    public Task<IResult> DeleteAppointmentCancelReason(int id);

    #endregion

    #region Account Types

    public Task<AccountTypeDto> GetAccountType(int id);
    public Task<List<AccountTypeDto>> GetAllAccountTypes(TransactionActionType? accountTypes);
    public Task<IResult> SaveAccountType(int id, AccountTypeDto request);
    public Task<IResult> DeleteAccountType(int id);

    #endregion

    #region Pomr Group

    public Task<PomrGroup> GetPomrGroup(int id);
    public Task<List<PomrGroup>> GetAllPomrGroups();
    public Task<IResult> SavePomrGroup(int id, PomrGroup request);
    public Task<IResult> DeletePomrGroup(int id);

    #endregion

    #region Note Template

    public Task<NoteTemplateDto> GetNoteTemplate(int id);
    public Task<List<NoteTemplateDto>> GetAllNoteTemplates();
    public Task<IResult> SaveNoteTemplate(int id, NoteTemplateDto request);
    public Task<IResult> DeleteNoteTemplate(int id);

    #endregion

    #region Immunisations

    #region Shot

    Task<List<Shot>> GetShotsList();
    Task<ShotDto> GetShotsDetail(int id);
    Task<IResult> SaveShot(Shot shot);
    Task<IResult> DeleteShot(int id);
    Task<IResult> DeleteBatchFromShot(int batchId);
    Task<IResult> AssignBatchToShot(AssignShotToBatchDto assignShotToBatch);

    #endregion

    #region Batch

    Task<List<BatchDetail>> GetBatches();
    Task<IResult<UpsertBatchDto>> GetUpdateBatchDetail(int id);
    Task<IResult> UpsertBatch(int id,int shotId, UpsertBatchDto batch);
    Task<IResult> DeleteBatch(int id);

    #endregion

    #region Courses

    Task<List<Course>> GetCourses();
    Task<CourseDto> GetCourse(int courseId);
    Task<IResult> SaveCourse(int courseId, Course course);
    Task<IResult> AddShotInCourse(int courseId, List<int> shotIds);
    Task<List<Shot>> GetSelectedShot(int courseId);
    Task<IResult> DeleteCourse(int id);

    #endregion

    #region Immunisation Setup

    Task<List<ImmunisationSetup>> GetImmunisationSetups();
    Task<ImmunisationSetupDto> GetImmunisationSetup(int setupId);
    Task<IResult> SaveImmunisationSetup(int setupId, ImmunisationSetup setup);
    Task<IResult> AddCourseInSchedule(int setupId, List<int> courseIds);
    Task<List<Course>> GetSelectedCourse(int setupId);
    Task<IResult> DeleteImmunisationSetup(int setupId);

    #endregion

    #endregion

    #region Drug

    Task<IEnumerable<Drug>> GetAllDrugsAsync();
    Task<Result<Drug>> GetDrugByIdAsync(int id);
    Task<IResult> UpsertDrugAsync(int id, Drug drug);
    Task<IResult> DeleteDrugAsync(int id);

    #endregion
}