using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Element.GIS.Fx.Plug
{
    /// <summary>
    /// 主页
    /// </summary>
    [Export(typeof(IPlug))]
    public class PlugHome : IPlug
    {
        public string Name => "Home";

        public string Title => "主页";

        public string Description => "主页";

        public bool FreeUse => true;

        public List<IPlug> Subs => new List<IPlug>();
    }
}
