using Domain.Entities.Common;

namespace Services.Features.Admin.Interfaces;

public interface IAppService
{
    Task<List<AppModule>> GetAppNavigations(Guid parentId=default);
    Task<List<AppModule>> GetAppModules();
}