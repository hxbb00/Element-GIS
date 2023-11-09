using Element.GIS.Fx;
using Element.GIS.Fx.Plug;

namespace Element.GIS.Plugin.DataConverter
{
    public class PlugDataGeoJson2ShpConverter : ISubPlug
    {
        public string Name => "DataGeoJson2ShpConverter";

        public string Title => "GeoJson转Shp";

        public string Description => "GeoJson 转 shp";

        public bool FreeUse => true;

        public void ButtonClick()
        {
            ProgramHelper.StartProcess("DataConverter", "Element.GIS.Module.DataConverter.exe", "");
        }
    }
}
