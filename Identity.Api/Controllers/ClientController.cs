using Identity.Data.Models;
using Identity.Domain;
using Identity.Domain.Models;
using Identity.Domain.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;
using System.Security.Claims;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;
        private readonly ITokenService tokenService;
        private readonly IUserTokenService userTokenService;
        private readonly JwtConfig jwtConfig;

        public ClientController(IClientService clientService, ITokenService tokenService, IOptions<JwtConfig> jwtConfig, IUserTokenService userTokenService)
        {
            this.clientService = clientService;
            this.tokenService = tokenService;
            this.userTokenService = userTokenService;
            this.jwtConfig = jwtConfig.Value;
        }

        [HttpPost]
        public async Task<IActionResult> LoginClient (LoginClientModel model)
        {
            var user = await clientService.GetOrCreateClient(model);
            var claims = clientService.GetClaimsByClient(user);
            
            var accessToken = tokenService.GenerateJwtToken(claims);
            var refreshToken = tokenService.GenerateRefreshToken();

            var res = await userTokenService.SetRefreshToken(user, refreshToken);
            if (!res.Succeeded)
            {
                return Problem(res.Errors.FirstOrDefault()?.Description);
            }

            SetTokensInCookie(accessToken, refreshToken);

            return Ok();
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

            var userClaims = clientService.GetClaimsByClient(user);
            var newAccessToken = tokenService.GenerateJwtToken(userClaims);

            SetTokensInCookie(newAccessToken, newRefreshToken);

            return Ok();
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ClientInfoResponse), (int)HttpStatusCode.OK)]
        public IActionResult GetUserInfo ()
        {
            var info = new ClientInfoResponse
            {
                Id = User.FindFirstValue(ClaimTypes.Sid),
                Username = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            return Ok(info);
        }

        private void SetTokensInCookie(string accessToken, string refreshToken)
        {
            HttpContext.Response.Cookies.Append(jwtConfig.AccessTokenCookieName, accessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.UtcNow.AddMinutes(jwtConfig.AccessTokenLifeTimeMinutes),
                SameSite = SameSiteMode.Strict
            });

            HttpContext.Response.Cookies.Append(jwtConfig.RefreshTokenCookieName, refreshToken, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Secure = true,
                Expires = DateTime.UtcNow.AddDays(jwtConfig.RefreshTokenLifeTimeDays),
                Path = "/api/client/RefreshToken"
            });
        }
    }
}
