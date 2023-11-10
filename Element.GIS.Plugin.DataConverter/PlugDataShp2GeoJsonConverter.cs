using Element.GIS.Fx;
using Element.GIS.Fx.Plug;
using Neumorphism.Avalonia.Demo.Pages.Panels;

namespace Element.GIS.Plugin.DataConverter
{
    public class PlugDataShp2GeoJsonConverter : ISubPlug
    {
        public string Name => "DataShp2GeoJsonConverter";

        public string Title => "shp转geojson";

        public string Description => "shp 转 geojson";

        public bool FreeUse => true;

        public object AvaloniaControl
        {
            get
            {
                return new PanelLoginDemo();
            }
        }

        public void ButtonClick()
        {
            ProgramHelper.StartProcess("DataConverter", "Element.GIS.Module.DataConverter.exe", "");
        }
    }
}
