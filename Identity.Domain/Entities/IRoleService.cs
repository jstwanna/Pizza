using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Entities
{
    public interface IRoleService
    {
        public Task<string[]> GetRolesList ();

        public Task ChangeUserRole (ChangeUserRoleModel model);
    }
}
