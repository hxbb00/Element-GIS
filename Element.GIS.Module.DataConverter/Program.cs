using Element.GIS.Fx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Element.GIS.Plugin.DataConverter
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var grpc = HostGrpcHelper.StartGrpc();
            grpc.SayHelloAsync().Wait();
            grpc.Close();
        }
    }
}
