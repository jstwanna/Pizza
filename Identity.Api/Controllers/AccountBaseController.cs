using Identity.Api.Helpers;
using Identity.Domain.Entities;
using Identity.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Identity.Domain.Models;
using System.Net;
using System.Security.Claims;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountBaseController : ControllerBase
    {
        private readonly IUserTokenService userTokenService;
        private readonly ITokenService tokenService;
        private readonly IUserService userService;
        private JwtConfig jwtConfig;

        public AccountBaseController(IUserTokenService userTokenService, ITokenService tokenService, IUserService userService, IOptions<JwtConfig> options)
        {
            this.userTokenService = userTokenService;
            this.tokenService = tokenService;
            this.userService = userService;
            jwtConfig = options.Value;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout ()
        {
            HttpContext.Response.Cookies.Delete(jwtConfig.AccessTokenCookieName);

            HttpContext.Request.Cookies.TryGetValue(jwtConfig.RefreshTokenCookieName, out var refreshToken);
            if (refreshToken != null)
            {
                var user = await userTokenService.GetUserByRefreshToken(refreshToken);

                if (user != null)
                {
                    var res = await userTokenService.RemoveRefreshToken(user);

                    if (!res.Succeeded)
                    {
                        return Problem(res.Errors.FirstOrDefault()?.Description);
                    }
                }

                HttpContext.Response.Cookies.Delete(jwtConfig.RefreshTokenCookieName);
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken ()
        {
            HttpContext.Request.Cookies.TryGetValue(jwtConfig.RefreshTokenCookieName, out var refreshToken);

            if (refreshToken == null)
            {
                return Problem("Отсутствует рефреш токен");
            }

            var user = await userTokenService.GetUserByRefreshToken(refreshToken);

            if (user == null)
            {
                return Problem("Пользователь не найден");
            }

            var newRefreshToken = tokenService.GenerateRefreshToken();
            var res = await userTokenService.SetRefreshToken(user, newRefreshToken);

            if (!res.Succeeded)
            {
                return Problem(res.Errors.FirstOrDefault()?.Description);
            }

            var userClaims = await userService.GetUserClaims(user);
            var newAccessToken = tokenService.GenerateJwtToken(userClaims);

            HttpContext.SetTokensInCookie(newAccessToken, newRefreshToken, jwtConfig);

            return Ok();
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(UserInfoResponse), (int) HttpStatusCode.OK)]
        public IActionResult GetUserInfo ()
        {
            var info = new UserInfoResponse
            {
                //Id = User.FindFirstValue(ClaimTypes.Sid),
                Username = User.FindFirstValue(ClaimTypes.NameIdentifier),
                Role = User.FindFirstValue(ClaimTypes.Role)
            };

            return Ok(info);
        }
    }
}
