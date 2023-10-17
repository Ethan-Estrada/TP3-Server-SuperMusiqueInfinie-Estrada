using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace SuperGalerieInfinie.Models
{
    public class User : IdentityUser
    {

        public virtual List<Galerie> Galeries { get; set; } = null!;

    }
}
