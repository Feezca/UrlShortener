using Microsoft.AspNetCore.Mvc;
using UrlShortener.Proyecto.Services;

namespace UrlShortener.Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlControllers : ControllerBase
    {
        private readonly UrlShortenerService _UrlShortenerService;

        public UrlControllers( UrlShortenerService urlShortener) 
        {
            _UrlShortenerService = urlShortener;
        }

        [HttpGet("{url}")]
        public IActionResult GetUrl(string url,[FromQuery] string Url)
        {
            string UrlForDB= Url;
            string GeneratedUrl=_UrlShortenerService.UrlShortener();

            return Ok(GeneratedUrl);
        }

    }
}
