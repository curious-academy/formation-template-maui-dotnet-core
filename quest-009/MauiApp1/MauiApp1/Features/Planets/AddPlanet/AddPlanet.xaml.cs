using AllModels.Planets;

namespace MauiApp1.Features.Planets.AddPlanet;

[QueryProperty(nameof(PlanetId), "Id")]
public partial class AddPlanet : ContentPage
{
    #region Fields
    //private AllModels.Planets.Planets planets = new AllModels.Planets.Planets();
    private PlanetsUseCase useCase;
    #endregion

    #region Constructors
    public AddPlanet(PlanetsUseCase useCase)
    {

        InitializeComponent();
        this.useCase = useCase;
    }
    #endregion

    #region Internal methods
    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        this.CurrentItem.Set(this.txtName.Text);
        await this.useCase.SaveOne(this.CurrentItem);
        await Shell.Current.GoToAsync("..");
    }
    #endregion

    //#region Properties
    public int PlanetId
    {
        set
        {
            this.CurrentItem = new(value, string.Empty, string.Empty);
            this.txtName.Text = this.CurrentItem.Name;
        }
    }

    public Planet CurrentItem { get; set; }
    //#endregion
}