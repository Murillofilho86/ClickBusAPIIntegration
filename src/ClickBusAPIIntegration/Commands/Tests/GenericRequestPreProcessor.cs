namespace ClickBusAPIIntegration.Commands.Tests
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR.Pipeline;

    public class GenericRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly TextWriter _writer;

        public GenericRequestPreProcessor(TextWriter writer)
        {
            _writer = writer;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            return _writer.WriteLineAsync("- Começando");
        }
    }
}
