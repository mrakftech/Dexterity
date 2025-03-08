using Database;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Services.Features.Admin.Interfaces;

namespace Services.Features.Admin.Service;

public class AppService(ApplicationDbContext context) : IAppService
{
    public async Task<List<AppModule>> GetAppNavigations(Guid parentId)
    {
        if (parentId == Guid.Empty)
        {
            return await context.AppModules.Where(x => x.ParentId == null).OrderBy(x => x.Order).ToListAsync();
        }

        return await context.AppModules.Where(x => x.ParentId == parentId).OrderBy(x => x.Order).ToListAsync();
    }

    public async Task<List<AppModule>> GetAppModules()
    {
        return await context.AppModules.OrderBy(x => x.Order).ToListAsync();
    }
}