using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Proyecto.Models
{
    public class AuthenticationRequestBody
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
