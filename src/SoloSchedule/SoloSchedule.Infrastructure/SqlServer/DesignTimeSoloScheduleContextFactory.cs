using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace SoloSchedule.Infrastructure.SqlServer
{
    /// <summary>
    /// DesignTimeSoloScheduleContextFactory
    /// </summary>
    public class DesignTimeSoloScheduleContextFactory : IDesignTimeDbContextFactory<SoloScheduleContext>
    {
        /// <summary>
        /// CreateDbContext
        /// </summary>
        /// <param name="args">args</param>
        /// <returns>SoloScheduleContext</returns>
        public SoloScheduleContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SoloScheduleContext>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets(Assembly.GetExecutingAssembly())
                .Build();

            var cnnBuilder = new SqlConnectionStringBuilder(configuration.GetConnectionString("SoloSchedule"))
            {
                Password = configuration["DbPassword"],
            };
            var connection = cnnBuilder.ConnectionString;

            optionsBuilder.UseSqlServer(connection);

            return new SoloScheduleContext(optionsBuilder.Options);
        }
    }
}
