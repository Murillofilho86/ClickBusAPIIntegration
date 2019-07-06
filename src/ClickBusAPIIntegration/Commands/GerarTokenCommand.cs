namespace ClickBusAPIIntegration.Commands
{
    using ClickBusAPIIntegration.Models;
    using MediatR;

    public class GerarTokenCommand : IRequest<JWT>
    {
        public HttpAPI Http { get; set; }
    }
}
