using ApiControladorVendas.Aplicacao.Usuarios.Dtos;
using ApiControladorVendas.Dominio.Usuarios;
using ApiControladorVendas.Dominio.Usuarios.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiControladorVendas.Api.Controllers.Login
{
    [Route("Autorizacao")]
    [ApiController]
    public class AutorizationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AutorizationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "AutorizaController :: Acessado em :"
            + DateTime.Now.ToLongDateString();
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] UserDto dto)
        {
            var user = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _signInManager.SignInAsync(user, false);

            return Ok();

        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Email,
                dto.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login Inválido...");
                return BadRequest(ModelState);
            }
        }
    }
}
