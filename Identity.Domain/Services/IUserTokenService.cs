using Identity.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Services
{
    public interface IUserTokenService
    {
        public Task<AppUser?> GetUserByRefreshToken(string refreshToken);

        public Task<IdentityResult> SetRefreshToken (AppUser user, string refreshToken);

        public Task<IdentityResult> RemoveRefreshToken (AppUser user);
    }
}
