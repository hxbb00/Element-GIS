using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Element.GIS.Fx
{

    public class HostGrpcHelper
    {
        public static IHostGrpc StartGrpc()
        {
            return new DefaultHostGrpc();
        }
    }
}
