﻿using AllModels.Planets;
using Interfaces;

namespace MauiApp1.Features.Planets
{
    public class PlanetsUseCase
    {
        #region Constructors
        public PlanetsUseCase(IGetPlanets getPlanets, IAddOnePlanet addOnePlanet)
        {
            this.GetPlanets = getPlanets;
            this.AddOnePlanet = addOnePlanet;
        }
        #endregion

        #region Public methods
        public async Task<List<Planet>> GetAllAsync(string filter = "")
        {
            var result = await this.GetPlanets.GetAll();

            return result.ToList();
        }

        public async Task<Planet> SaveOne(Planet item)
        {
            return await this.AddOnePlanet.AddOneAsync(item);
        }
        #endregion

        #region Properties
        public IGetPlanets GetPlanets { get; init; }

        public IAddOnePlanet AddOnePlanet { get; init; }
        #endregion
    }
}
