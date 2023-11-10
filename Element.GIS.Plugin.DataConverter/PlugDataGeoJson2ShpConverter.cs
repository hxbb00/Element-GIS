using Element.GIS.Fx;
using Element.GIS.Fx.Plug;
using Neumorphism.Avalonia.Demo.Pages.Panels;

namespace Element.GIS.Plugin.DataConverter
{
    public class PlugDataGeoJson2ShpConverter : ISubPlug
    {
        public string Name => "DataGeoJson2ShpConverter";
        public string Title => "geojson转shp";
        public string Description => "geojson 转 shp";

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
