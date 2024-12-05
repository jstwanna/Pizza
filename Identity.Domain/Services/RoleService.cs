using Identity.Domain.Entities;
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
        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }

        public RoleManager<IdentityRole> RoleManager { get; }

        public Task<string[]> GetRolesList ()
        {
            return RoleManager.Roles
                .Where(w => w.NormalizedName != "USER")
                .Select(s => s.Name)
                .ToArrayAsync()!;
        }
    }
}
