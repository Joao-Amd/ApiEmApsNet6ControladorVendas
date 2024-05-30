using ApiControladorVendas.Dominio.AuthenticateService;
using ApiControladorVendas.Dominio.Authentications.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiControladorVendas.Api.Controllers.TokenRefresh
{
    [Route("TokenRefresh")]
    [Authorize]

    public class TokenRefreshController : Controller
    {
        private readonly IAuthTokenRefresh _tokenRefresh;

        public TokenRefreshController(IAuthTokenRefresh tokenRefresh)
        {
            _tokenRefresh = tokenRefresh;
        }

        [HttpPost]
        public ActionResult<UserTokenViewModel> TokenRefresh()
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);

                var item = _tokenRefresh.CreateRefreshToken(token);

                return new UserTokenViewModel
                {
                    Token = token
                };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
