using Microsoft.Extensions.Configuration;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Windows;

namespace TFWpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
    : PrismApplication
{
    private readonly IConfiguration Configuration;

    public App()
    {
        DispatcherUnhandledException += App_DispatcherUnhandledException;

        Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddCommandLine(Environment.GetCommandLineArgs())
            .Build();
    }

    protected override Window CreateShell()
    {
        return Container.Resolve<MainView>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        //// Display a view immediately
        //var regionManager = Container.Resolve<RegionManager>();
        //regionManager.RegisterViewWithRegion<MyView>(ShellRegions.MainRegion);
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        //// Register views for navigation
        //containerRegistry
        //    .RegisterForNavigation<MyView>(); // regionManager.RequestNavigate(ShellRegions.MainRegion, nameof(MyView));

        containerRegistry
            .AddLogging(Configuration)
            .AddAppServices();
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        base.ConfigureModuleCatalog(moduleCatalog);
        //// Add modules
        // moduleCatalog.AddModule<MyModule>();
    }

    private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
        MessageBox.Show(e.Exception.ToString(), "Error");
    }
}
