using Identity.Api.Helpers;
using Identity.Data.Models;
using Identity.Domain;
using Identity.Domain.Entities;
using Identity.Domain.Models;
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
    public class ClientAccountController : ControllerBase
    {
        private readonly IClientService clientService;
        private readonly ITokenService tokenService;
        private readonly IUserTokenService userTokenService;
        private readonly IUserService userService;
        private readonly JwtConfig jwtConfig;

        public ClientAccountController(IClientService clientService, ITokenService tokenService, IOptions<JwtConfig> jwtConfig, IUserTokenService userTokenService, IUserService userService)
        {
            this.clientService = clientService;
            this.tokenService = tokenService;
            this.userTokenService = userTokenService;
            this.userService = userService;
            this.jwtConfig = jwtConfig.Value;
        }

        [HttpPost]
        public async Task<IActionResult> LoginClient (LoginClientModel model)
        {
            try
            {
                var user = await clientService.GetOrCreateClient(model);
                var claims = await userService.GetUserClaims(user);

                var accessToken = tokenService.GenerateJwtToken(claims);
                var refreshToken = tokenService.GenerateRefreshToken();

                var res = await userTokenService.SetRefreshToken(user, refreshToken);
                if (!res.Succeeded)
                {
                    return Problem(res.Errors.FirstOrDefault()?.Description);
                }

                HttpContext.SetTokensInCookie(accessToken, refreshToken, jwtConfig);

                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
