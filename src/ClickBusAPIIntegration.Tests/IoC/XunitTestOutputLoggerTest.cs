namespace ClickBusAPIIntegration.Tests.IoC
{
    using Microsoft.Extensions.Logging;
    using Xunit;

    public class XunitTestOutputLoggerTest
    {
        private readonly ILogger<XunitTestOutputLoggerTest> _logger;

        [Fact]
        public void Test()
        {
            _logger.LogDebug("LogDebug");
            _logger.LogInformation("LogInformation");
            _logger.LogError("LogError");
        }
    }
}
