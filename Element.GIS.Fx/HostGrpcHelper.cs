using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace Element.GIS.Fx
{
    public class HostGrpcHelper
    {
        public static async Task SayHelloAsync()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var response = await client.SayHelloAsync(
                new HelloRequest { Name = "World" });

            Console.WriteLine(response.Message);
            channel.Dispose();
        }
    }
}
