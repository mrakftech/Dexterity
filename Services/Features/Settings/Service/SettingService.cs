using AutoMapper;
using Database;
using Domain.Entities.Appointments;
using Domain.Entities.Settings.Clinic;
using Domain.Entities.Settings.Consultation;
using Domain.Entities.Settings.Consultation.Immunisation;
using Domain.Entities.Settings.Drugs;
using Domain.Entities.Settings.Templates;
using Domain.Entities.Settings.Templates.Dms;
using Domain.Entities.Settings.Templates.Forms;
using Domain.Entities.Settings.Templates.InvestigationTemplates;
using Domain.Entities.Settings.Templates.Letter;
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
        List<AccountType> list;
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

    public async Task<ShotDto> GetShotsDetail(Guid shotId)
    {
        var shotInDb = await context.Shots.FirstOrDefaultAsync(x => x.Id == shotId);
        var batchDetails = await context.ShotBatches
            .Where(x => x.ShotId == shotId)
            .Select(x => x.Batch)
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
            if (shot.Id == Guid.Empty)
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

    public async Task<IResult> DeleteShot(Guid shotId)
    {
        var shot = await context.Shots.AsNoTracking().FirstOrDefaultAsync(x => x.Id == shotId);
        if (shot is null) return await Result.FailAsync("Error occured while deleting Shot");
        context.ChangeTracker.Clear();
        context.Shots.Remove(shot);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Shot has been deleted");
    }

    public async Task<IResult> DeleteBatchFromShot(Guid batchId)
    {
        var batchInDb = await context.ShotBatches.AsNoTracking()
            .FirstOrDefaultAsync(x => x.BatchId == batchId);
        if (batchInDb is null)
        {
            return await Result.FailAsync("Batch not found");
        }

        context.ShotBatches.Remove(batchInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Batch has been removed.");
    }

    public async Task<IResult> AssignBatchToShot(AssignShotToBatchDto assignShotToBatch)
    {
        var batchInDb = await context.Batches
            .FirstOrDefaultAsync(x => x.BatchNumber == assignShotToBatch.BatchNumber && x.IsActive);

        var checkBatchInShot = await context.ShotBatches.AnyAsync(x =>
            x.BatchId == batchInDb.Id && x.ShotId == assignShotToBatch.ShotId);

        if (checkBatchInShot)
        {
            return await Result.FailAsync("Batch already exists.");
        }

        if (batchInDb is null)
        {
            return await Result.FailAsync("Batch not found");
        }

        var shotBatchDetails = new ShotBatch()
        {
            ShotId = assignShotToBatch.ShotId,
            BatchId = batchInDb.Id
        };
        await context.ShotBatches.AddAsync(shotBatchDetails);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Batch has been added under shot ");
    }

    public async Task<ShotBatch> GetShotBatchByShotId(Guid shotId)
    {
        var shotBatch = await context
            .ShotBatches
            .Include(x => x.Batch)
            .Where(x => x.ShotId == shotId && x.Batch.IsActive && x.Batch.Remaining > 0)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        return shotBatch;
    }

    public async Task<List<Batch>> GetAssignedBatches(Guid shotId)
    {
        var batches = await context
            .ShotBatches
            .Include(x => x.Batch)
            .Where(x => x.ShotId == shotId && x.Batch.IsActive)
            .Select(x => x.Batch)
            .ToListAsync();
        return batches;
    }

    #endregion

    #region Batch

    public async Task<IResult> UpsertBatch(Guid batchId, Guid shotId, UpsertBatchDto batch)
    {
        await using var transaction = await context.Database.BeginTransactionAsync();

        try
        {
            if (batchId == Guid.Empty)
            {
                var newBatch = new Batch()
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
                await context.Batches.AddAsync(newBatch);
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
                var batchInDb = await context.Batches.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == batchId);
                if (batchInDb is null)
                {
                    return await Result.FailAsync("Batch not found");
                }

                batchInDb.BatchNumber = batch.BatchNumber;
                batchInDb.IsActive = batch.IsActive;
                batchInDb.BatchCompleteWhenZero = batch.BatchCompleteWhenZero;
                batchInDb.BatchCount = batch.BatchCount;
                batchInDb.DrugId = batch.DrugId;
                batchInDb.ManfactureName = batch.ManfactureName;
                batchInDb.TradeName = batch.TradeName;
                batchInDb.Remaining = batch.Remaining;
                batchInDb.Expiry = batch.Expiry;
                context.ChangeTracker.Clear();
                context.Batches.Update(batchInDb);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();
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

    public async Task<IResult<UpsertBatchDto>> GetUpdateBatchDetail(Guid batchId)
    {
        var batchInDb = await context.Batches
            .Include(x => x.Drug)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == batchId);
        if (batchInDb is null)
        {
            return await Result<UpsertBatchDto>.FailAsync("Batch not found");
        }

        var data = mapper.Map<UpsertBatchDto>(batchInDb);
        return await Result<UpsertBatchDto>.SuccessAsync(data);
    }

    public async Task<IResult> DeleteBatch(Guid batchId)
    {
        var batchInDb = await context.Batches.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == batchId);
        if (batchInDb is null)
        {
            return await Result.FailAsync("Batch not found");
        }

        context.Batches.Remove(batchInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Batch has been removed.");
    }

    public async Task<IResult> DecreaseBatchQty(Guid batchId, int qty)
    {
        var batchInDb = await context.Batches.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == batchId);
        if (batchInDb is null)
        {
            return await Result.FailAsync("Batch not found");
        }

        batchInDb.Remaining -= qty;
        context.Batches.Update(batchInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync($"{qty} has been subtracted.");
    }

    public async Task<List<Batch>> GetBatches()
    {
        var list = await context.Batches.ToListAsync();
        return list;
    }

    #endregion

    #region Courses

    public async Task<List<Course>> GetCourses()
    {
        return await context.Courses.Where(x => x.IsActive).ToListAsync();
    }

    public async Task<CourseDto> GetCourse(Guid courseId)
    {
        var courseInDb = await context.Courses.FirstOrDefaultAsync(x => x.Id == courseId);
        var shots = await context.CourseShots
            .Where(x => x.CourseId == courseId)
            .Select(x => x.Shot)
            .ToListAsync();

        return new CourseDto()
        {
            Course = courseInDb,
            Shots = shots
        };
    }

    public async Task<IResult> SaveCourse(Guid courseId, Course course)
    {
        try
        {
            if (courseId == Guid.Empty)
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


    public async Task<IResult> AssignedShotToCourse(Guid courseId, List<Guid> shotIds)
    {
        await ClearShotList(courseId);
        var list = shotIds.Select((item, index) => new CourseShot()
                {CourseId = courseId, ShotId = item, Order = index + 1})
            .ToList();
        context.ChangeTracker.Clear();
        context.CourseShots.AddRange(list);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Shot(s) has been saved.");
    }

    private async Task ClearShotList(Guid courseId)
    {
        var cleanPreviousData =
            await context.CourseShots.AsNoTracking().Where(x => x.CourseId == courseId).ToListAsync();
        context.ChangeTracker.Clear();
        context.CourseShots.RemoveRange(cleanPreviousData);
        await context.SaveChangesAsync();
    }

    public async Task<List<Shot>> GetAssignedShotToCourse(Guid courseId)
    {
        return await context.CourseShots
            .Where(x => x.CourseId == courseId)
            .OrderBy(x => x.Order)
            .Select(x => x.Shot)
            .AsNoTracking()
            .ToListAsync();
    }


    public async Task<IResult> DeleteCourse(Guid id)
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

    public async Task<ImmunisationSetupDto> GetImmunisationProgram(Guid programId)
    {
        var immunisationProgram = await context.ImmunisationPrograms.FirstOrDefaultAsync(x => x.Id == programId);
        var courses = await context.ProgramCourses
            .Where(x => x.ImmunisationProgramId == programId)
            .Select(x => x.Course)
            .ToListAsync();

        return new ImmunisationSetupDto()
        {
            ImmunisationProgram = immunisationProgram,
            Courses = courses
        };
    }

    public async Task<IResult> SaveImmunisationProgram(Guid setupId, ImmunisationProgram program)
    {
        try
        {
            if (setupId == Guid.Empty)
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

    public async Task<IResult> AssignedCourseToSchedule(Guid programId, List<Guid> courseIds)
    {
        await ClearCourseList(programId);
        var list = courseIds.Select((item, index) => new ProgramCourse()
                {ImmunisationProgramId = programId, CourseId = item, Order = index + 1})
            .ToList();
        context.ChangeTracker.Clear();
        context.ProgramCourses.AddRange(list);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Course(s) has been saved.");
    }


    public async Task<List<Course>> GetAssignedCoursesOfProgram(Guid programId)
    {
        return await context.ProgramCourses
            .Where(x => x.ImmunisationProgramId == programId)
            .OrderBy(x => x.Order)
            .Select(x => x.Course)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IResult> DeleteImmunisationProgram(Guid id)
    {
        var courseInDb = await context.ImmunisationPrograms.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        context.ImmunisationPrograms.Remove(courseInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Immunisation Setup has been deleted.");
    }

    private async Task ClearCourseList(Guid programId)
    {
        var cleanPreviousData =
            await context.ProgramCourses.AsNoTracking().Where(x => x.ImmunisationProgramId == programId)
                .ToListAsync();
        context.ChangeTracker.Clear();
        context.ProgramCourses.RemoveRange(cleanPreviousData);
        await context.SaveChangesAsync();
    }

    #endregion

    #endregion

    #region Investigation

    public async Task<List<InvestigationDto>> GetInvestigations()
    {
        var templates = await context.Investigations
            .AsNoTracking()
            .Where(x => x.IsActive).ToListAsync();
        var data = mapper.Map<List<InvestigationDto>>(templates);
        return data;
    }

    public async Task<IResult> SaveInvestigation(InvestigationDto request)
    {
        if (request.Id == Guid.Empty)
        {
            var investigationTemplate = new Investigation()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                IsActive = request.IsActive
            };
            context.Investigations.Add(investigationTemplate);
        }
        else
        {
            var investigationInDb = await context
                .Investigations
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (investigationInDb == null)
                return await Result.FailAsync("Investigation Template not found.");


            investigationInDb.Name = request.Name;
            investigationInDb.IsActive = request.IsActive;
            context.ChangeTracker.Clear();
            context.Investigations.Update(investigationInDb);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Investigation Template has been saved.");
    }

    public async Task<IResult> DeleteInvestigation(Guid id)
    {
        var investigationInDb = await context
            .Investigations
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (investigationInDb == null)
            return await Result.FailAsync("Investigation Template not found.");

        context.Investigations.Remove(investigationInDb);
        await context.SaveChangesAsync();

        return await Result.SuccessAsync("Investigation Template has been deleted.");
    }

    public async Task<List<InvestigationDetailDto>> GetInvestigationDetails(Guid investigationId)
    {
        var details = await context.InvestigationDetails
            .AsNoTracking()
            .Where(x => x.IsActive && x.InvestigationId == investigationId)
            .ToListAsync();
        var mapped = mapper.Map<List<InvestigationDetailDto>>(details);
        return mapped;
    }

    public async Task<IResult> SaveInvestigationDetail(InvestigationDetailDto request)
    {
        try
        {
            if (request.Id == Guid.Empty)
            {
                var details = new InvestigationDetail()
                {
                    Id = Guid.NewGuid(),
                    InvestigationId = request.InvestigationId,
                    Name = request.Name,
                    IsActive = request.IsActive,
                    Description = request.Description,
                    IsMaindatory = request.IsMaindatory,
                    AbsoluteMinimum = request.AbsoluteMinimum,
                    AbsoluteMaximum = request.AbsoluteMaximum,
                    NormalMinimum = request.NormalMinimum,
                    NormalMaximum = request.NormalMaximum,
                    FieldType = request.FieldType,
                };
                if (request.InvestigationSelectionListId != Guid.Empty)
                {
                    details.InvestigationSelectionListId = request.InvestigationSelectionListId;
                }

                await context.InvestigationDetails.AddAsync(details);
            }
            else
            {
                var investigationDetailInDb = await context
                    .InvestigationDetails
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (investigationDetailInDb == null)
                    return await Result.FailAsync("Investigation Details not found.");

                investigationDetailInDb.InvestigationId = request.InvestigationId;
                investigationDetailInDb.Name = request.Name;
                investigationDetailInDb.IsActive = request.IsActive;
                investigationDetailInDb.Description = request.Description;
                investigationDetailInDb.IsMaindatory = request.IsMaindatory;
                investigationDetailInDb.AbsoluteMinimum = request.AbsoluteMinimum;
                investigationDetailInDb.AbsoluteMaximum = request.AbsoluteMaximum;
                investigationDetailInDb.NormalMinimum = request.NormalMinimum;
                investigationDetailInDb.NormalMaximum = request.NormalMaximum;
                investigationDetailInDb.FieldType = request.FieldType;
                if (request.InvestigationSelectionListId != Guid.Empty)
                {
                    investigationDetailInDb.InvestigationSelectionListId = request.InvestigationSelectionListId;
                }

                context.ChangeTracker.Clear();
                context.InvestigationDetails.Update(investigationDetailInDb);
            }

            await context.SaveChangesAsync();
            return await Result.SuccessAsync("Investigation details has been saved.");
        }
        catch (Exception e)
        {
            return await Result.FailAsync(e.Message);
        }
    }

    public async Task<IResult> DeleteInvestigationDetails(Guid id)
    {
        var investigationDetailInDb = await context
            .InvestigationDetails
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (investigationDetailInDb == null)
            return await Result.FailAsync("Investigation Details not found.");
        context.ChangeTracker.Clear();
        context.InvestigationDetails.Remove(investigationDetailInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Investigation details has been deleted.");
    }

    public async Task<List<InvestigationSelectionList>> GetInvestigationSelectionList()
    {
        return await context.InvestigationSelectionList.ToListAsync();
    }

    public async Task<IResult> SaveInvestigationSelectionList(InvestigationSelectionList request)
    {
        if (request.Id == Guid.Empty)
        {
            var newInvestigationSelectionList = new InvestigationSelectionList()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
            };
            await context.InvestigationSelectionList.AddAsync(newInvestigationSelectionList);
        }
        else
        {
            var listInDb = await context.InvestigationSelectionList
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (listInDb == null) return await Result.FailAsync("Investigation Selection List not found.");
            listInDb.Name = request.Name;

            context.ChangeTracker.Clear();
            context.InvestigationSelectionList.Update(listInDb);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Investigation Selection List has been saved.");
    }

    public async Task<IResult> DeleteInvestigationSelectionList(Guid id)
    {
        var listInDb = await context
            .InvestigationSelectionList
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (listInDb == null) return await Result.FailAsync("Investigation Selection List not found.");

        context.InvestigationSelectionList.Remove(listInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Investigation Selection List has been removed.");
    }

    public async Task<List<InvestigationSelectionValue>> GetInvestigationSelectionValues(Guid selectionId)
    {
        return await context.InvestigationSelectionValues
            .Where(x => x.InvestigationSelectionListId == selectionId)
            .ToListAsync();
    }

    public async Task<IResult> SaveInvestigationSelectionListValue(InvestigationSelectionValue request)
    {
        if (request.Id == Guid.Empty)
        {
            request.Id = Guid.NewGuid();
            request.InvestigationSelectionListId = request.InvestigationSelectionListId;
            await context.InvestigationSelectionValues.AddAsync(request);
        }
        else
        {
            var listInDb = await context.InvestigationSelectionValues.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            listInDb.Value = request.Value;
            listInDb.InvestigationSelectionListId = request.InvestigationSelectionListId;
            context.ChangeTracker.Clear();
            context.InvestigationSelectionValues.Update(listInDb);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Investigation Selection Value has been saved.");
    }

    public async Task<IResult> DeleteInvestigationSelectionListValue(Guid id)
    {
        var listInDb = await context
            .InvestigationSelectionValues
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (listInDb == null) return await Result.FailAsync("Investigation Selection Value not found.");

        context.InvestigationSelectionValues.Remove(listInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Investigation Selection Value has been removed.");
    }

    public async Task<List<InvestigationGroup>> GetInvestigationGroups()
    {
        return await context.InvestigationGroups.AsNoTracking().Where(x => x.IsActive).ToListAsync();
    }

    public async Task<IResult> SaveInvestigationGroup(InvestigationGroup request)
    {
        if (request.Id == Guid.Empty)
        {
            var newInvestigationGroup = new InvestigationGroup()
            {
                Id = Guid.NewGuid(),
                Icon = request.Icon,
                Name = request.Name,
                IsActive = request.IsActive
            };
            await context.InvestigationGroups.AddAsync(newInvestigationGroup);
        }
        else
        {
            var groupInDb = await context.InvestigationGroups.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (groupInDb == null) return await Result.FailAsync("Investigation Group not found.");

            groupInDb.Name = request.Name;
            groupInDb.Icon = request.Icon;
            groupInDb.IsActive = request.IsActive;
            context.ChangeTracker.Clear();
            context.InvestigationGroups.Update(groupInDb);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Investigation Group has been saved.");
    }

    public async Task<IResult> DeleteInvestigationGroup(Guid id)
    {
        var groupInDb = await context.InvestigationGroups.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        if (groupInDb == null) return await Result.FailAsync("Investigation Group not found.");

        context.InvestigationGroups.Remove(groupInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Investigation Group has been removed.");
    }

    public async Task<IResult> AssignInvestigationsToGroup(Guid groupId, Guid investigationId)
    {
        var isExists = await context.AssignedInvestigationsGroup.AsNoTracking().AnyAsync(x =>
            x.InvestigationGroupId == groupId && x.InvestigationId == investigationId);

        if (!isExists)
        {
            var newAssignGroup = new AssignedInvestigationGroup()
            {
                Id = Guid.NewGuid(),
                InvestigationGroupId = groupId,
                InvestigationId = investigationId
            };
            await context.AssignedInvestigationsGroup.AddAsync(newAssignGroup);
        }

        await context.SaveChangesAsync();
        context.ChangeTracker.Clear();
        return await Result.SuccessAsync("Assigned Investigations Group has been assigned.");
    }

    public async Task<List<AssignedInvestigationGroup>> GetAssignInvestigationsOfGroup(Guid groupId)
    {
        return await context.AssignedInvestigationsGroup
            .AsNoTracking()
            .Include(x => x.InvestigationGroup)
            .Where(x => x.InvestigationGroupId == groupId)
            .ToListAsync();
    }

    public async Task<IResult> DeleteAssignedInvestigationGroup(Guid id)
    {
        var assignInDb = await context.AssignedInvestigationsGroup.FirstOrDefaultAsync(x => x.Id == id);
        if (assignInDb == null) return await Result.FailAsync("Assigned Investigation Group not found.");

        context.AssignedInvestigationsGroup.Remove(assignInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Assigned Investigation Group has been removed.");
    }

    #endregion

    #region Letter

    public async Task<List<LetterType>> GetLetterTypes()
    {
        return await context.LetterTypes.AsNoTracking().ToListAsync();
    }

    public async Task<IResult> SaveLetterType(Guid id, LetterType letterType)
    {
        if (id == Guid.Empty)
        {
            await context.LetterTypes.AddAsync(letterType);
        }
        else
        {
            var letterInDb = await context.LetterTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == letterType.Id);
            if (letterInDb == null) return await Result.FailAsync("Letter Type not found.");

            letterInDb.Name = letterType.Name;
            context.LetterTypes.Update(letterInDb);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Letter Type has been saved.");
    }

    public async Task<IResult> DeleteLetterType(Guid id)
    {
        var letterInDb = await context.LetterTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (letterInDb == null) return await Result.FailAsync("Letter Type not found.");

        context.LetterTypes.Remove(letterInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Letter Type has been deleted.");
    }

    public async Task<LetterType> GetLetterType(Guid id)
    {
        var letterInDb = await context.LetterTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return letterInDb ?? new LetterType();
    }

    public async Task<List<LetterTemplate>> GetLetterTemplates()
    {
        return await context.LetterTemplates
            .Include(x => x.LetterType)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<string> GetLetterTemplateFile(Guid letterTemplateId)
    {
        var templateInDb = await context.LetterTemplates.FirstOrDefaultAsync(x => x.Id == letterTemplateId);
        return templateInDb != null ? templateInDb.TemplateFile : "";
    }

    public async Task<List<LetterTemplate>> GetLetterTemplatesByType(Guid typeId)
    {
        return await context.LetterTemplates
            .Include(x => x.LetterType)
            .AsNoTracking()
            .Where(x => x.LetterType.Id == typeId)
            .ToListAsync();
    }

    public async Task<IResult> SaveLetterTemplate(Guid id, LetterTemplateDto request)
    {
        var letterTemplate = mapper.Map<LetterTemplate>(request);
        if (id == Guid.Empty)
        {
            await context.LetterTemplates.AddAsync(letterTemplate);
        }
        else
        {
            var letterInDb = await context.LetterTemplates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (letterInDb == null) return await Result.FailAsync("Letter Template not found.");

            letterInDb.Name = request.Name;
            letterInDb.LetterTypeId = request.LetterTypeId;
            letterInDb.IsActive = request.IsActive;
            letterInDb.TemplateFile = request.TemplateFile;
            context.ChangeTracker.Clear();
            context.LetterTemplates.Update(letterInDb);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Letter Type has been saved.");
    }

    public async Task<IResult> DeleteLetterTemplate(Guid id)
    {
        var letterInDb = await context.LetterTemplates
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (letterInDb == null) return await Result.FailAsync("Letter Template not found.");

        context.LetterTemplates.Remove(letterInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Letter Template has been deleted.");
    }

    #endregion

    #region Sketch categories

    public async Task<List<SketchCategory>> GetSketchCategories()
    {
        return await context.SketchCategories
            .Include(x => x.Sketches)
            .AsNoTracking().ToListAsync();
    }

    public async Task<List<Sketch>> GetSketcheByCategory(Guid categoryId)
    {
        return await context.Sketches
            .Where(x => x.SketchCategoryId == categoryId)
            .AsNoTracking().ToListAsync();
    }

    public async Task<IResult> SaveSketch(Guid id, Sketch request)
    {
        if (id == Guid.Empty)
        {
            await context.Sketches.AddAsync(request);
        }
        else
        {
            var sketchInDb = await context.Sketches
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (sketchInDb is null)
                return await Result.FailAsync("Sketch not found.");

            sketchInDb.IsActive = request.IsActive;
            sketchInDb.Name = request.Name;
            sketchInDb.SketchCategoryId = request.SketchCategoryId;
            sketchInDb.Description = request.Description;
            sketchInDb.Image = request.Image;
            context.ChangeTracker.Clear();
            context.Sketches.Update(sketchInDb);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Sketch has been saved.");
    }

    public async Task<IResult> DeleteSketch(Guid id)
    {
        var sketchInDb = await context.Sketches
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (sketchInDb is null)
            return await Result.FailAsync("Sketch not found.");

        context.Sketches.Remove(sketchInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Sketch has been deleted.");
    }


    public async Task<List<CustomForm>> GetCustomForms()
    {
        return await context.CustomForms
            .Where(x => x.IsActive)
            .ToListAsync();
    }

    public async Task<IResult> SaveCustomForm(Guid id, CustomForm request)
    {
        if (id == Guid.Empty)
        {
            await context.CustomForms.AddAsync(request);
        }
        else
        {
            var customForm = await context.CustomForms
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (customForm is null)
                return await Result.FailAsync("Form not found.");

            customForm.IsActive = request.IsActive;
            customForm.Name = request.Name;
            customForm.Type = request.Type;
            customForm.Description = request.Description;
            context.ChangeTracker.Clear();
            context.CustomForms.Update(customForm);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Form has been saved.");
    }

    public async Task<List<CustomFormTemplate>> GetCustomFormTemplates(Guid customFormId)
    {
        return await context.FormTemplates
            .Where(x => x.CustomFormId == customFormId)
            .ToListAsync();
    }

    public async Task<CustomFormTemplate> GetCustomFormTemplate(Guid templateId)
    {
        return await context.FormTemplates.FirstOrDefaultAsync(x => x.Id == templateId);
    }

    public async Task<IResult> SaveFormTemplate(Guid id, CustomFormTemplate request)
    {
        if (id == Guid.Empty)
        {
            var newTemplate = new CustomFormTemplate()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                CustomFormId = request.CustomFormId,
                Description = request.Description,
            };
            await context.FormTemplates.AddAsync(newTemplate);
        }
        else
        {
            var formTemplate = await context.FormTemplates
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (formTemplate is null)
                return await Result.FailAsync("Form not found.");

            formTemplate.Description = request.Description;
            context.ChangeTracker.Clear();
            context.FormTemplates.Update(formTemplate);
        }

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Form has been saved.");
    }

    public async Task<IResult> CopyFormTemplate(Guid id)
    {
        var formTemplate = await context.FormTemplates
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (formTemplate is null)
            return await Result.FailAsync("Form Template not found.");

        var newTemplate = new CustomFormTemplate()
        {
            Id = Guid.NewGuid(),
            Created = DateTime.Now,
            CustomFormId = formTemplate.CustomFormId,
            Description = formTemplate.Description,
        };
        await context.FormTemplates.AddAsync(newTemplate);

        await context.SaveChangesAsync();
        return await Result.SuccessAsync("New Copy has been saved.");
    }

    public async Task<IResult> DeleteFormTemplate(Guid id)
    {
        var formTemplate = await context.FormTemplates
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (formTemplate is null)
            return await Result.FailAsync("Form Template not found.");

        context.FormTemplates.Remove(formTemplate);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Form Template has been deleted.");
    }

    #endregion

    #region Dms Category

    public async Task<List<DocumentCategory>> GetAllCategoriesWithHierarchy()
    {
        return await context.DocumentCategories
            .Include(c => c.SubCategories)
            .Where(c => c.ParentCategoryId == null) // Start from root categories
            .ToListAsync();
    }

    public async Task<IResult> SaveDmsCategory(string name, int? parentCategoryId = null)
    {
        var newCategory = new DocumentCategory
        {
            Name = name,
            ParentCategoryId = parentCategoryId,
        };

        await context.DocumentCategories.AddAsync(newCategory);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("DMS category has been saved.");
    }

    public async Task<IResult> DeleteDmsCategory(int id)
    {
        var documentCategory = await context.DocumentCategories
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (documentCategory is null)
            return await Result.FailAsync("Document not found.");

        context.ChangeTracker.Clear();
        context.DocumentCategories.Remove(documentCategory);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Document has been deleted.");
    }

    #endregion
}