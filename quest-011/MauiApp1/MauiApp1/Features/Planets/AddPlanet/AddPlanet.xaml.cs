using AllModels.Planets;
using MauiApp1.Features.Planets.AddPlanet.ViewModels;

namespace MauiApp1.Features.Planets.AddPlanet;

[QueryProperty(nameof(PlanetId), "Id")]
public partial class AddPlanet : ContentPage
{
    #region Fields
    private AllModels.Planets.Planets planets = new AllModels.Planets.Planets();
    private readonly AddPlanetViewModel viewModel;
    #endregion

    #region Constructors
    public AddPlanet(AddPlanetViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        this.BindingContext = viewModel;
    }
    #endregion

    #region Internal methods
    private void btnSave_Clicked(object sender, EventArgs e)
    {
        //this.CurrentItem.Set(this.txtName.Text);
        Shell.Current.GoToAsync("..");
    }
    #endregion

    #region Properties
    public int PlanetId
    {
        set
        {
            this.CurrentItem = this.planets.GetById(value);
            this.viewModel.Planet = this.CurrentItem;
            //this.txtName.Text = this.CurrentItem.Name;
        }
    }

    public Planet CurrentItem { get; set; }
    #endregion
}