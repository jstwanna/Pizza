using Identity.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Data
{
    public class DbContext : IdentityDbContext<AppUser>
    {
        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating (ModelBuilder builder)
        {
            var adminRoleId = Guid.NewGuid().ToString();
            var userRoleId = Guid.NewGuid().ToString();
            var employeeRoleId = Guid.NewGuid().ToString();

            builder
                .Entity<IdentityRole>()
                .HasData([
                    new IdentityRole{
                        Id = adminRoleId,
                        Name = "Admin",
                        NormalizedName = "ADMIN",
                        ConcurrencyStamp = adminRoleId,
                    },
                    new IdentityRole{
                        Id = userRoleId,
                        Name = "User",
                        NormalizedName = "USER",
                        ConcurrencyStamp = userRoleId,
                    },
                    new IdentityRole{
                        Id = employeeRoleId,
                        Name = "Employee",
                        NormalizedName = "EMPLOYEE",
                        ConcurrencyStamp = employeeRoleId,
                    }
                    ]);

            var hasher = new PasswordHasher<AppUser>();
            var admin = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                FirstName = "admin",
                LastName = "admin",
            };

            admin.PasswordHash = hasher.HashPassword(admin, "admin");

            builder
                .Entity<AppUser>()
                .HasData([
                    admin
                    ]);

            builder
                .Entity<IdentityUserRole<string>>()
                .HasData([
                    new IdentityUserRole<string>{
                        RoleId = adminRoleId,
                        UserId = admin.Id,
                    }
                ]);

            base.OnModelCreating(builder);
        }
    }
}
