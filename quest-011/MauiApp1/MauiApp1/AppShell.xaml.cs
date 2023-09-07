namespace MauiApp1;
using Features.Planets.AddPlanet;
using Features.Planets.ListPlanet;
using MauiApp1.Features.Loggers;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(ShowLogs), typeof(ShowLogs));
        Routing.RegisterRoute(nameof(ListPlanet), typeof(ListPlanet));
        Routing.RegisterRoute(nameof(AddPlanet), typeof(AddPlanet));


    }
}
