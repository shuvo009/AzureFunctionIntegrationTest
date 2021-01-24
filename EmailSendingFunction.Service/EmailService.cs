using System.Threading.Tasks;
using EmailSendingFunction.Core.Interface;
using EmailSendingFunction.Core.Model;

namespace EmailSendingFunction.Service
{
    public class EmailService : IEmailService
    {
        private readonly IEmailLogRepository _emailLogRepository;
        private readonly IEmailSender _emailSender;

        public EmailService(IEmailLogRepository emailLogRepository, IEmailSender emailSender)
        {
            _emailLogRepository = emailLogRepository;
            _emailSender = emailSender;
        }

        public async Task SendEmail(EmailModel emailModel)
        {
            await _emailSender.Send(emailModel);
            await _emailLogRepository.Log(emailModel);
        }
    }
}