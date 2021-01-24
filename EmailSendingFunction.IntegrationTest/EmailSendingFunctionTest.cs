using System;
using System.Linq;
using System.Threading.Tasks;
using EmailSendingFunction.Core.Model;
using EmailSendingFunction.IntegrationTest.Setup;
using EmailSendingFunction.Repository.Context;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace EmailSendingFunction.IntegrationTest
{
    public class EmailSendingFunctionTest : TestBase
    {
        [Fact]
        public async Task Send_Email()
        {
            var email = new EmailModel { Body = "Test Body", Recipient = "test@test.com", Subject = "Test Subject" };
            var jsonData = JsonConvert.SerializeObject(email);
            var host = HostSetup();

            var emailSendFunction = host.Services.GetService<EmailSendingFunction>();
            await emailSendFunction.SendEmail(jsonData, GetLogger());

            var dbContext = host.Services.GetService<DatabaseContext>();
            Assert.Equal(1, dbContext.EmailLogs.Count());

            emailSenderMock.Verify(s=>s.Send(It.IsAny<EmailModel>()), Times.Once);
        }
    }
}
