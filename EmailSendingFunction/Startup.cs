using EmailSendingFunction;
using EmailSendingFunction.Core.Interface;
using EmailSendingFunction.Service;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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
        }
    }
}