namespace MauiApp1.Features.Planets.ListPlanet;

public partial class ListPlanet : ContentPage
{
    public ListPlanet()
    {
        InitializeComponent();
    }

    private async Task btnGoBack_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}