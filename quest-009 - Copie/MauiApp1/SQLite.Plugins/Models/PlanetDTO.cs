using System.ComponentModel.DataAnnotations;

namespace SQLite.Plugins.Models
{
    internal class PlanetDTO
    {
        #region Properties
        [Required]
        [PrimaryKey]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        #endregion
    }
}
