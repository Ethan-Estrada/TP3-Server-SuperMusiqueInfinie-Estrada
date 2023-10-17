using Microsoft.Build.Framework;

namespace SuperGalerieInfinie.Models
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }


    }
}
