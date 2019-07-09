namespace ClickBusAPIIntegration.Commands.Tests
{
    using MediatR;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public class GenericPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly TextWriter _writer;

        public GenericPipelineBehavior(TextWriter writer)
        {
            _writer = writer;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            await _writer.WriteLineAsync("-- Solicitação de manipulação");
            var response = await next();
            await _writer.WriteLineAsync("-- Pedido Concluído");
            return response;
        }
    }
}
