using EmailSendingFunction;
using EmailSendingFunction.Core.Interface;
using EmailSendingFunction.Repository;
using EmailSendingFunction.Service;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace EmailSendingFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            RegisterDependency(builder.Services);
        }

        private void RegisterDependency(IServiceCollection services)
        {
            services.AddTransient<IEmailSender, SendGridEmailSender>();
            services.AddTransient<IEmailLogRepository, EmailLogRepository>();
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}