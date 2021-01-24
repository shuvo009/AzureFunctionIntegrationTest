using EmailSendingFunction.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace EmailSendingFunction.Repository.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<EmailModel> EmailLogs { get; set; }
    }
}