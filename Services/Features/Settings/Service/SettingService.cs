using AutoMapper;
using Database;
using Domain.Entities.Appointments;
using Domain.Entities.Settings.Clinic;
using Domain.Entities.Settings.Consultation;
using Domain.Entities.Settings.Consultation.Immunisation;
using Domain.Entities.Settings.Drugs;
using Domain.Entities.Settings.Templates;
using Microsoft.EntityFrameworkCore;
using Services.Features.Settings.Dtos;
using Services.Features.Settings.Dtos.Immunisations;
using Services.State;
using Shared.Constants.Module;
using Shared.Wrapper;
using AccountType = Domain.Entities.Settings.Account.AccountType;

namespace Services.Features.Settings.Service;

public class SettingService(ApplicationDbContext context, IMapper mapper)
    : ISettingService
{
    #region Sms Templates

    public async Task<List<SmsTemplate>> GetSmsTemplates()
    {
        return await context.SmsTemplates.ToListAsync();
    }

    public async Task<IResult<SmsTemplate>> GetSmsTemplate(Guid id)
    {
        var smsTemplate = context.SmsTemplates.FirstOrDefault(x => x.Id == id);
        if (smsTemplate == null)
            return await Result<SmsTemplate>.FailAsync("template not found.");

        return await Result<SmsTemplate>.SuccessAsync(smsTemplate);
    }

    public async Task<IResult> SaveSmsTemplate(Guid id, SmsTemplate request)
    {
        if (id == Guid.Empty)
        {
            await context.SmsTemplates.AddAsync(request);
        }
        else
        {
            context.SmsTemplates.Update(request);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Sms template saved.");
    }

    public async Task<IResult> DeleteSmsTemplate(Guid id)
    {
        var smsTemplate = context.SmsTemplates.FirstOrDefault(x => x.Id == id);
        if (smsTemplate == null)
            return await Result.FailAsync("template not found.");
        context.SmsTemplates.Remove(smsTemplate);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Sms template deleted.");
    }

    #endregion

    #region Clinics

    public async Task<List<ClinicDto>> GetClinics()
    {
        var data = await context.Clinics.ToListAsync();
        var mappedData = mapper.Map<List<ClinicDto>>(data);
        return mappedData;
    }

    public async Task<IResult<ClinicDto>> GetClinic(int id)
    {
        var clinic = context.Clinics.FirstOrDefault(x => x.Id == id);

        if (clinic == null)
            return await Result<ClinicDto>.FailAsync("clinic not found.");
        var mappedData = mapper.Map<ClinicDto>(clinic);
        return await Result<ClinicDto>.SuccessAsync(mappedData);
    }

    public async Task<IResult> SaveClinic(int id, ClinicDto request)
    {
        if (id == 0)
        {
            var mappedData = mapper.Map<Clinic>(request);

            await context.Clinics.AddAsync(mappedData);
        }
        else
        {
            var clinic = context.Clinics.FirstOrDefault(x => x.Id == id);

            if (clinic == null)
                return await Result<ClinicDto>.FailAsync("clinic not found.");

            var updatedData = mapper.Map(request, clinic);
            context.Clinics.Update(updatedData);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Clinic saved.");
    }

    public async Task<IResult> DeleteClinic(int id)
    {
        var clinic = context.Clinics.FirstOrDefault(x => x.Id == id);
        if (clinic == null)
            return await Result.FailAsync("clinic not found.");

        context.Clinics.Remove(clinic);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Clinic deleted.");
    }

    public async Task<List<ClinicSiteDto>> GetClinicSites()
    {
        var data = await context.ClinicSites.ToListAsync();
        var mappedData = mapper.Map<List<ClinicSiteDto>>(data);
        return mappedData;
    }

    public async Task<List<ClinicSiteDto>> GetSitesByClinic(int clinicId)
    {
        var data = await context.ClinicSites.Where(x => x.ClinicId == clinicId).ToListAsync();
        var mappedData = mapper.Map<List<ClinicSiteDto>>(data);
        return mappedData;
    }

    public async Task<IResult<ClinicSiteDto>> GetClinicSite(int id)
    {
        var clinic = context.ClinicSites.FirstOrDefault(x => x.Id == id);

        if (clinic == null)
            return await Result<ClinicSiteDto>.FailAsync("clinic not found.");
        var mappedData = mapper.Map<ClinicSiteDto>(clinic);
        return await Result<ClinicSiteDto>.SuccessAsync(mappedData);
    }

    public async Task<IResult> SaveClinicSite(int id, ClinicSiteDto request)
    {
        if (id == 0)
        {
            var mappedData = mapper.Map<ClinicSite>(request);
            await context.ClinicSites.AddAsync(mappedData);
        }
        else
        {
            var clinic = context.ClinicSites.FirstOrDefault(x => x.Id == id);

            if (clinic == null)
                return await Result<ClinicSiteDto>.FailAsync("clinic site not found.");

            var updatedData = mapper.Map(request, clinic);
            context.ClinicSites.Update(updatedData);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Clinic site saved.");
    }

    public async Task<IResult> DeleteClinicSite(int id)
    {
        var clinic = context.ClinicSites.FirstOrDefault(x => x.Id == id);
        if (clinic == null)
            return await Result.FailAsync("clinic site not found.");

        context.ClinicSites.Remove(clinic);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Clinic site deleted.");
    }

    #endregion

    #region Email Templates

    public async Task<List<EmailTemplate>> GetEmailTemplates()
    {
        return await context.EmailTemplates.ToListAsync();
    }

    public async Task<IResult<EmailTemplate>> GetEmailTemplate(Guid id)
    {
        var emailTemplate = context.EmailTemplates.FirstOrDefault(x => x.Id == id);
        if (emailTemplate == null)
            return await Result<EmailTemplate>.FailAsync("template not found.");

        return await Result<EmailTemplate>.SuccessAsync(emailTemplate);
    }

    public async Task<IResult> SaveEmailTemplate(Guid id, EmailTemplate request)
    {
        if (id == Guid.Empty)
        {
            await context.EmailTemplates.AddAsync(request);
        }
        else
        {
            context.EmailTemplates.Update(request);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Sms template saved.");
    }

    public async Task<IResult> DeleteEmailTemplate(Guid id)
    {
        var email = context.EmailTemplates.FirstOrDefault(x => x.Id == id);
        if (email == null)
            return await Result.FailAsync("template not found.");
        context.EmailTemplates.Remove(email);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Sms template deleted.");
    }

    #endregion

    #region Appointment Type

    public async Task<List<AppointmentTypeDto>> GetAppointmentTypes()
    {
        var list = await context.AppointmentTypes.ToListAsync();
        var data = mapper.Map<List<AppointmentTypeDto>>(list);
        return data;
    }

    public async Task<IResult<AppointmentTypeDto>> GetAppointmentType(int id)
    {
        var appointmentType = context.AppointmentTypes.FirstOrDefault(x => x.Id == id);

        if (appointmentType == null)
            return await Result<AppointmentTypeDto>.FailAsync("Appointment Type not found.");

        var data = mapper.Map<AppointmentTypeDto>(appointmentType);

        return await Result<AppointmentTypeDto>.SuccessAsync(data);
    }

    public async Task<IResult> SaveAppointmentType(int id, AppointmentTypeDto request)
    {
        if (id == 0)
        {
            var appt = mapper.Map<AppointmentType>(request);
            await context.AppointmentTypes.AddAsync(appt);
        }
        else
        {
            var appt = mapper.Map<AppointmentType>(request);
            context.AppointmentTypes.Update(appt);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Appointment Type saved.");
    }

    public async Task<IResult> DeleteAppointmentType(int id)
    {
        var appointmentType = context.AppointmentTypes.FirstOrDefault(x => x.Id == id);
        if (appointmentType == null)
            return await Result.FailAsync("Appointment Type not found.");
        context.AppointmentTypes.Remove(appointmentType);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Appointment Type deleted.");
    }

    #endregion

    #region Appointment Cancel Reasons

    public async Task<List<AppointmentCancellationReason>> GetAppointmentCancelReasons()
    {
        return await context.AppointmentCancellationReasons.ToListAsync();
    }

    public async Task<IResult<AppointmentCancellationReason>> GetAppointmentCancelReason(int id)
    {
        var appointmentType = context.AppointmentCancellationReasons.FirstOrDefault(x => x.Id == id);

        if (appointmentType == null)
            return await Result<AppointmentCancellationReason>.FailAsync("Appointment reason not found.");

        return await Result<AppointmentCancellationReason>.SuccessAsync(appointmentType);
    }

    public async Task<IResult> SaveAppointmentCancelReason(int id, AppointmentCancellationReason request)
    {
        if (id == 0)
        {
            await context.AppointmentCancellationReasons.AddAsync(request);
        }
        else
        {
            context.AppointmentCancellationReasons.Update(request);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Appointment cancel reason saved.");
    }

    public async Task<IResult> DeleteAppointmentCancelReason(int id)
    {
        var cancellationReason = context.AppointmentCancellationReasons.FirstOrDefault(x => x.Id == id);
        if (cancellationReason == null)
            return await Result.FailAsync("Appointment reason not found..");
        context.AppointmentCancellationReasons.Remove(cancellationReason);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Appointment Cancel Reason deleted.");
    }

    #endregion

    #region Account Type

    public async Task<AccountTypeDto> GetAccountType(int id)
    {
        var accountInDb = await context.AccountTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (accountInDb is null)
            return new AccountTypeDto();
        var mapped = mapper.Map<AccountTypeDto>(accountInDb);
        return mapped;
    }

    public async Task<List<AccountTypeDto>> GetAllAccountTypes(TransactionActionType? accountTypes)
    {
        var list = new List<AccountType>();
        switch (accountTypes)
        {
            case TransactionActionType.Charge:
                list = await context.AccountTypes
                    .Where(x => x.IsActive && x.Type == TransactionActionType.Charge)
                    .ToListAsync();
                break;
            case TransactionActionType.Payment:
                list = await context.AccountTypes
                    .Where(x => x.IsActive && x.Type == TransactionActionType.Payment)
                    .ToListAsync();
                break;
            case TransactionActionType.StrikeOff:
                list = await context.AccountTypes
                    .Where(x => x.IsActive && x.Type == TransactionActionType.StrikeOff)
                    .ToListAsync();
                break;
            default:
                list = await context.AccountTypes
                    .Where(x => x.IsActive)
                    .ToListAsync();
                break;
        }


        var mapped = mapper.Map<List<AccountTypeDto>>(list);
        return mapped;
    }

    public async Task<List<AccountTypeDto>> GetAllAccountTypes()
    {
        var list = await context.AccountTypes.Where(x => x.IsActive).ToListAsync();
        var mapped = mapper.Map<List<AccountTypeDto>>(list);
        return mapped;
    }

    public async Task<IResult> SaveAccountType(int id, AccountTypeDto request)
    {
        try
        {
            var account = mapper.Map<AccountType>(request);
            if (id == 0)
            {
                await context.AccountTypes.AddAsync(account);
                await context.SaveChangesAsync();
            }
            else
            {
                var accountInDb = await context.AccountTypes.FirstOrDefaultAsync(x => x.Id == id);
                if (accountInDb is null)
                    return await Result.FailAsync("Account type is not found");

                accountInDb.IsActive = request.IsActive;
                accountInDb.Name = request.Name;
                accountInDb.Amount = request.Amount;
                accountInDb.Type = request.Type;
                context.AccountTypes.Update(accountInDb);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            return await Result.FailAsync(e.Message);
        }

        return await Result.SuccessAsync("Account added.");
    }

    public async Task<IResult> DeleteAccountType(int id)
    {
        var accountInDb = await context.AccountTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (accountInDb is null)
            return await Result.FailAsync("Account type is not found");
        context.AccountTypes.Remove(accountInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Account deleted.");
    }

    #endregion

    #region Pomr Group

    public async Task<PomrGroup> GetPomrGroup(int id)
    {
        var pomrGroup = await context.PomrGroups.FirstOrDefaultAsync(x => x.Id == id);
        return pomrGroup ?? new PomrGroup();
    }

    public async Task<List<PomrGroup>> GetAllPomrGroups()
    {
        return await context.PomrGroups.Where(x => x.ClinicId == ApplicationState.CurrentUser.ClinicId).ToListAsync();
    }

    public async Task<IResult> SavePomrGroup(int id, PomrGroup request)
    {
        if (id == 0)
        {
            request.ClinicId = ApplicationState.CurrentUser.ClinicId;
            await context.PomrGroups.AddAsync(request);
            await context.SaveChangesAsync();
        }
        else
        {
            var pomrGroup = await context.PomrGroups.FirstOrDefaultAsync(x => x.Id == id);
            if (pomrGroup is null)
                return await Result.FailAsync("POMR Group is not found");
            pomrGroup.Name = request.Name;
            context.PomrGroups.Update(pomrGroup);
            await context.SaveChangesAsync();
        }

        return await Result.SuccessAsync("POMR group saved.");
    }

    public async Task<IResult> DeletePomrGroup(int id)
    {
        var pomrGroup = await context.PomrGroups.FirstOrDefaultAsync(x => x.Id == id);
        if (pomrGroup is null)
            return await Result.FailAsync("POMR Group is not found");

        context.PomrGroups.Remove(pomrGroup);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("POMR group deleted.");
    }

    #endregion

    #region Note Template

    public async Task<NoteTemplateDto> GetNoteTemplate(int id)
    {
        var noteTemplate = await context.NoteTemplates.Include(x => x.HealthCode).FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<NoteTemplateDto>(noteTemplate) ?? new NoteTemplateDto();
    }

    public async Task<List<NoteTemplateDto>> GetAllNoteTemplates()
    {
        var list = await context.NoteTemplates
            .Include(x => x.HealthCode)
            .ToListAsync();

        return mapper.Map<List<NoteTemplateDto>>(list);
    }

    public async Task<IResult> SaveNoteTemplate(int id, NoteTemplateDto request)
    {
        var noteTemplate = mapper.Map<NoteTemplate>(request);

        if (id == 0)
        {
            await context.NoteTemplates.AddAsync(noteTemplate);
            await context.SaveChangesAsync();
        }
        else
        {
            var template = await context.NoteTemplates.FirstOrDefaultAsync(x => x.Id == id);
            if (template is null)
                return await Result.FailAsync("Note Template is not found");
            template.Note = noteTemplate.Note;
            template.IsActive = noteTemplate.IsActive;
            template.HealthCodeId = noteTemplate.HealthCodeId;
            context.NoteTemplates.Update(template);
            await context.SaveChangesAsync();
        }

        return await Result.SuccessAsync("Note Template saved.");
    }

    public async Task<IResult> DeleteNoteTemplate(int id)
    {
        var noteTemplate = await context.NoteTemplates.FirstOrDefaultAsync(x => x.Id == id);
        if (noteTemplate is null)
            return await Result.FailAsync("Note Template is not found");

        context.NoteTemplates.Remove(noteTemplate);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Note Template deleted.");
    }

    #endregion

    #region Drug

    public async Task<IEnumerable<Drug>> GetAllDrugsAsync()
    {
        return await context.Drugs.ToListAsync();
    }

    public async Task<Result<Drug>> GetDrugByIdAsync(int id)
    {
        var drugInDb = await context.Drugs.FindAsync(id);
        if (drugInDb is not null)
        {
            return await Result<Drug>.SuccessAsync(drugInDb);
        }

        return await Result<Drug>.FailAsync("Drug not found");
    }

    public async Task<IResult> UpsertDrugAsync(int id, Drug drug)
    {
        if (id == 0)
        {
            context.Drugs.Add(drug);
            await context.SaveChangesAsync();
            return await Result.SuccessAsync("Drug added");
        }

        var drugInDb = await context.Drugs.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (drugInDb is null)
        {
            return await Result<Drug>.FailAsync("Drug not found");
        }

        drugInDb = drug;
        context.ChangeTracker.Clear();
        context.Drugs.Update(drugInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Drug saved");
    }

    public async Task<IResult> DeleteDrugAsync(int id)
    {
        var drug = await context.Drugs.FindAsync(id);
        if (drug == null)
        {
            return await Result.FailAsync("Drug not found");
        }

        context.Drugs.Remove(drug);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Drug deleted");
    }

    private async Task<bool> DrugExistsAsync(int id)
    {
        return await context.Drugs.AnyAsync(e => e.Id == id);
    }

    #endregion

    #region Immunisations

    #region Shot

    public async Task<List<Shot>> GetShotsList()
    {
        return await context.Shots.Where(x => x.IsActive).ToListAsync();
    }

    public async Task<ShotDto> GetShotsDetail(int id)
    {
        var shotInDb = await context.Shots.FirstOrDefaultAsync(x => x.Id == id);
        var batchDetails = await context.AssignedBatchToShots
            .Where(x => x.ShotId == id)
            .Select(x => x.BatchDetail)
            .ToListAsync();

        if (shotInDb is not null)
        {
            return new ShotDto()
            {
                BatchDetails = batchDetails,
                Shot = shotInDb
            };
        }

        return new ShotDto();
    }

    public async Task<IResult> SaveShot(Shot shot)
    {
        try
        {
            if (shot.Id == 0)
            {
                await context.Shots.AddAsync(shot);
                await context.SaveChangesAsync();
                return await Result.SuccessAsync("Shot added.");
            }

            var shotInDb = await context.Shots.AsNoTracking().FirstOrDefaultAsync(x => x.Id == shot.Id);
            if (shotInDb is null)
            {
                return await Result.FailAsync("shot not found");
            }

            shotInDb = shot;
            context.ChangeTracker.Clear();
            context.Shots.Update(shotInDb);
            await context.SaveChangesAsync();
            return await Result.SuccessAsync("Shot saved.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return await Result.FailAsync(e.Message);
        }
    }

    public async Task<IResult> DeleteShot(int id)
    {
        var shot = await context.Shots.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (shot is null) return await Result.FailAsync("Error occured while deleting Shot");
        context.ChangeTracker.Clear();
        context.Shots.Remove(shot);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Shot has been deleted");
    }

    public async Task<IResult> DeleteBatchFromShot(int batchId)
    {
        var batchInDb = await context.AssignedBatchToShots.AsNoTracking()
            .FirstOrDefaultAsync(x => x.BatchDetailId == batchId);
        if (batchInDb is null)
        {
            return await Result.FailAsync("Batch not found");
        }

        context.AssignedBatchToShots.Remove(batchInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Batch has been removed.");
    }

    public async Task<IResult> AssignBatchToShot(AssignShotToBatchDto assignShotToBatch)
    {
        var batchInDb = await context.BatchDetails
            .FirstOrDefaultAsync(x => x.BatchNumber == assignShotToBatch.BatchNumber && x.IsActive);
        var checkBatchInShot = await context.AssignedBatchToShots.AnyAsync(x =>
            x.BatchDetailId == batchInDb.Id && x.ShotId == assignShotToBatch.ShotId);
        if (checkBatchInShot)
        {
            return await Result.FailAsync("Batch already exists.");
        }

        if (batchInDb is null)
        {
            return await Result.FailAsync("Batch not found");
        }

        var shotBatchDetails = new AssignedBatchToShot()
        {
            ShotId = assignShotToBatch.ShotId,
            BatchDetailId = batchInDb.Id
        };
        await context.AssignedBatchToShots.AddAsync(shotBatchDetails);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Batch has been added under shot ");
    }

    #endregion

    #region Batch

    public async Task<IResult> UpsertBatch(int id, int shotId, UpsertBatchDto batch)
    {
        await using var transaction = await context.Database.BeginTransactionAsync();

        try
        {
            if (id == 0)
            {
                var newBatch = new BatchDetail()
                {
                    BatchNumber = batch.BatchNumber,
                    IsActive = batch.IsActive,
                    BatchCompleteWhenZero = batch.BatchCompleteWhenZero,
                    BatchCount = batch.BatchCount,
                    DrugId = batch.DrugId,
                    ManfactureName = batch.ManfactureName,
                    TradeName = batch.TradeName,
                    Remaining = batch.Remaining,
                    Expiry = batch.Expiry
                };
                await context.BatchDetails.AddAsync(newBatch);
                await context.SaveChangesAsync();
                var assignShotToBatch = new AssignShotToBatchDto()
                {
                    BatchNumber = newBatch.BatchNumber,
                    ShotId = shotId,
                };
                await AssignBatchToShot(assignShotToBatch);
                await transaction.CommitAsync();
                return await Result.SuccessAsync("Batch has been added");
            }
            else
            {
                var batchInDb = await context.BatchDetails.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (batchInDb is null)
                {
                    return await Result.FailAsync("Batch not found");
                }

                batchInDb = mapper.Map(batch, batchInDb);
                context.ChangeTracker.Clear();
                context.BatchDetails.Update(batchInDb);
                await context.SaveChangesAsync();
                return await Result.SuccessAsync("Batch has been saved ");
            }
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            Console.WriteLine(e);
            return await Result.FailAsync(e.Message);
        }
    }

    public async Task<IResult<UpsertBatchDto>> GetUpdateBatchDetail(int id)
    {
        var batchInDb = await context.BatchDetails
            .Include(x => x.Drug)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        if (batchInDb is null)
        {
            return await Result<UpsertBatchDto>.FailAsync("Batch not found");
        }

        var data = mapper.Map<UpsertBatchDto>(batchInDb);
        return await Result<UpsertBatchDto>.SuccessAsync(data);
    }

    public async Task<IResult> DeleteBatch(int id)
    {
        var batchInDb = await context.BatchDetails.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        if (batchInDb is null)
        {
            return await Result.FailAsync("Batch not found");
        }

        context.BatchDetails.Remove(batchInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Batch has been removed.");
    }

    public async Task<List<BatchDetail>> GetBatches()
    {
        var list = await context.BatchDetails.ToListAsync();
        return list;
    }

    #endregion

    #region Courses

    public async Task<List<Course>> GetCourses()
    {
        return await context.Courses.Where(x => x.IsActive).ToListAsync();
    }

    public async Task<CourseDto> GetCourse(int courseId)
    {
        var courseInDb = await context.Courses.FirstOrDefaultAsync(x => x.Id == courseId);
        var shots = await context.AssignedShotToCourses
            .Where(x => x.CourseId == courseId)
            .Select(x => x.Shot)
            .ToListAsync();

        return new CourseDto()
        {
            Course = courseInDb,
            Shots = shots
        };
    }

    public async Task<IResult> SaveCourse(int courseId, Course course)
    {
        try
        {
            if (courseId == 0)
            {
                await context.Courses.AddAsync(course);
                await context.SaveChangesAsync();
                return await Result.SuccessAsync("Course has been added.");
            }

            var courseInDb = await context.Courses.FirstOrDefaultAsync(x => x.Id == courseId);
            courseInDb.IsActive = course.IsActive;
            courseInDb.Name = course.Name;
            context.Courses.Update(courseInDb);
            await context.SaveChangesAsync();
            return await Result.SuccessAsync("Course has been saved.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return await Result.FailAsync(e.Message);
        }
    }


    public async Task<IResult> AssignedShotToCourse(int courseId, List<int> shotIds)
    {
        await ClearShotList(courseId);
        var list = shotIds.Select((item, index) => new AssignedShotToCourse()
                {CourseId = courseId, ShotId = item, Order = index + 1})
            .ToList();
        context.ChangeTracker.Clear();
        context.AssignedShotToCourses.AddRange(list);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Shot(s) has been saved.");
    }

    private async Task ClearShotList(int courseId)
    {
        var cleanPreviousData =
            await context.AssignedShotToCourses.AsNoTracking().Where(x => x.CourseId == courseId).ToListAsync();
        context.ChangeTracker.Clear();
        context.AssignedShotToCourses.RemoveRange(cleanPreviousData);
        await context.SaveChangesAsync();
    }

    public async Task<List<Shot>> GetAssignedShotToCourse(int courseId)
    {
        return await context.AssignedShotToCourses
            .Where(x => x.CourseId == courseId)
            .OrderBy(x => x.Order)
            .Select(x => x.Shot)
            .ToListAsync();
    }


    public async Task<IResult> DeleteCourse(int id)
    {
        var courseInDb = await context.Courses.FirstOrDefaultAsync(x => x.Id == id);
        context.Courses.Remove(courseInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Course has been deleted.");
    }

    #endregion

    #region Immunisation Programs

    public async Task<List<ImmunisationProgram>> GetImmunisationPrograms()
    {
        return await context.ImmunisationPrograms.ToListAsync();
    }

    public async Task<ImmunisationSetupDto> GetImmunisationProgram(int programId)
    {
        var immunisationProgram = await context.ImmunisationPrograms.FirstOrDefaultAsync(x => x.Id == programId);
        var courses = await context.AssignedCourseToPrograms
            .Where(x => x.ImmunisationProgramId == programId)
            .Select(x => x.Course)
            .ToListAsync();

        return new ImmunisationSetupDto()
        {
            ImmunisationProgram = immunisationProgram,
            Courses = courses
        };
    }

    public async Task<IResult> SaveImmunisationProgram(int setupId, ImmunisationProgram program)
    {
        try
        {
            if (setupId == 0)
            {
                await context.ImmunisationPrograms.AddAsync(program);
                await context.SaveChangesAsync();
                return await Result.SuccessAsync("Scheduling Program has been added.");
            }

            var courseInDb = await context.ImmunisationPrograms.FirstOrDefaultAsync(x => x.Id == setupId);
            courseInDb.IsActive = program.IsActive;
            courseInDb.Name = program.Name;
            courseInDb.IsDefualt = program.IsDefualt;
            courseInDb.IsChildhood = program.IsChildhood;
            context.ImmunisationPrograms.Update(courseInDb);
            await context.SaveChangesAsync();
            return await Result.SuccessAsync("Scheduling Program has been saved.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return await Result.FailAsync(e.Message);
        }
    }

    public async Task<IResult> AssignedCourseToSchedule(int programId, List<int> courseIds)
    {
        await ClearCourseList(programId);
        var list = courseIds.Select((item, index) => new AssignedCourseToProgram()
                {ImmunisationProgramId = programId, CourseId = item, Order = index + 1})
            .ToList();
        context.ChangeTracker.Clear();
        context.AssignedCourseToPrograms.AddRange(list);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Course(s) has been saved.");
    }


    public async Task<List<Course>> GetAssignedCoursesOfProgram(int programId)
    {
        return await context.AssignedCourseToPrograms
            .Where(x => x.ImmunisationProgramId == programId)
            .OrderBy(x => x.Order)
            .Select(x => x.Course)
            .ToListAsync();
    }

    public async Task<IResult> DeleteImmunisationProgram(int id)
    {
        var courseInDb = await context.ImmunisationPrograms.FirstOrDefaultAsync(x => x.Id == id);
        context.ImmunisationPrograms.Remove(courseInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Immunisation Setup has been deleted.");
    }

    private async Task ClearCourseList(int programId)
    {
        var cleanPreviousData =
            await context.AssignedCourseToPrograms.AsNoTracking().Where(x => x.ImmunisationProgramId == programId)
                .ToListAsync();
        context.ChangeTracker.Clear();
        context.AssignedCourseToPrograms.RemoveRange(cleanPreviousData);
        await context.SaveChangesAsync();
    }

    #endregion

    #endregion
}