using Avalonia.Controls;
using DynamicData;
using Neumorphism.Avalonia.Demo.Interfaces;
using Neumorphism.Avalonia.Demo.ViewModels;
using Neumorphism.Avalonia.Demo.Windows.ViewModels;
using System;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public partial class CardsDemo : UserControl, ICardsDemoHost
    {
        private Carousel PageCarousel => this.GetControl<Carousel>("PageCarousel2");

        public CardsDemo()
        {
            InitializeComponent();

            DataContext = new CardsDemoViewModel();
        }

        public void SetSelValue(PlugModel plugModel)
        {
            ((CardsDemoViewModel)DataContext).SetSelValue(plugModel, this);
        }

        public void BeRunning(bool running, SubPlugModel subPlug)
        {
            PageCarousel.SelectedIndex = running ? 1 : 0;
            PlugContentPanel.Children.Clear();
            PlugContentPanel.Children.Add(subPlug.ContentPanel);
        }
    }
}