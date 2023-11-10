using Grpc.Net.Client;
using System.Threading.Tasks;
using System;

namespace Element.GIS.Fx
{
    internal class DefaultHostGrpc : IHostGrpc
    {
        private readonly GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:5001");

        public void Close()
        {
            channel.Dispose();
        }

        public async Task SayHelloAsync()
        {
            var client = new Greeter.GreeterClient(channel);

            var response = await client.SayHelloAsync(
                new HelloRequest { Name = "World" });

            Console.WriteLine(response.Message);
        }
    }
}