using System.Windows;

namespace TFWpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
    : Application
{
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        MainWindow = new MainView();
        MainWindow.Show();
    }
}
