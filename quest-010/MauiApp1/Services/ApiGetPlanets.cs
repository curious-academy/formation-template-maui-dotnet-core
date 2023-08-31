using AllModels.Planets;
using Interfaces;
using Services.Dtos;
using System.Text.Json;

namespace Services
{
    public class ApiGetPlanets : IGetPlanets
    {
        #region Fields
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions jsonSerializerOptions;
        #endregion

        #region Constructors
        public ApiGetPlanets()
        {
            this.httpClient = new HttpClient();
            this.jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        #endregion

        #region Public methods
        public async Task<IEnumerable<Planet>> GetAll()
        {
            IEnumerable<Planet>? planets = null;
            Uri uri = new Uri("https://swapi.dev/api/planets");
            var result = await this.httpClient.GetAsync(uri);

            if (result != null)
            {
                var content = await result.Content.ReadAsStringAsync();
                var planetsResult = JsonSerializer.Deserialize<PlanetsDtoResult>(content, this.jsonSerializerOptions);

                if (planetsResult?.Results != null)
                {
                    planets = planetsResult.Results.Select(item => new Planet(0, item.Name!, ""));
                }
            }

            return planets;
        }
        #endregion
    }
}
