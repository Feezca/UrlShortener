using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Proyecto.Data;
using UrlShortener.Proyecto.Entities;
using UrlShortener.Proyecto.Models;
using UrlShortener.Proyecto.Services;

namespace UrlShortener.Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService) 
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAll());
        }

        [HttpPost]
        public IActionResult CreateUser(CreateAndUpdateUserDto dto)
        {
            try
            {
                _userService.CreateUser(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Created", dto);
        }
        [HttpPut]
        [Route("{Id}")]
        public IActionResult UpdateUser(CreateAndUpdateUserDto dto, int userId)
        {
            _userService.Update(dto, userId);
            return NoContent();
        }

        [HttpDelete]
        [Authorize]
        public IActionResult DeleteUser(int id)
        {
            User? user = _userService.GetUser(id);
            if (user is null)
            {
                return BadRequest("El cliente que intenta eliminar no existe");
            }

            if (user.Username != "Admin")
            {
                _userService.DeleteUser(id);
            }
            return NoContent();
        }
    }
}
