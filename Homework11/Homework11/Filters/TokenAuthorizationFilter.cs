using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Homework11.Filters
{
    public class TokenAuthorizationFilter : IAuthorizationFilter
    {
        private readonly IConfiguration _configuration;

        public TokenAuthorizationFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Path.StartsWithSegments(new PathString("/User/Login")))
            {
                return;
            }

            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                return;
            }

            var myIssuer = _configuration["JwtIssuer"];

            var mySecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = context.HttpContext.Request.Headers["Authorization"].ToString().Substring("Bearer ".Length);

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = myIssuer,
                ValidAudience = myIssuer,
                IssuerSigningKey = mySecurityKey
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            if (jwtToken.Header.Alg == "HS256" && jwtToken.Payload.Iss == myIssuer)
            {
                context.Result = new OkResult();
                return;
            }

            context.Result = new UnauthorizedResult();
        }
    }
}
