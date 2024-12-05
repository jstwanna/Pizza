using Identity.Data.Models;
using Identity.Domain.Entities;
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
    internal class ClientService : IClientService
    {
        private readonly UserManager<AppUser> userManager;

        public ClientService(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<AppUser> GetOrCreateClient (LoginClientModel model)
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
                    throw new Exception("Ошибка: " + creatingResult.Errors.FirstOrDefault()?.Description);
                }
                
                await userManager.AddToRoleAsync(user, "User");
            }

            return user;
        }
    }
}
