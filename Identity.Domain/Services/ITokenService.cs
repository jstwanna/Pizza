using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Services
{
    public interface ITokenService
    {
        public string GenerateJwtToken (Claim[] claims);

        public string GenerateRefreshToken ();
    }
}
