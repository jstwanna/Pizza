using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Services
{
    public interface IUserService
    {
        public Task<string> GetClientToken (LoginClientModel model);
    }
}
