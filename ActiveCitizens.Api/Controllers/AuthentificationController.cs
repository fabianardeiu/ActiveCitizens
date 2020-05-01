using ActiveCitizens.Core.DTOs;
using ActiveCitizens.Core.Interfaces;
using ActiveCitizens.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActiveCitizens.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificationController : Controller
    {
        private IAuthentificationService _authService;

        public AuthentificationController(IAuthentificationService authentificationService)
        {
            _authService = authentificationService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDto userDto)
        {
            User user = new User
            {
                Username = userDto.Username,
                Password = userDto.Password
            };

            var citizen = _authService.Login(user);
            return Ok(citizen);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserDto registerUserDto)
        {
            _authService.Register(registerUserDto);
            return Ok();
        }
    }
}
