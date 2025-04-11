using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Database
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var conBuilder = new ConfigurationBuilder();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            IConfiguration configuration = conBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
            builder.UseSqlServer(configuration["ConnectionStrings:AppConnection"] ?? string.Empty);
            return new ApplicationDbContext(builder.Options);
        }
    }
}
