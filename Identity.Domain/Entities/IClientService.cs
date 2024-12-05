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
    public interface IClientService
    {
        public Task<AppUser> GetOrCreateClient(LoginClientModel model);
    }
}
