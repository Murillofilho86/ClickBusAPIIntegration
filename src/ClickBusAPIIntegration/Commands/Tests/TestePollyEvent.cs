namespace ClickBusAPIIntegration.Commands.Tests
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Polly;

    public class TestePollyEvent : IRequestHandler<TestePollyCommad, TestePollyEvent>
    {
        private readonly HttpClient _httpClient;
        private string _endPoint { get; }
        private int _maxRetryAttempts { get; }
        private TimeSpan _pauseBetweenFailures { get; }


        public TestePollyEvent(string endPoint, int maxRetryAttempts, TimeSpan pauseBetweenFailures)
        {
            _httpClient = new HttpClient();
            _maxRetryAttempts = maxRetryAttempts;
            _pauseBetweenFailures = pauseBetweenFailures;
            _endPoint = endPoint;
        }

        public async Task<HttpResponseMessage> RecuperarValor()
        {
            var retryPolicy = Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(_maxRetryAttempts, i => _pauseBetweenFailures);

            return await retryPolicy.ExecuteAsync(async () =>
            {
                return await _httpClient
                  .GetAsync(_endPoint);
            });
        }

        public Task<TestePollyEvent> Handle(TestePollyCommad request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new TestePollyEvent(request.EndPoint, request.MaxRetryAttempts, request.PauseBetweenFailures));
        }
    }
}
