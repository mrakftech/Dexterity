using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
