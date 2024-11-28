using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain
{
    public class JwtConfig
    {
        public string SecretKey { get; set; }
        public int AccessTokenLifeTimeMinutes {  get; set; }
        public int RefreshTokenLifeTimeDays { get; set; }
        public string AccessTokenCookieName { get; set; }
        public string RefreshTokenCookieName { get; set; }
    }
}
