namespace ClickBusAPIIntegration.Commands.Tests
{
    using MediatR;
    using System;

    public class TestePollyCommad : IRequest<TestePollyEvent>
    {
        public string EndPoint { get; set; }
        public int MaxRetryAttempts { get; set; } = 3;
        public TimeSpan PauseBetweenFailures { get; set; } = TimeSpan.FromSeconds(2);
    }
}
