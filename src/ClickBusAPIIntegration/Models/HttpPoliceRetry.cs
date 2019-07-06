namespace ClickBusAPIIntegration.Models
{
    using System;

    public class HttpPoliceRetry
    {
        public int MaxRetryAttempts { get; set; }
        public TimeSpan PauseBetweenFailures { get; set; }
    }
}
