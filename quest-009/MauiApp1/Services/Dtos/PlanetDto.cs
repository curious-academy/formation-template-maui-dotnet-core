namespace Services.Dtos
{
    internal class PlanetDto
    {
        #region Properties
        public string? Name { get; set; }
        #endregion
    }

    internal class PlanetsDtoResult
    {
        public PlanetDto[]? Results { get; set; }
    }
}
