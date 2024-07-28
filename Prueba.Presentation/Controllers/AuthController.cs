using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using PruebaApi.DTO.Response;

namespace Prueba.Presentation.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        private static readonly AuthenticationProperties COOKIE_EXPIRES = new AuthenticationProperties()
        {
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            IsPersistent = true,
        };

        [HttpPost]
        [Route("api/auth/signin")]
        public async Task<ActionResult> SignInPost(SigninData value)
        {
            if (HttpContext.User.Identity.IsAuthenticated && HttpContext.Request.Cookies.ContainsKey("myauth"))
            {
                return this.Ok();
            }
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, value.User),
                    new Claim(ClaimTypes.Name,  value.User),
                    new Claim(ClaimTypes.Role,  "Administrator"),
                };

            var claimsIdentity = new ClaimsIdentity(claims,
                                                    CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = COOKIE_EXPIRES;

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                          new ClaimsPrincipal(claimsIdentity),
                                          authProperties);

            return this.Ok();
        }
        [HttpPost("api/auth/IsAuthenticated")]
        public IActionResult IsAuthenticated()
        {
            return Ok(HttpContext.User.Identity.IsAuthenticated);
        }

        [HttpPost]
        [Route("api/auth/getclaims")]
        public async Task<IActionResult> GetClaims()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    var userName = User.Identity.Name;

            //}
            var user = HttpContext.User;
            if (user.Claims.Any())
            {
                LoginResponse response = new LoginResponse()
                {
                    Usuario1 = user.FindFirst(ClaimTypes.Name).Value,
                };
                return this.Ok(response);
            }
            return this.BadRequest();
        }

        [HttpPost]
        [Route("api/auth/signout")]
        public async Task<ActionResult> SignOutPost()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return this.Ok();
        }

        public class SigninData
        {
            public string User { get; set; }
            public string Password { get; set; }
        }
    }
}
