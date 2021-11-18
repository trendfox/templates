using Microsoft.Extensions.Logging;
using Prism.Mvvm;

namespace TFWpf;

public class MainViewModel
    : BindableBase
{
    private readonly ILogger<MainViewModel> _logger;

    private string _title = "MainView";
    public string Title
    {
        get { return _title; }
        set { SetProperty(ref _title, value); }
    }

    public MainViewModel(ILogger<MainViewModel> logger)
    {
        _logger = logger;
    }
}
