using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Proyecto.Models
{
    public class UrlForCreationDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string NormalUrl { get; set; }

        public string ShortUrl { get; set; }

    }
}
