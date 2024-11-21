using Identity.Domain.Models;
using Identity.Domain.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task LoginClient (LoginClientModel model)
        {
            var token = await userService.GetClientToken(model);
            HttpContext.Response.Cookies.Append("access-token", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.UtcNow.AddDays(7),
                SameSite = SameSiteMode.Strict
            });

            var userData = token.Split('.')[1];
            HttpContext.Response.Cookies.Append("user", userData);
        }

        [HttpPost]
        public async Task Logout ()
        {
            HttpContext.Response.Cookies.Delete("access-token");
        }

        [HttpGet]
        [Authorize]
        public string TestAuth ()
        {
            return "Ok";
        }
    }
}
