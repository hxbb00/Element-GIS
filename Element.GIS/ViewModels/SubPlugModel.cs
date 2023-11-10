using Avalonia.Themes.Neumorphism.Controls;
using Element.GIS.Fx.Plug;
using Neumorphism.Avalonia.Demo.Interfaces;
using Neumorphism.Avalonia.Demo.Windows.ViewModels;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public class SubPlugModel : ViewModelBase
    {
        private readonly PlugModel _plugModel;
        private readonly ISubPlug _elementGISPlug;
        private readonly ICardsDemoHost _cardsDemoHost;

        public SubPlugModel(PlugModel plugModel, ISubPlug elementGISPlug, ICardsDemoHost cardsDemoHost)
        {
            _plugModel = plugModel;
            _elementGISPlug = elementGISPlug;
            _cardsDemoHost = cardsDemoHost;
        }

        public string Name { get { return _elementGISPlug.Name; } }
        public string Title { get { return _elementGISPlug.Title; } }
        public string Description { get { return _elementGISPlug.Description; } }
        public bool FreeUse { get { return _elementGISPlug.FreeUse; } }

        private bool _bRunning;
        public bool Running
        {
            get { return _bRunning; }
            set
            {
                _bRunning = value;
                OnPropertyChanged(nameof(Running));
            }
        }

        public void ButtonClick()
        {
            Running = true;
            _cardsDemoHost.BeRunning(Running);
        }
    }
}
