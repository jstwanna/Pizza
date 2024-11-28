using Identity.Data;
using Identity.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Services
{
    internal class UserTokenService : IUserTokenService
    {
        private readonly Data.DbContext context;
        private readonly UserManager<AppUser> userManager;
        private readonly JwtConfig jwtConfig;

        public UserTokenService(Data.DbContext context, UserManager<AppUser> userManager, IOptions<JwtConfig> options)
        {
            this.context = context;
            this.userManager = userManager;
            this.jwtConfig = options.Value;
        }

        public Task<AppUser?> GetUserByRefreshToken (string refreshToken)
        {
            return context.Users.FirstOrDefaultAsync(w => 
                w.RefreshToken == refreshToken && 
                w.RefreshTokenExpiryTime.HasValue &&
                w.RefreshTokenExpiryTime.Value > DateTime.UtcNow);
        }

        public Task<IdentityResult> SetRefreshToken (AppUser user, string refreshToken)
        {
            var refreshTokenExpiryTime = DateTime.UtcNow.AddDays(jwtConfig.RefreshTokenLifeTimeDays);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = refreshTokenExpiryTime;

            return userManager.UpdateAsync(user);
        }

        public Task<IdentityResult> RemoveRefreshToken (AppUser user)
        {
            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = null;

            return userManager.UpdateAsync(user);
        }
    }
}
