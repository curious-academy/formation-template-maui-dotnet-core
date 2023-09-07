using MetroLog.Maui;

namespace MauiApp1.Features.Loggers;

public partial class ShowLogs : ContentPage
{
    public ShowLogs()
    {
        InitializeComponent();
        BindingContext = new LogController();
    }

    private LogController LogController => (LogController)BindingContext;
}