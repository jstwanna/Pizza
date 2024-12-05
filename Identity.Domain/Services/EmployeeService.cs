using Identity.Data;
using Identity.Data.Models;
using Identity.Domain.Entities;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Domain.Services
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly Data.DbContext dbContext;

        public EmployeeService(UserManager<AppUser> userManager, Data.DbContext dbContext)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        public async Task<AppUser> GetEmployee(LoginEmployeeModel model)
        {
            var user = await userManager.FindByNameAsync(model.Login);

            if (user == null)
            {
                throw new Exception("Неверный логин или пароль");
            }

            if (user.Disabled)
            {
                throw new Exception("Пользователь заблокирован");
            }

            var passIsValid = await userManager.CheckPasswordAsync(user, model.Password);

            if (!passIsValid)
            {
                throw new Exception("Неверный логин или пароль");
            }

            return user;
        }

        public async Task<AppUser> AddEmployee(AddEmployeeModel model)
        {
            var user = new AppUser
            {
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            var creatingResult = await userManager.CreateAsync(user, model.Password);

            if (!creatingResult.Succeeded)
            {
                throw new Exception(creatingResult.Errors.FirstOrDefault()?.Description);   
            }

            var AddToRoleResult = await userManager.AddToRoleAsync(user, model.Role);

            if (!AddToRoleResult.Succeeded)
            {
                throw new Exception(creatingResult.Errors.FirstOrDefault()?.Description);
            }

            return user;
        }

        public Task<EmployeeViewModel[]> GetEmployeeList (string? username)
        {
            var users = dbContext.Users
                .Join(dbContext.UserRoles,
                u => u.Id,
                ur => ur.UserId,
                (u, ur) => new
                {
                    u,
                    ur
                })
                .Join(dbContext.Roles,
                u => u.ur.RoleId,
                r => r.Id,
                (u, r) => new EmployeeViewModel
                {
                    Id = u.u.Id,
                    Disabled = u.u.Disabled,
                    UserName = u.u.UserName,
                    FirstName = u.u.FirstName,
                    LastName = u.u.LastName,
                    Role = r.NormalizedName
                })
                .Where(w => w.Role != "USER");

            if (username != null)
            {
                users = users.Where(w => w.UserName.Contains(username));
            }
            
            return users.ToArrayAsync();
        }

        public async Task ChangeUserDisablePosition (string userId, bool value)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("Пользователь не найден");
            }

            user.Disabled = value;

            var res = await userManager.UpdateAsync(user);

            if (!res.Succeeded)
            {
                throw new Exception(res.Errors.FirstOrDefault()?.Description);
            }
        }
    }
}
