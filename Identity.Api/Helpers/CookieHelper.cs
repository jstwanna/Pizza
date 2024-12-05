using Identity.Domain;

namespace Identity.Api.Helpers
{
    public static class CookieHelper
    {
        public static void SetTokensInCookie (this HttpContext context, string accessToken, string refreshToken, JwtConfig jwtConfig)
        {
            context.Response.Cookies.Append(jwtConfig.AccessTokenCookieName, accessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.UtcNow.AddMinutes(jwtConfig.AccessTokenLifeTimeMinutes),
                SameSite = SameSiteMode.Strict
            });

            context.Response.Cookies.Append(jwtConfig.RefreshTokenCookieName, refreshToken, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Secure = true,
                Expires = DateTime.UtcNow.AddDays(jwtConfig.RefreshTokenLifeTimeDays),
                Path = "/api/employee/RefreshToken"
            });
        }
    }
}
