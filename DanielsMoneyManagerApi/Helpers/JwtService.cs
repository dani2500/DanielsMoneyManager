using DanielsMoneyManagerApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DanielsMoneyManagerApi.Helpers
{
    public class JwtService
    {
        private readonly string _secureKey;

        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _secureKey = configuration["Jwt:Key"];
        }

        public string Generate(int id, out DateTime expireAt)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secureKey));

            List<Claim> userClaims = new()
            {
                new Claim(ClaimTypes.UserData, id.ToString())
            };

            expireAt = DateTime.Now.AddMinutes(2);

            var token = new JwtSecurityToken(
                claims: userClaims,
                expires: expireAt,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public int GetUserId(ClaimsPrincipal claimsPrincipal)
        {
            var claimsIdentity = claimsPrincipal.Identity as ClaimsIdentity;

            IEnumerable<Claim> claim = claimsIdentity.Claims;

            var userIdClaim = claim
                .Where(x => x.Type == ClaimTypes.UserData)
                .FirstOrDefault();

            int userId = -1;
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out userId))
            {
                //TODO log bad authentication
            }

            return userId;
        }

    }
}
