namespace ClickBusAPIIntegration.Tests.Basic
{
    using ClickBusAPIIntegration.Commands.Tests;
    using MediatR;
    using Shouldly;
    using StructureMap;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class TesteBasico
    {
        [Fact]
        public async Task MediatR_Responde()
        {
            var container = new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssemblyContainingType<Ping>(); 
                    scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                });
                cfg.For<ServiceFactory>().Use<ServiceFactory>(ctx => ctx.GetInstance);
                cfg.For<IMediator>().Use<Mediator>();
            });

            var mediator = container.GetInstance<IMediator>();

            var response = await mediator.Send(new Ping { Message = "Ping" });

            response.Message.ShouldBe("Ping Pong");
        }

        [Fact]
        public async Task Polly_Responde()
        {
            var container = new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssemblyContainingType<TestePollyCommad>();
                    scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                });
                cfg.For<ServiceFactory>().Use<ServiceFactory>(ctx => ctx.GetInstance);
                cfg.For<IMediator>().Use<Mediator>();
            });

            var mediator = container.GetInstance<IMediator>();

            var response = await mediator.Send(new TestePollyCommad
            {
                EndPoint = "https://jsonplaceholder.typicode.com/todos/1",
                MaxRetryAttempts = 3,
                PauseBetweenFailures = TimeSpan.FromSeconds(3)
            });

            var http = await response.RecuperarValor();
            Assert.NotNull(http);
            var content = await http.Content.ReadAsStringAsync();
            Assert.True(content.Length > 0);
        }
    }
}
