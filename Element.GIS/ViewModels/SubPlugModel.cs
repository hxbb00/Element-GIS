using Avalonia.Themes.Neumorphism.Controls;
using Element.GIS.Fx.Plug;
using Neumorphism.Avalonia.Demo.Windows.ViewModels;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public class SubPlugModel : ViewModelBase
    {
        private readonly PlugModel _plugModel;
        private readonly ISubPlug _elementGISPlug;

        public SubPlugModel(PlugModel plugModel, ISubPlug elementGISPlug)
        {
            _plugModel = plugModel;
            _elementGISPlug = elementGISPlug;
        }

        public string Name { get { return _elementGISPlug.Name; } }
        public string Title { get { return _elementGISPlug.Title; } }
        public string Description { get { return _elementGISPlug.Description; } }
        public bool FreeUse { get { return _elementGISPlug.FreeUse; } }

        public void ButtonClick()
        {
            SnackbarHost.Post("You have clicked on the button !");
            _elementGISPlug.ButtonClick();
        }
    }
}
