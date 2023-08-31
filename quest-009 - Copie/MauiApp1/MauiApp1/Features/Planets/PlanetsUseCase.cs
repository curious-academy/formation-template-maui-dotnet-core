using AllModels.Planets;
using Interfaces;

namespace MauiApp1.Features.Planets
{
    public class PlanetsUseCase
    {
        #region Constructors
        public PlanetsUseCase(IGetPlanets getPlanets)
        {
            this.GetPlanets = getPlanets;
        }
        #endregion

        #region Public methods
        public async Task<List<Planet>> GetAllAsync(string filter = "")
        {
            var result = await this.GetPlanets.GetAll();

            return result.ToList();
        }
        #endregion

        #region Properties
        public IGetPlanets GetPlanets { get; init; }
        #endregion
    }
}
