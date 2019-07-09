namespace ClickBusAPIIntegration.Commands.Tests
{
    using MediatR.Pipeline;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public class GenericRequestPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly TextWriter _writer;

        public GenericRequestPostProcessor(TextWriter writer)
        {
            _writer = writer;
        }

        public Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            return _writer.WriteLineAsync("- Tudo Encerrado");
        }
              
    }
}
