using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Proyecto.Data;
using UrlShortener.Proyecto.Entities;
using UrlShortener.Proyecto.Models;
using UrlShortener.Proyecto.Services;

namespace UrlShortener.Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))!.Value);

            return Ok(_UrlShortenerService.GetAllByUser(userId));        
        }


        [HttpGet("{shortUrl}")]
        public RedirectResult GetLongUrl(string shortUrl)
        {
            Url urlDest= _UrlShortenerService.UrlRedirector(shortUrl);
            return Redirect(urlDest.NormalUrl);
        }

        [HttpDelete]
            
        public IActionResult DeleteUrl(int id)
        {
            return Ok(_UrlShortenerService.DeleteUrl(id));
        }
        [HttpPut]
        [Route("{Id}")]
        public IActionResult UpdateUrl(CreateAndUpdateUrlDto dto, int urlId)
        {
            _UrlShortenerService.Update(dto, urlId);
            return NoContent();
        }
        [HttpPost]
        public IActionResult CreateUrl(CreateAndUpdateUrlDto dto)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))!.Value);
            _UrlShortenerService.Create(dto, userId );
            return Created("Created", dto);
        }
        
    }
}
