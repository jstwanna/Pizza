using Identity.Data.Models;
using Identity.Domain.Entities;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Services
{
    internal class UserService : IUserService
    {
        private readonly UserManager<AppUser> userManager;

        public UserService (UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IdentityResult> ChangePassword (ChangePasswordModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                throw new Exception("Пользователь не найден");
            }

            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            return await userManager.ResetPasswordAsync(user, token, model.Password);
        }

        public async Task<Claim[]> GetUserClaims (AppUser user)
        {
            var role = (await userManager.GetRolesAsync(user)).FirstOrDefault();

            return new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, role),
            };
        }
    }
}
