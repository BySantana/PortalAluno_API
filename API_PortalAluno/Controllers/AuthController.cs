using API_PortalAluno.Models;
using API_PortalAluno.Models.User;
using API_PortalAluno.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API_PortalAluno.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<UserAdmin> _userManager;
        private readonly TokenService _tokenService;
        private readonly AuthService _authService;

        public AuthController(UserManager<UserAdmin> userManager, TokenService tokenService, AuthService authService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _authService = authService;
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

                var roles = await _userManager.GetRolesAsync(user);
                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

                var token = _tokenService.GenerateToken(claims);

                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAdmin([FromBody] UserLogin model)
        {
            await _authService.CreateAccountAdminAsync(new UserLogin { Password = model.Password, UserName = model.UserName });

            return Ok(new {User = model.UserName});
        }

    }
}
