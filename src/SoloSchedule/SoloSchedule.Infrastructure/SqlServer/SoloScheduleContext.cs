using Microsoft.EntityFrameworkCore;

namespace SoloSchedule.Infrastructure.SqlServer
{
    /// <summary>
    /// SoloSchedule コンテキスト
    /// </summary>
    public class SoloScheduleContext : DbContext
    {
        /// <summary>SoloScheduleContext
        /// SoloScheduleContext
        /// </summary>
        /// <param name="options">options</param>
        public SoloScheduleContext(DbContextOptions<SoloScheduleContext> options)
            : base(options) { }
    }
}
