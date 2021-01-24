using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;

namespace EmailSendingFunction.IntegrationTest.Setup
{
    public abstract class TestBase
    {
        internal static string DatabaseName = "ReportTestDatabase";

        internal IHost HostSetup()
        {
            var builder = new HostBuilder();
            builder.ConfigureServices((context, services) => { RegisterDependencies(services); });
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
        }

        #endregion
    }
}