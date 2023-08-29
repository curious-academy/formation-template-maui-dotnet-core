using MauiApp1.Features.Planets.Models;

namespace MauiApp1.Features.Planets.AddPlanet;

[QueryProperty(nameof(PlanetId), "Id")]
public partial class AddPlanet : ContentPage
{
    #region Fields
    private Features.Planets.Models.Planets planets = new Features.Planets.Models.Planets();
    #endregion

    #region Constructors
    public AddPlanet()
    {
        InitializeComponent();
    }
    #endregion

    #region Internal methods
    #endregion

    #region Properties
    public int PlanetId
    {
        set
        {
            this.CurrentItem = this.planets.GetById(value);
            this.planetData.Name = this.CurrentItem.Name;
        }
    }

    public Planet CurrentItem { get; set; }
    #endregion

    private void planetData_OnError(object sender, string e)
    {
        DisplayAlert("ERROR", e, "OK");
    }

    private void planetData_OnSaving(object sender, EventArgs e)
    {
        this.CurrentItem.Set(this.planetData.Name);
        Shell.Current.GoToAsync("..");
    }
}