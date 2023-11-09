using Element.GIS.Fx.Plug;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Element.GIS.Plugin.DataConverter
{
    /// <summary>
    /// 数据转换
    /// </summary>
    [Export(typeof(IPlug))]
    public class PlugDataConverter : IPlug
    {
        public string Name => "DataConverter";

        public string Title => "数据转换";

        public string Description => "数据转换";

        public bool FreeUse => true;

        public List<ISubPlug> Subs => new List<ISubPlug>()
        { 
            new PlugDataShp2GeoJsonConverter(),
            new PlugDataGeoJson2ShpConverter(),
        };
    }
}
