using System.ComponentModel.DataAnnotations;
using UrlShortener.Proyecto.Entities;

namespace UrlShortener.Proyecto.Models
{
    public class CreateAndUpdateUrlDto
    {
        [Required]
        public string Url { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public User? User { get; set; } 

    }
}
