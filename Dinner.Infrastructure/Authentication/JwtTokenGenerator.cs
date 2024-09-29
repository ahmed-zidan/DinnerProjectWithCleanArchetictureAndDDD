using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dinner.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJWTTokenGenerator
    {
        private readonly SymmetricSecurityKey key;
        private readonly JwtSettings _jwtSetting;

        public JwtTokenGenerator(IOptions<JwtSettings> options)
        {
            _jwtSetting = options.Value;
            key = new SymmetricSecurityKey(Encoding.UTF8
                   .GetBytes(_jwtSetting.JwtKey));
           
        }
        public string GenerateToken(AppUser user)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.NameId , user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName , user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName , user.LastName)
            };

            var signingCredintiels = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature
               );

            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(_jwtSetting.ExpiresInDays),
                SigningCredentials = signingCredintiels,
                Issuer = _jwtSetting.Issuer,
                Audience = _jwtSetting.Audience
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);

        }
    }
}
