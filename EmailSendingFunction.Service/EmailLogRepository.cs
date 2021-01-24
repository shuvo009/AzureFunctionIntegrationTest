using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmailSendingFunction.Core.Interface;
using EmailSendingFunction.Core.Model;

namespace EmailSendingFunction.Service
{
    public class EmailLogRepository : IEmailLogRepository
    {


        public Task Log(EmailModel emailModel)
        {
            
        }
    }
}
