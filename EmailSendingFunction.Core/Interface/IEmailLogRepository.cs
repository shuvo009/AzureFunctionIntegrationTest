using System.Threading.Tasks;
using EmailSendingFunction.Core.DbModel;
using EmailSendingFunction.Core.Model;

namespace EmailSendingFunction.Core.Interface
{
    public interface IEmailLogRepository
    {
        Task Log(EmailModel emailModel);
    }
}