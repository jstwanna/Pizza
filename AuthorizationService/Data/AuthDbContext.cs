using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationService.Data
{
    public class AuthDbContext : IdentityDbContext<IdentityUser>
    {
        AuthDbContext(DbContextOptions<AuthDbContext> options) 
            : base(options) { }
    }
}
