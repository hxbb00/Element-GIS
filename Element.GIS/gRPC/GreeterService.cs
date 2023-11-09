using Avalonia.Themes.Neumorphism.Controls;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Element.GIS.gRPC
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;

        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request,
            ServerCallContext context)
        {
            SnackbarHost.Post($"Saying hello to gRPC -> {request.Name}");
            _logger.LogInformation("Saying hello to {Name}", request.Name);
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
