using Identity.Data.Models;
using Identity.Domain.Entities;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Services
{
    internal class RoleService : IRoleService
    {
        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            RoleManager = roleManager;
            UserManager = userManager;
        }

        public RoleManager<IdentityRole> RoleManager { get; }
        public UserManager<AppUser> UserManager { get; }

        public Task<string[]> GetRolesList ()
        {
            return RoleManager.Roles
                .Where(w => w.NormalizedName != "USER")
                .Select(s => s.Name)
                .ToArrayAsync()!;
        }

        public async Task ChangeUserRole (ChangeUserRoleModel model)
        {
            var user = await UserManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                throw new Exception("Пользователь не найден");
            }
            var removeResult = await UserManager.RemoveFromRoleAsync(user, model.OldRole);
            if (!removeResult.Succeeded)
            {
                throw new Exception(removeResult.Errors.FirstOrDefault()?.Description);
            }

            var addRoleResult = await UserManager.AddToRoleAsync(user, model.NewRole);
            if (!addRoleResult.Succeeded)
            {
                throw new Exception(addRoleResult.Errors.FirstOrDefault()?.Description);
            }
        }
    }
}
