namespace ClickBusAPIIntegration.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using ClickBusAPIIntegration.Commands.Tests;
    using MediatR;

    public class TestePollyCommandHandler : IRequestHandler<TestePollyCommad, TestePollyEvent>
    {
        public Task<TestePollyEvent> Handle(TestePollyCommad request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new TestePollyEvent(request.EndPoint, request.MaxRetryAttempts, request.PauseBetweenFailures));
        }
      
    }
}
