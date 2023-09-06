using AllModels.Planets;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Shared.UIs.Dialogs;
using System.Collections.ObjectModel;

namespace MauiApp1.Features.Planets.ListPlanet.ViewModels
{
    public partial class ListPlanetViewModel : ObservableObject
    {
        #region Constructors
        public ListPlanetViewModel(PlanetsUseCase planetsUseCase, IDialogService dialogService)
        {
            this.PlanetsUseCase = planetsUseCase;
            this.dialogService = dialogService;
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

        [RelayCommand]
        public async Task DeleteOne(int id)
        {
            await this.dialogService.ShowConfirmationAsync("DELETE", " Sure ?");
        }
        #endregion

        #region Properties
        [ObservableProperty]
        private ObservableCollection<Planet> planets = new ObservableCollection<Planet>();

        private readonly IDialogService dialogService;

        public PlanetsUseCase PlanetsUseCase { get; init; }
        #endregion
    }
}
