using AllModels.Planets;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace MauiApp1.Features.Planets.ListPlanet.ViewModels
{
    public partial class ListPlanetViewModel : ObservableObject
    {
        #region Constructors
        public ListPlanetViewModel(PlanetsUseCase planetsUseCase)
        {
            this.PlanetsUseCase = planetsUseCase;
        }
        #endregion

        #region Public methods
        public async Task<List<Planet>> Load()
        {
            var result = await this.PlanetsUseCase.GetAllAsync(string.Empty);
            this.Planets.Clear();
            result.ForEach(item => this.Planets.Add(item));

            return result;
        }
        #endregion

        #region Properties
        [ObservableProperty]
        private ObservableCollection<Planet> planets = new ObservableCollection<Planet>();

        public PlanetsUseCase PlanetsUseCase { get; init; }
        #endregion
    }
}
