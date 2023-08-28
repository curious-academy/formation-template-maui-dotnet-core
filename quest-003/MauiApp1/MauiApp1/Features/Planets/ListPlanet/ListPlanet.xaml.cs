using MauiApp1.Features.Planets.Models;

namespace MauiApp1.Features.Planets.ListPlanet;

public partial class ListPlanet : ContentPage
{
    public ListPlanet()
    {
        InitializeComponent();
        this.DisplayPlanets();
    }

    private async Task btnGoBack_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private void DisplayPlanets()
    {
        List<Planet> strings = new()
        {
            new () { Id = 1, Name = "Coruscant", Description="bl" },
            new () { Id = 2, Name = "Kashhyk", Description = "bla" }
        };
        this.lstPlanets.ItemsSource = strings;
    }
}