using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RetoLibreria.Dtos;

namespace RetoLibreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager; // el guion es un estandar que se sigue para ponerle a algo que es privado

        public AuthController(UserManager<IdentityUser> userManager) // Este codigo nos permite que lo que llegue a la inyección de dependencias pasarlo al userManager
        {
            _userManager = userManager;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] RegisterRequestDto model)
        {

            var user = new IdentityUser
            {
                UserName = model.Username,
                Email = model.Email
            };
            var result =await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("User registerly succesfully");
             }



    }
}
