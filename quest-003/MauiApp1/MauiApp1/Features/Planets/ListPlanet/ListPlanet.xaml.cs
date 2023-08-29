using MauiApp1.Features.Planets.Models;

namespace MauiApp1.Features.Planets.ListPlanet;

public partial class ListPlanet : ContentPage
{
    #region Fields
    private Features.Planets.Models.Planets planets = new Features.Planets.Models.Planets();
    #endregion

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
        this.lstPlanets.ItemsSource = this.planets.List;

        DisplayActionSheet("Hello", "Cancel ?", "Destroy", FlowDirection.LeftToRight);
        DisplayAlert("Hello !", "Yeah", "Cancel", FlowDirection.LeftToRight);
    }

    private async void lstPlanets_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (this.lstPlanets.SelectedItem != null)
        {
            var planet = this.lstPlanets.SelectedItem as Planet;
            await Shell.Current.GoToAsync($"{nameof(AddPlanet.AddPlanet)}?Id={planet.Id}");
        }
    }

    private void lstPlanets_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        this.lstPlanets.SelectedItem = null;
    }
}