using System.Threading.Tasks;

namespace Element.GIS.Fx
{
    public interface IHostGrpc
    {
        Task SayHelloAsync();
        void Close();
    }
}
