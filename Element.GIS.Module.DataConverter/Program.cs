using CommandLine;
using Element.GIS.Fx;
using System.Reflection;

namespace Element.GIS.Plugin.DataConverter
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(Run);
        }

        private static void Run(Options option)
        {
            var grpc = HostGrpcHelper.StartGrpc();
            Run0(option, grpc);
            grpc.Close();
        }

        private static void Run0(Options option, IHostGrpc hostGrpc)
        {
            var field = option.Format.GetType().GetField(option.Format.ToString());
            var customAttribute = field.GetCustomAttribute<FormatConverterAttribute>();
            customAttribute?.Convert(option, hostGrpc);
        }
    }
}