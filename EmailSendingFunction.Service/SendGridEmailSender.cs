using System.Threading.Tasks;
using EmailSendingFunction.Core.Interface;
using EmailSendingFunction.Core.Model;

namespace EmailSendingFunction.Service
{
    public class SendGridEmailSender : IEmailSender
    {
        public Task Send(EmailModel emailModel)
        {
            //Send Email using Send Grid
            return Task.FromResult(0);
        }
    }
}