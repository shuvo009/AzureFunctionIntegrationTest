using System.Threading.Tasks;
using EmailSendingFunction.Core.Model;

namespace EmailSendingFunction.Core.Interface
{
    public interface IEmailSender
    {
        Task Send(EmailModel emailModel);
    }
}