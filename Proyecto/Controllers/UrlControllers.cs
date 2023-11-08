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

            //otra manera puede ser :  
            // var urls = _UrlShortenerContext.Urls
            //     .Include(u=>u.Categories)
            //     .Include(u => u.User).toList();


            var listUrl = _UrlShortenerContext.Urls.ToList(); 
            return Ok(listUrl);        
        }

        [HttpGet("{shortUrl}")]
        public RedirectResult GetLongUrl(string shortUrl)
        {
            Url urlDest= _UrlShortenerService.UrlRedirector(shortUrl);
            return Redirect(urlDest.NormalUrl);
        }

        [HttpDelete]
        [Authorize]
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
        [Authorize]
        public IActionResult CreateUrl(CreateAndUpdateUrlDto dto)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))!.Value);
            
            try
            {
                _UrlShortenerService.Create(dto, userId );
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Created", dto);
        }
        
    }
}
