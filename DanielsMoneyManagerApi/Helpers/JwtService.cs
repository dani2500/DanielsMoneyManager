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
        private readonly int _lifeTimeMs;

        public JwtService(IConfiguration configuration)
        {
            _secureKey = configuration["Jwt:Key"];
            _lifeTimeMs = int.Parse(configuration["Jwt:LifeTimeMs"]);
        }

        public string Generate(int id, out int lifeTimeMs)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secureKey));

            List<Claim> userClaims = new()
            {
                new Claim(ClaimTypes.UserData, id.ToString())
            };

            lifeTimeMs = _lifeTimeMs;
            DateTime expireAt = DateTime.Now.AddMilliseconds(lifeTimeMs);

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
