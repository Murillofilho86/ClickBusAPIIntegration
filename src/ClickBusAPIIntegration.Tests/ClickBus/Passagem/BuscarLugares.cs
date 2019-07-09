using ClickBusAPIIntegration.Models;
using System;
using System.Threading.Tasks;

namespace ClickBusAPIIntegration.Tests.ClickBus.Passagem
{
    public class BuscarLugares
    {

        public async Task BuscarTodosLugares_Response()
        {
            var http = new HttpAPI()
            {
                EndPoint = "/api/v1/places",
                Host = "api.clickbus.com.br",
                Protocol = "http",
                Method = "GET",
                Police = new HttpPolice()
                {
                    Retry = new HttpPoliceRetry()
                    {
                        MaxRetryAttempts = 3,
                        PauseBetweenFailures = TimeSpan.FromSeconds(3)
                    }
                },
                Content = ""
            };

            http.Headers.Add("cache-control", "no-cache");
            http.Headers.Add("x-access-token", _token);
        }
    }
}
