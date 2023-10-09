using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Proyecto.Data;
using UrlShortener.Proyecto.Entities;
using UrlShortener.Proyecto.Services;

namespace UrlShortener.Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlControllers : ControllerBase
    {
        private readonly UrlShortenerService _UrlShortenerService;
        private readonly UrlShortenerContext _UrlShortenerContext;
        public UrlControllers(UrlShortenerService urlShortener, UrlShortenerContext urlShortenerContext)
        {
            _UrlShortenerService = urlShortener;
            _UrlShortenerContext = urlShortenerContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listUrl = _UrlShortenerContext.Urls.ToListAsync(); 
            return Ok(listUrl);        
        }

        [HttpPost]
        public async Task<ActionResult<List<Url>>> AddUrl(Url NewUrl, [FromQuery] string url)
        {
            if (NewUrl != null) 
            {
                NewUrl.NormalUrl = url;
                NewUrl.ShortUrl = _UrlShortenerService.UrlShortener(8);
                _UrlShortenerContext.Urls.Add(NewUrl);
                await _UrlShortenerContext.SaveChangesAsync();
                var urls= await _UrlShortenerContext.Urls.ToListAsync();
                return Ok(urls);
            }
            return BadRequest();
        }
     }
}
