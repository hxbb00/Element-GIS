using Neumorphism.Avalonia.Demo.Interfaces;
using Neumorphism.Avalonia.Demo.Windows.ViewModels;
using System.Collections.ObjectModel;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public sealed class CardsDemoViewModel : ViewModelBase
    {
        public void SetSelValue(PlugModel plugModel, ICardsDemoHost cardsDemoHost)
        {
            PlugName = plugModel.Title;
            PlugItems = new ObservableCollection<SubPlugModel>(plugModel.GetSubs(cardsDemoHost));
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

        private int _modeSelectedIndex;
        public int ModeSelectedIndex
        {
            get { return _modeSelectedIndex; }
            set
            {
                _modeSelectedIndex = value;
                OnPropertyChanged(nameof(ModeSelectedIndex));
                ReturnButtonIsVisible = 0 != value;
            }
        }
        private bool _returnButtonIsVisible;
        public bool ReturnButtonIsVisible
        {
            get { return _returnButtonIsVisible; }
            set
            {
                _returnButtonIsVisible = value;
                OnPropertyChanged(nameof(ReturnButtonIsVisible));
            }
        }

        public void ReturnButtonClick()
        {
            ModeSelectedIndex = 0;
        }
    }
}
