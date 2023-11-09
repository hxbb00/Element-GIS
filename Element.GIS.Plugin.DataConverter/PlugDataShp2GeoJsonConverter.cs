using Element.GIS.Fx;
using Element.GIS.Fx.Plug;

namespace Element.GIS.Plugin.DataConverter
{
    public class PlugDataShp2GeoJsonConverter : ISubPlug
    {
        public string Name => "DataShp2GeoJsonConverter";

        public string Title => "Shp转GeoJson";

        public string Description => "Shp 转 GeoJson";

        public bool FreeUse => true;

        public void ButtonClick()
        {
            ProgramHelper.StartProcess("DataConverter", "Element.GIS.Module.DataConverter.exe", "");
        }
    }
}
