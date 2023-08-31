using AllModels.Planets;
using Interfaces;

namespace MauiApp1.Features.Planets.AddPlanet;

[QueryProperty(nameof(PlanetId), "Id")]
public partial class AddPlanet : ContentPage
{
    #region Fields
    private AllModels.Planets.Planets planets = new AllModels.Planets.Planets();
    private readonly IAddOnePlanet addOnePlanet;
    #endregion

    #region Constructors
    public AddPlanet(IAddOnePlanet addOnePlanet)
    {
        this.addOnePlanet = addOnePlanet;
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