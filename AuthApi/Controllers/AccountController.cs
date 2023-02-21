using JwtAuthManager;
using JwtAuthManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandler;

        public AccountController(JwtTokenHandler jwtTokenHandler )
        {
            _jwtTokenHandler = jwtTokenHandler;
        }
        [HttpPost]
        public ActionResult<AuthResponse?> Authenticate(AuthRequest request)
        {
            var authResponse = _jwtTokenHandler.GenerateJwtToken(request);
            if(authResponse == null ) return Unauthorized();
            return authResponse;
        }

    }
}
