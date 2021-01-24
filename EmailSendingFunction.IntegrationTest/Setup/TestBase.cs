using EmailSendingFunction.Core.Interface;
using EmailSendingFunction.Implementations;
using EmailSendingFunction.Repository;
using EmailSendingFunction.Repository.Context;
using EmailSendingFunction.Service;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;

namespace EmailSendingFunction.IntegrationTest.Setup
{
    public abstract class TestBase
    {
        protected readonly Mock<IEmailSender> emailSenderMock = new Mock<IEmailSender>();

        internal IHost HostSetup()
        {
            var builder = new HostBuilder();
            builder.ConfigureServices((context, services) =>
            {
                RegisterDependencies(services);

                services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("TestDatabase"));
            });

            var host = builder.Build();
            return host;
        }

        internal ILogger<TestBase> GetLogger()
        {
            var moqLogger = new Mock<ILogger<TestBase>>();
            return moqLogger.Object;
        }

        #region Supported Methods

        private void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<EmailSendingFunction, EmailSendingFunction>();
            services.AddSingleton<IJobActivator>(new WebJobActivator(services.BuildServiceProvider()));


            services.AddTransient(s => emailSenderMock.Object);
            services.AddTransient<IEmailLogRepository, EmailLogRepository>();
            services.AddTransient<IEmailService, EmailService>();
        }

        #endregion
    }
}