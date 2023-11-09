using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels;
using Neumorphism.Avalonia.Demo.Windows.ViewModels;
using System;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public partial class CardsDemo : UserControl
    {
        public CardsDemo()
        {
            InitializeComponent();

            DataContext = new CardsDemoViewModel();
        }

        public void SetSelValue(PlugModel plugModel)
        {
            ((CardsDemoViewModel)DataContext).SetSelValue(plugModel);
        }
    }
}