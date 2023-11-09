using Avalonia.Themes.Neumorphism.Controls;
using Element.GIS.Fx.Plug;
using Neumorphism.Avalonia.Demo.Windows.ViewModels;
using System.Collections.ObjectModel;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public sealed class CardsDemoViewModel : ViewModelBase
    {
        public void SetSelValue(PlugModel plugModel)
        {
            PlugName = plugModel.Title;
            PlugItems = new ObservableCollection<SubPlugModel>(plugModel.GetSubs());
        }

        private ObservableCollection<SubPlugModel> _plugItems;
        public ObservableCollection<SubPlugModel> PlugItems
        {
            get { return _plugItems; }
            set
            {
                _plugItems = value;
                OnPropertyChanged(nameof(PlugItems));
            }
        }

        private string _plugName;
        public string PlugName
        {
            get { return _plugName; }
            set
            {
                _plugName = value;
                OnPropertyChanged(nameof(PlugName));
            }
        }
    }
}
