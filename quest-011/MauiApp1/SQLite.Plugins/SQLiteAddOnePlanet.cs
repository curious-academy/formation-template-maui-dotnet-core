using AllModels.Planets;
using Interfaces;

namespace SQLite.Plugins
{
    public class SQLiteAddOnePlanet : IAddOnePlanet
    {
        #region Fields
        private readonly SQLiteAsyncConnection connection;
        #endregion

        #region Constructors
        public SQLiteAddOnePlanet()
        {
            this.connection = new SQLiteAsyncConnection(SqliteConstants.DatabasePath);
            this.connection.CreateTableAsync<Models.PlanetDTO>();
        }
        #endregion

        #region Public methods
        public async Task<Planet> AddOneAsync(Planet item)
        {
            var dto = new Models.PlanetDTO()
            {
                Name = item.Name
            };

            await this.connection.InsertAsync(dto);
            item.Id = dto.Id;

            return item;
        }
        #endregion
    }
}
