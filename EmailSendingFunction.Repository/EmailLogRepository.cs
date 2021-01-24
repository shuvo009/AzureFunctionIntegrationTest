using System.Threading.Tasks;
using EmailSendingFunction.Core.DbModel;
using EmailSendingFunction.Core.Interface;
using EmailSendingFunction.Core.Model;
using EmailSendingFunction.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace EmailSendingFunction.Repository
{
    public class EmailLogRepository : IEmailLogRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly DbSet<EmailLogModel> _emailModels;

        public EmailLogRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _emailModels = _databaseContext.Set<EmailLogModel>();
        }

        public async Task Log(EmailModel emailModel)
        {
            var log = new EmailLogModel
            {
                Boy = emailModel.Body,
                Recipient = emailModel.Recipient,
                Subject = emailModel.Subject
            };

            await _emailModels.AddAsync(log);
            await _databaseContext.SaveChangesAsync();
        }
    }
}