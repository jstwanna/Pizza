using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Entities
{
    public interface ITokenService
    {
        public string GenerateJwtToken(Claim[] claims);

        public string GenerateRefreshToken();
    }
}
