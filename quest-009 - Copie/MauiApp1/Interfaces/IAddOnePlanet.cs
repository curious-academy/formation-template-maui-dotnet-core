using AllModels.Planets;

namespace Interfaces
{
    public interface IAddOnePlanet
    {
        Task<Planet> AddOneAsync(Planet item);
    }
}
