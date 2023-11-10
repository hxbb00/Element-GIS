using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels.Panels;

namespace Neumorphism.Avalonia.Demo.Pages.Panels
{
    public partial class PanelShp2Geojson : UserControl
    {
        public PanelShp2Geojson()
        {
            InitializeComponent();

            DataContext = new PanelShp2GeojsonViewModel();
        }
    }
}