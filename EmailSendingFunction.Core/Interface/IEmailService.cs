using System.Threading.Tasks;
using EmailSendingFunction.Core.Model;

namespace EmailSendingFunction.Core.Interface
{
    public interface IEmailService
    {
        Task SendEmail(EmailModel emailModel);
    }
}