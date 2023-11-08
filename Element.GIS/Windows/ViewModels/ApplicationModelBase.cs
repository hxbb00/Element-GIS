using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Styling;
using Avalonia.Themes.Neumorphism.Controls;
using Avalonia.Themes.Neumorphism.Enums;
using Element.GIS.Plug;
using Neumorphism.Avalonia.Demo.Interfaces;
using Neumorphism.Avalonia.Demo.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Neumorphism.Avalonia.Demo.Windows.ViewModels
{
    internal abstract class ApplicationModelBase : ViewModelBase, IMainWindowState
    {
        private readonly IThemeSwitch _themeSwitch;


        private bool _aboutEnable;
        public bool AboutEnabled
        {
            get { return _aboutEnable; }
            set
            {
                _aboutEnable = value;
                OnPropertyChanged(nameof(AboutEnabled));
            }
        }


        private bool _darkThemeEnabled = false;
        public bool DarkThemeEnabled
        {
            get { return _darkThemeEnabled; }
            set
            {
                _darkThemeEnabled = value;
                OnPropertyChanged(nameof(DarkThemeEnabled));
            }
        }


        private int _selectedPageIndex = 0;
        public int CurrentPageIndex
        {
            get { return _selectedPageIndex; }
            set
            {
                _selectedPageIndex = value;
                OnPropertyChanged(nameof(CurrentPageIndex));
            }
        }


        private bool _isDialogOpened;
        public bool IsDialogOpened
        {
            get { return _isDialogOpened; }
            set
            {
                _isDialogOpened = value;
                OnPropertyChanged(nameof(IsDialogOpened));
            }
        }

        private ObservableCollection<PlugModel> _plugItems;
        public ObservableCollection<PlugModel> PlugItems
        {
            get { return _plugItems; }
            set
            {
                _plugItems = value;
                OnPropertyChanged(nameof(PlugItems));
            }
        }

        public ApplicationModelBase(IThemeSwitch themeSwitch)
        {
            AboutEnabled = true;

            ThemeVariant theme = Application.Current.GetValue(ThemeVariantScope.ActualThemeVariantProperty);

            _themeSwitch = themeSwitch;

            var plugs = PlugManager.GetElementGISPlugs().Select(x => new PlugModel(x));
            _plugItems = new ObservableCollection<PlugModel>(plugs);

            ApplicationTheme appTheme = theme == ThemeVariant.Dark ? ApplicationTheme.Dark : ApplicationTheme.Light;
            IntializeTheme(appTheme);
        }

        public abstract void SayHelloCommand(string msg);
        public abstract void HelpAboutMethod();
        public abstract void AppExitCommand();
        public abstract void SwitchThemeCommand(bool dark);







        protected void SayHello(string msg)
        {
            SnackbarHost.Post(msg);
        }

        protected async void RunHelpAbout(Window currentWindow)
        {
            if (AboutEnabled)
            {
                try
                {
                    AboutEnabled = false;
                    await new AboutWindow(IsDarkTheme(_themeSwitch.Current)).ShowDialog(currentWindow);
                }
                finally
                {
                    AboutEnabled = true;
                }
            }
        }

        protected void AppExit()
        {
            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.Shutdown(0);
            }
        }


        protected void SetTheme(ApplicationTheme theme)
        {
            IntializeTheme(theme);
            _themeSwitch.ChangeTheme(theme);
        }





        private void IntializeTheme(ApplicationTheme theme)
        {
            DarkThemeEnabled = (theme == ApplicationTheme.Dark);
        }

        private static bool IsDarkTheme(ApplicationTheme? theme)
            => theme switch
            {
                ApplicationTheme.Dark => true,
                _ => false,
            };
    }
}