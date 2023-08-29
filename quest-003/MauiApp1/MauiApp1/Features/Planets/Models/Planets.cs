namespace MauiApp1.Features.Planets.Models
{
    public class Planets
    {
        #region Fields
        #endregion

        #region Public methods
        public Planet GetById(int id)
        {
            return this.List.First(p => p.Id == id);
        }
        #endregion

        #region Properties
        public List<Planet> List { get; } = new()
        {
            new (1, "Coruscant", "bl"),
            new (2, "Kashhyk", "bla")
        };
        #endregion
    }
}
