﻿using AllModels.Planets;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Interfaces;
using MauiApp1.Shared.UIs.Dialogs;

namespace MauiApp1.Features.Planets.AddPlanet.ViewModels
{
    public partial class AddPlanetViewModel : ObservableObject
    {
        #region Fields
        private readonly IAddOnePlanet addOnePlanet;
        private readonly IDialogService dialogService;
        private Planet planet = new Planet(0, "", "");

        [ObservableProperty]
        private string name = string.Empty;

        [ObservableProperty]
        private bool nameIsValid = false;
        #endregion

        #region Constructors
        public AddPlanetViewModel(IAddOnePlanet addOnePlanet, IDialogService dialogService)
        {
            this.addOnePlanet = addOnePlanet;
            this.dialogService = dialogService;
        }
        #endregion

        #region Public methods
        [RelayCommand]
        public async Task SaveOne()
        {
            if (this.NameIsValid)
            {
                await this.dialogService.ShowConfirmationAsync("Save is done", "Data are saved");
            }
        }

        [RelayCommand]
        public async Task ForceValidateName()
        {
            await this.dialogService.ShowConfirmationAsync("Validate", "Name ?");
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
