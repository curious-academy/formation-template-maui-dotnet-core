namespace MauiApp1;
using Features.Planets.AddPlanet;
using Features.Planets.ListPlanet;
public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(ListPlanet), typeof(ListPlanet));
        Routing.RegisterRoute(nameof(AddPlanet), typeof(AddPlanet));
    }
}
