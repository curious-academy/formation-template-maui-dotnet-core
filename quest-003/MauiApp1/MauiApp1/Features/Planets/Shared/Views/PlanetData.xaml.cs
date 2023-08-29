namespace MauiApp1.Features.Planets.Shared.Views;

public partial class PlanetData : ContentView
{
    #region Fields
    public event EventHandler<string> OnError;
    public event EventHandler OnSaving;
    #endregion

    #region Constructors
    public PlanetData()
    {
        InitializeComponent();
    }
    #endregion

    #region Properties
    public string Name
    {
        get => txtName.Text; set => txtName.Text = value;
    }
    #endregion

    #region Internal methods
    private void btnSave_Clicked(object sender, EventArgs e)
    {
        if (this.validatorName.IsNotValid)
        {
            this.OnError?.Invoke(this, "Name is required");
            return;
        }
        this.OnSaving?.Invoke(this, EventArgs.Empty);
    }
    #endregion
}