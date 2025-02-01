using AutoMapper;
using Database;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Services.Features.Admin.Dtos.FlagRecords;
using Services.Features.Admin.Interfaces;
using Services.State;
using Shared.Constants.Module.Common;
using Shared.Wrapper;

namespace Services.Features.Admin.Service;

public class FlagService(ApplicationDbContext context, IMapper mapper) : IFlagService
{
    public async Task<IResult<List<GetFlagRecordDto>>> GetFlagRecords(string status = nameof(FlagRecordStatus.Flagged))
    {
        var flags = await context.FlagRecords.Include(x => x.FlaggedBy).Include(x => x.ResolvedBy)
            .Where(x => x.Status == status).ToListAsync();
        var mapped = mapper.Map<List<GetFlagRecordDto>>(flags);
        return await Result<List<GetFlagRecordDto>>.SuccessAsync(mapped);
    }

    public async Task<IResult> FlagRecord(FlagRecordDto flagRecordRecord)
    {
        try
        {
            var newFlagRecord = new FlagRecord()
            {
                Id = Guid.NewGuid(),
                RecordId = flagRecordRecord.RecordId,
                Reason = flagRecordRecord.Reason,
                CreatedDate = DateTime.UtcNow,
                CurrentPatientId = ApplicationState.SelectedPatient.PatientId,
                FlaggedById = ApplicationState.Auth.CurrentUser.UserId,
                Status = nameof(FlagRecordStatus.Flagged),
                ModuleName = flagRecordRecord.ModuleName,
                Description = flagRecordRecord.Description,
            };
            context.FlagRecords.Add(newFlagRecord);
            await context.SaveChangesAsync();
            return await Result.SuccessAsync("Flag Record saved successfully");
        }
        catch (Exception e)
        {
            return await Result.FailAsync(e.Message);
        }
    }

    public async Task<IResult> ReassignedRecord(Guid id, ResolvedRecordDto request)
    {
        try
        {
            var flagRecordToUpdate = await context.FlagRecords.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (flagRecordToUpdate is {Status: nameof(FlagRecordStatus.Flagged)})
            {
                //RecordId : Fetch particular record from particular module and 
                if (flagRecordToUpdate.ModuleName == FlagRecordConstant.Module.ConsultationDetail)
                {
                    var consultationDetail =
                        context.ConsultationDetails.AsNoTracking()
                            .FirstOrDefault(x => x.Id == flagRecordToUpdate.RecordId);
                    consultationDetail.PatientId = request.ReassignedId;
                    context.ConsultationDetails.Update(consultationDetail);
                }
                else if (flagRecordToUpdate.ModuleName == FlagRecordConstant.Module.Notes)
                {
                    var noteInDb =
                        context.ConsultationNotes.AsNoTracking()
                            .FirstOrDefault(x => x.Id == flagRecordToUpdate.RecordId);
                    noteInDb.PatientId = request.ReassignedId;
                    context.ConsultationNotes.Update(noteInDb);
                }

                flagRecordToUpdate.Status = nameof(FlagRecordStatus.Resolved);
                flagRecordToUpdate.ModifiedDate = DateTime.UtcNow;
                flagRecordToUpdate.ResolvedById = ApplicationState.Auth.CurrentUser.UserId;
                flagRecordToUpdate.ReassignedToPatientId = request.ReassignedId;
                context.FlagRecords.Update(flagRecordToUpdate);
                await context.SaveChangesAsync();
            }

            return await Result.SuccessAsync("Flag Record saved successfully");
        }
        catch (Exception e)
        {
            return await Result.FailAsync(e.Message);
        }
    }
}