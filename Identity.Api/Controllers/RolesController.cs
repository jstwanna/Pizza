using Identity.Domain.Entities;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RolesController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpPost]
        public Task<string[]> GetEmployeeRoles ()
        {
            return roleService.GetRolesList();
        }

        [HttpPost]
        public Task ChangeRole (ChangeUserRoleModel model)
        {
            return roleService.ChangeUserRole(model);
        }
    }
}
