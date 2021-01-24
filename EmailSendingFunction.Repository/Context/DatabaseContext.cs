using EmailSendingFunction.Core.DbModel;
using Microsoft.EntityFrameworkCore;

namespace EmailSendingFunction.Repository.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<EmailLogModel> EmailLogs { get; set; }
    }
}