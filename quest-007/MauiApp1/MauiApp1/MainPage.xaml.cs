using MauiApp1.Features.Planets.AddPlanet;
using MauiApp1.Features.Planets.ListPlanet;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        // SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private void btnGoToListPlanets_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(ListPlanet));
    }

    private void btnGoToAddPlanet_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddPlanet));
    }
}

