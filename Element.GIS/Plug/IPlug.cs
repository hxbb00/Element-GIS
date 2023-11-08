using System.Collections.Generic;

namespace Element.GIS.Plug
{
    public interface IPlug
    {
        string Name { get; }
        string Title { get; }
        string Description { get; }
        bool FreeUse { get; }
        List<IPlug> Subs { get; }
    }
}
