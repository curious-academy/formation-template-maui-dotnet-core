using MauiApp1.Features.Planets.Models;

namespace MauiApp1.Features.Planets.AddPlanet;

[QueryProperty(nameof(PlanetId), "Id")]
public partial class AddPlanet : ContentPage
{


    public AddPlanet()
    {
        InitializeComponent();
    }

    public int PlanetId
    {
        set
        {
            this.CurrentItem = new()
            {
                Id = value
            };
        }
    }

    public Planet CurrentItem { get; set; }
}