using Identity.Api.Helpers;
using Identity.Domain;
using Identity.Domain.Entities;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly ITokenService tokenService;
        private readonly IUserTokenService userTokenService;
        private readonly IUserService userService;
        private readonly JwtConfig jwtConfig;

        public EmployeeController(IEmployeeService employeeService, ITokenService tokenService, IUserTokenService userTokenService, IOptions<JwtConfig> jwtConfig, IUserService userService)
        {
            this.employeeService = employeeService;
            this.tokenService = tokenService;
            this.userTokenService = userTokenService;
            this.userService = userService;
            this.jwtConfig = jwtConfig.Value;
        }

        [HttpPost]
        public async Task<IActionResult> LoginEmployee (LoginEmployeeModel model)
        {
            try
            {
                var user = await employeeService.GetEmployee(model);

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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public Task AddEmployee (AddEmployeeModel model)
        {
            return employeeService.AddEmployee(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public Task<IdentityResult> ChangeUserPassword (ChangePasswordModel model)
        {
            return userService.ChangePassword(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public Task<EmployeeViewModel[]> GetEmployees (string? username)
        {
            return employeeService.GetEmployeeList(username);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public Task ChangeUserDisablePosition (string userId, bool value)
        {
            return employeeService.ChangeUserDisablePosition(userId, value);
        }
    }
}
