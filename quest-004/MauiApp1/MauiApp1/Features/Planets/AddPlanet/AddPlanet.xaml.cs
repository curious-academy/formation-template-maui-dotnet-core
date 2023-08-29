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
    private void btnSave_Clicked(object sender, EventArgs e)
    {
        this.CurrentItem.Set(this.txtName.Text);
        Shell.Current.GoToAsync("..");
    }
    #endregion

    #region Properties
    public int PlanetId
    {
        set
        {
            this.CurrentItem = this.planets.GetById(value);
            this.txtName.Text = this.CurrentItem.Name;
        }
    }

    public Planet CurrentItem { get; set; }
    #endregion
}