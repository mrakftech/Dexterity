using Domain.Entities.Common;

namespace Services.Features.Admin.Interfaces;

public interface IAppService
{
    Task<List<AppModule>> GetAppNavigations();
    Task<List<AppModule>> GetAppModules();
}