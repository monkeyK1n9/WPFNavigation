using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Windows;
using WPFNavigation.Core;
using WPFNavigation.MVVM.ViewModel;
using WPFNavigation.Services;

namespace WPFNavigation;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        IServiceCollection service = new ServiceCollection();

        service.AddSingleton<MainWindow>(provider => new MainWindow
        {
            DataContext = provider.GetRequiredService<MainViewModel>()
        });

        //register the screens
        service.AddSingleton<MainViewModel>();
        service.AddSingleton<HomeViewModel>();
        service.AddSingleton<SettingsViewModel>();

        //register navigation service
        service.AddSingleton<INavigationService, NavigationService>();

        //register the func
        service.AddSingleton<Func<Type, ViewModel>>(serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));

        _serviceProvider = service.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }
}

