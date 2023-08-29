namespace MauiApp1.Features.Planets.Models
{
    public class Planets
    {
        #region Fields
        #endregion

        #region Public methods
        public Planet GetById(int id)
        {
            return List.First(p => p.Id == id);
        }

        public void Delete(Planet item)
        {
            List.Remove(item);
        }
        #endregion

        #region Properties
        public static List<Planet> List { get; } = new()
        {
            new (1, "Coruscant", "bl"),
            new (2, "Kashhyk", "bla")
        };
        #endregion
    }
}
