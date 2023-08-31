namespace AllModels.Planets
{
    public class Planet
    {
        #region Constructors
        public Planet(int id, string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this.Id = id;
        }
        #endregion

        #region Public methods
        public void Set(string name)
        {
            this.Name = name;
        }
        #endregion

        #region Properties        
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        #endregion
    }
}
