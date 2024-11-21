using Identity.Data.Models;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Services
{
    internal class UserService : IUserService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly JwtConfig jwtConfig;

        public UserService(UserManager<AppUser> userManager, IOptions<JwtConfig> jwtConfig)
        {
            this.userManager = userManager;
            this.jwtConfig = jwtConfig.Value;
        }

        public async Task<string> GetClientToken (LoginClientModel model)
        {
            var user = await userManager.FindByNameAsync(model.Phone);
            if (user == null)
            {
                user = new AppUser
                {
                    UserName = model.Phone
                };

                var creatingResult = await userManager.CreateAsync(user);
                if (!creatingResult.Succeeded)
                {
                    throw new Exception("Ошибки при создании пользователя");
                }
            }

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken (AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(jwtConfig.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id",user.Id)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
