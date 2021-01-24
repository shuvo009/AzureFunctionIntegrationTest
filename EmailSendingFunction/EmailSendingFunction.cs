using System;
using System.Threading.Tasks;
using EmailSendingFunction.Core.Interface;
using EmailSendingFunction.Core.Model;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EmailSendingFunction
{
    public class EmailSendingFunction
    {
        private readonly IEmailService _emailService;

        public EmailSendingFunction(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [FunctionName("SendEmail")]
        public async Task SendEmail([ServiceBusTrigger("emailsendqueue", Connection = "MessageQueueSetting:ConnectionString")]
            string message, ILogger log)
        {
            log.LogInformation($"ServiceBus queue trigger function processed message: {message}");
            try
            {
                var emailModel = JsonConvert.DeserializeObject<EmailModel>(message);
                await _emailService.SendEmail(emailModel);
            }
            catch (Exception e)
            {
                log.LogError(0, e.Message, e);
            }
        }
    }
}