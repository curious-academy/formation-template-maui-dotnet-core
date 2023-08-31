using AllModels.Planets;
using Interfaces;

namespace Services
{
    public class InMemoryGetPlanets : IGetPlanets
    {
        public Task<IEnumerable<Planet>> GetAll()
        {
            IEnumerable<Planet> result = Planets.List;

            return Task.FromResult(result);
        }
    }
}
