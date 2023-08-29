using MauiApp1.Features.Planets.Models;
using System.Collections.ObjectModel;

namespace MauiApp1.Features.Planets.ListPlanet;

public partial class ListPlanet : ContentPage
{
    #region Fields
    private Features.Planets.Models.Planets planets = new Features.Planets.Models.Planets();
    #endregion

    public ListPlanet()
    {
        InitializeComponent();

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        this.DisplayPlanets();
    }

    private async Task btnGoBack_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private void DisplayPlanets()
    {
        this.lstPlanets.ItemsSource = new ObservableCollection<Planet>(Planets.Models.Planets.List);

        //DisplayActionSheet("Hello", "Cancel ?", "Destroy", FlowDirection.LeftToRight);
        //DisplayAlert("Hello !", "Yeah", "Cancel", FlowDirection.LeftToRight);
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

    private void MenuItem_Clicked(object sender, EventArgs e)
    {
        MenuItem item = sender as MenuItem;
        var planet = item.BindingContext as Planet;
        this.planets.Delete(planet);

        this.lstPlanets.ItemsSource = new ObservableCollection<Planet>(Planets.Models.Planets.List);
    }

    private void search_TextChanged(object sender, TextChangedEventArgs e)
    {
        var planets = this.planets.Search(e.NewTextValue);
        var obsPlanets = new ObservableCollection<Planet>(planets);

        this.lstPlanets.ItemsSource = obsPlanets;
    }

    private void search_SearchButtonPressed(object sender, EventArgs e)
    {

    }
}