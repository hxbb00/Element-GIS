using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Avalonia.Themes.Neumorphism.Controls;
using Neumorphism.Avalonia.Demo.Interfaces;
using Neumorphism.Avalonia.Demo.Pages;
using Neumorphism.Avalonia.Demo.ViewModels;
using Neumorphism.Avalonia.Demo.Windows.ViewModels;

namespace Neumorphism.Avalonia.Demo.Windows
{
    public sealed partial class MainWindow : Window, IMainWindow
    {
        private readonly Application _app = App.Current;

        #region Control fields

        private ToggleButton NavDrawerSwitch => this.GetControl<ToggleButton>("NavDrawerSwitch2");
        private ListBox DrawerList => this.GetControl<ListBox>("DrawerPlugList");
        private Carousel PageCarousel => this.GetControl<Carousel>("PageCarousel2");
        private ScrollViewer mainScroller => this.GetControl<ScrollViewer>("mainScroller2");

        private CardsDemo mainCards => this.GetControl<CardsDemo>("cardsPage");

        #endregion


        public MainWindow() : this(default) { }
        public MainWindow(IMainWindow window)
        {
            InitializeComponent(window);
        }

        IThemeSwitch IMainWindow.ThemeSwitch => (IThemeSwitch)_app!;
        IMainWindowState IMainWindow.Model => (IMainWindowState)DataContext;
        PixelPoint IMainWindow.Position => Utilities.GetWindowPosition(this);
        Size IMainWindow.ClientSize => ClientSize;
        Size? IMainWindow.FrameSize => FrameSize;
        WindowState IMainWindow.State => WindowState;

        private void InitializeComponent(IMainWindow window)
        {
            AvaloniaXamlLoader.Load(this);

            var vm = new MainViewModel<MainWindow>(this);
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "DarkThemeEnabled")
                {
                    if (vm.DarkThemeEnabled)
                    {
                        Application.Current.SetValue(ThemeVariantScope.ActualThemeVariantProperty, ThemeVariant.Dark);
                    }
                    else
                    {
                        Application.Current.SetValue(ThemeVariantScope.ActualThemeVariantProperty, ThemeVariant.Light);
                    }
                }
            };

            DataContext = vm;

            if (window is not null)
            {
                WindowStartupLocation = WindowStartupLocation.Manual;
                PageCarousel.SelectedIndex = window.Model != null ? window.Model.CurrentPageIndex : 0;
                WindowState = window.State;
                Position = window.Position;
                FrameSize = window.FrameSize;
                ClientSize = window.ClientSize;
            }


            #region Control getter and event binding

            DrawerList.PointerReleased += DrawerSelectionChanged;
            DrawerList.KeyUp += DrawerList_KeyUp;

            #endregion
        }

        private void TemplatedControl_OnTemplateApplied(object sender, TemplateAppliedEventArgs e)
        {
            SnackbarHost.Post("Welcome to\r\nElement GIS !");
        }


        private void DrawerList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.Enter)
            {
                DrawerSelectionChanged(sender, null);
            }
        }

        public void DrawerSelectionChanged(object sender, RoutedEventArgs args)
        {
            var listBox = sender as ListBox;
            if (!listBox.IsFocused && !listBox.IsKeyboardFocusWithin)
                return;
            try
            {
                var sel1 = listBox.SelectedItem;
                var sel2 = listBox.SelectedValue;
                mainCards.SetSelValue(sel2 as PlugModel);
                PageCarousel.SelectedIndex = listBox.SelectedIndex == 0 ? 0 : 1;
                mainScroller.Offset = Vector.Zero;
                mainScroller.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                ((IMainWindowState)DataContext).CurrentPageIndex = listBox.SelectedIndex;
            }
            catch
            {
            }

            NavDrawerSwitch.IsChecked = false;
        }
    }
}
