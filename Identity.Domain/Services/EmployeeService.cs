using Identity.Data.Models;
using Identity.Domain.Entities;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Services
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly UserManager<AppUser> userManager;

        public EmployeeService(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<AppUser> GetEmployee(LoginEmployeeModel model)
        {
            var user = await userManager.FindByNameAsync(model.Login);

            if (user == null)
            {
                throw new Exception("Неверный логин или пароль");
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
                UserName = model.Username
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
    }
}
