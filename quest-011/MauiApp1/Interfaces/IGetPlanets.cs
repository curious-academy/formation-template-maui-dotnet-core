using AllModels.Planets;

namespace Interfaces
{
    public interface IGetPlanets
    {
        public Task<IEnumerable<Planet>> GetAll();
    }
}
