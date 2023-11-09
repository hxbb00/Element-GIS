using System.Collections.Generic;

namespace Element.GIS.Fx.Plug
{
    public interface IPlug
    {
        string Name { get; }
        string Title { get; }
        string Description { get; }
        bool FreeUse { get; }
        List<ISubPlug> Subs { get; }
    }

    public interface ISubPlug
    {
        string Name { get; }
        string Title { get; }
        string Description { get; }
        bool FreeUse { get; }
    }
}
