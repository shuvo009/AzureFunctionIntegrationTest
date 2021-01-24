using EmailSendingFunction;
using EmailSendingFunction.Core.Interface;
using EmailSendingFunction.Implementations;
using EmailSendingFunction.Repository;
using EmailSendingFunction.Repository.Context;
using EmailSendingFunction.Service;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.EntityFrameworkCore;
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
            var executionContextOptions = builder.Services.BuildServiceProvider()
                .GetService<IOptions<ExecutionContextOptions>>().Value;

            var configuration = new ConfigurationBuilder()
                .SetBasePath(executionContextOptions.AppDirectory)
                .AddJsonFile("local.settings.json", true)
                .AddEnvironmentVariables().Build();

            RegisterDependency(builder.Services);

            builder.Services.AddDbContext<DatabaseContext>(
                options => options.UseSqlServer(configuration["connectionString"]));
        }

        private void RegisterDependency(IServiceCollection services)
        {
            services.AddTransient<EmailSendingFunction, EmailSendingFunction>();
            services.AddSingleton<IJobActivator>(new WebJobActivator(services.BuildServiceProvider()));

            services.AddTransient<IEmailSender, SendGridEmailSender>();
            services.AddTransient<IEmailLogRepository, EmailLogRepository>();
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}