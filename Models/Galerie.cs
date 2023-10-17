using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SuperGalerieInfinie.Models
{
    public class Galerie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool Publique { get; set; }

        [JsonIgnore]
        public virtual List<User>? Utilisateurs { get; set; }

    }
}
