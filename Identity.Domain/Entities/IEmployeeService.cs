using Identity.Data.Models;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Entities
{
    public interface IEmployeeService
    {
        Task<AppUser> GetEmployee(LoginEmployeeModel model);

        Task<AppUser> AddEmployee (AddEmployeeModel model);

        public Task<EmployeeViewModel[]> GetEmployeeList (string? username);
    }
}
