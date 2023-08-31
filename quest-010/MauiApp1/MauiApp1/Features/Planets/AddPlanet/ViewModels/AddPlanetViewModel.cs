using AllModels.Planets;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Interfaces;

namespace MauiApp1.Features.Planets.AddPlanet.ViewModels
{
    public partial class AddPlanetViewModel : ObservableObject
    {
        #region Fields
        private readonly IAddOnePlanet addOnePlanet;

        private Planet planet = new Planet(0, "", "");

        [ObservableProperty]
        private string name = string.Empty;
        #endregion

        #region Constructors
        public AddPlanetViewModel(IAddOnePlanet addOnePlanet)
        {
            this.addOnePlanet = addOnePlanet;
        }
        #endregion

        #region Public methods
        [RelayCommand]
        public async Task SaveOne()
        {

        }
        #endregion

        #region Properties
        public Planet Planet
        {
            set
            {
                this.planet = value;
                this.Name = value.Name;
            }
        }
        #endregion
    }
}
