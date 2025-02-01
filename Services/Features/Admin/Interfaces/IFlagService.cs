using Domain.Entities.Common;
using Services.Features.Admin.Dtos.FlagRecords;
using Shared.Wrapper;

namespace Services.Features.Admin.Interfaces;

public interface IFlagService
{
    Task<IResult<List<GetFlagRecordDto>>> GetFlagRecords(string status=null);
    Task<IResult> FlagRecord(FlagRecordDto flagRecordRecord);
    Task<IResult> ReassignedRecord(Guid id, ResolvedRecordDto request);
}