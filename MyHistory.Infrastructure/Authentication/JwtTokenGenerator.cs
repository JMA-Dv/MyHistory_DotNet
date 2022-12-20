using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyHistory.Application.Common.Interfaces.Authentication;
using MyHistory.Application.Common.Interfaces.Services;
using MyHistory.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyHistory.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateProvider;
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGenerator(IDateTimeProvider dateProvider, IOptions<JwtSettings> jwtSettings)
        {
            _dateProvider = dateProvider;
            _jwtSettings = jwtSettings.Value;
        }


        public string GenerateToken(User user)
        {
            var credentials = new SigningCredentials
                (new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti,  Guid.NewGuid().ToString()),
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                expires: _dateProvider.UtcNow.AddMinutes(_jwtSettings.Expires),
                claims: claims,
                signingCredentials: credentials
                );


            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
