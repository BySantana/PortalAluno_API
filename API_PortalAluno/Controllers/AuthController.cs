using API_PortalAluno.Models.User;
using API_PortalAluno.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_PortalAluno.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<UserAdmin> _userManager;
        private readonly TokenService _tokenService;

        public AuthController(UserManager<UserAdmin> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLogin model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
            };

                var token = _tokenService.GenerateToken(claims);

                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
