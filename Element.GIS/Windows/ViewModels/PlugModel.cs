using Avalonia.Controls.Presenters;
using Element.GIS.Plug;

namespace Neumorphism.Avalonia.Demo.Windows.ViewModels
{
    public class PlugModel
    {
        private readonly IPlug _elementGISPlug;

        public static implicit operator PlugModel(ContentPresenter contentPresenter)
        {
            return new PlugModel(contentPresenter);
        }

        public PlugModel(ContentPresenter contentPresenter)
        {

        }

        public PlugModel(IPlug elementGISPlug)
        {
            _elementGISPlug = elementGISPlug;
        }

        public string Name { get { return _elementGISPlug?.Name; } set { } }
        public string Title { get { return _elementGISPlug?.Title; } set { } }
        public string Description { get { return _elementGISPlug?.Description; } set { } }
        public bool FreeUse { get { return _elementGISPlug.FreeUse; } set { } }
    }
}