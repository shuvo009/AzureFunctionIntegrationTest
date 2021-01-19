using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace EmailSendingFunction
{
    public static class EmailSendingFunction
    {
        [FunctionName("SendEmail")]
        public static void Run([ServiceBusTrigger("emailsendqueue", Connection = "")]
            string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}