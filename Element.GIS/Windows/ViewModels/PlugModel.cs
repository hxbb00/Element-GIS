using Element.GIS.Fx.Plug;

namespace Neumorphism.Avalonia.Demo.Windows.ViewModels
{
    public class PlugModel
    {
        private readonly IPlug _elementGISPlug;

        public PlugModel(IPlug elementGISPlug)
        {
            _elementGISPlug = elementGISPlug;
        }

        public string Name { get { return _elementGISPlug.Name; } }
        public string Title { get { return _elementGISPlug.Title; } }
        public string Description { get { return _elementGISPlug.Description; } }
        public bool FreeUse { get { return _elementGISPlug.FreeUse; } }
    }
}