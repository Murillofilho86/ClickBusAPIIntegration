namespace ClickBusAPIIntegration.Commands.Tests
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class TestePollyEvent : IRequestHandler<TestePollyCommad, TestePollyEvent>
    {
        public Task<TestePollyEvent> Handle(TestePollyCommad request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new TestePollyEvent(request.EndPoint, request.MaxRetryAttempts, request.PauseBetweenFailures));
        }
    }
}
