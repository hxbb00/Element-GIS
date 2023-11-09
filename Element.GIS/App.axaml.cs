using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Themes.Neumorphism;
using Avalonia.Themes.Neumorphism.Enums;
using Neumorphism.Avalonia.Demo.Interfaces;
using Neumorphism.Avalonia.Demo.Windows;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.DependencyInjection;
using Element.GIS.gRPC;
using Microsoft.AspNetCore.Builder;

namespace Neumorphism.Avalonia.Demo
{
    public sealed class App : Application, IThemeSwitch
    {
        private ApplicationTheme _currentTheme;
        private IHost GlobalHost;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);

            Name = "Element.GIS";
        }

        ApplicationTheme IThemeSwitch.Current => _currentTheme;


        void IThemeSwitch.ChangeTheme(ApplicationTheme theme)
        {
            if (theme == _currentTheme)
                return;

            _currentTheme = theme;

            var neumorphismTheme = Application.Current.LocateMaterialTheme<NeumorphismTheme>();
            if (neumorphismTheme != null)
            {
                neumorphismTheme.BaseTheme = theme;
            }
        }

        public override async void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
                DataContext = desktop.MainWindow.DataContext;
                desktop.Exit += (sender, args) =>
                {
                    GlobalHost.StopAsync(TimeSpan.FromSeconds(5)).GetAwaiter().GetResult();
                    GlobalHost.Dispose();
                    GlobalHost = null;
                };
            }

            var hostBuilder = CreateHostBuilder();
            var host = hostBuilder.Build();
            host.MapGrpcService<GreeterService>();
            host.MapGet("/", () => "Welcome ElementGIS");
            GlobalHost = host;

            base.OnFrameworkInitializationCompleted();

            // Usually, we don't want to block main UI thread.
            // But if it's required to start async services before we create any window,
            // then don't set any MainWindow, and simply call Show() on a new window later after async initialization. 
            await host.StartAsync();
        }

        private static WebApplicationBuilder CreateHostBuilder()
        {
            // Alternatively, we can use Host.CreateDefaultBuilder, but this sample focuses on HostApplicationBuilder.
            //var builder = Host.CreateApplicationBuilder(Environment.GetCommandLineArgs());
            var builder = WebApplication.CreateBuilder(Environment.GetCommandLineArgs());
            builder.Services.AddGrpc();
            return builder;
        }
    }
}