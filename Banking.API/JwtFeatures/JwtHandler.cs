﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Banking.API.JwtFeatures
{
    public class JwtHandler
    {
       
            private readonly IConfiguration _configuration;
            private readonly IConfigurationSection _jwtSettings;

            public JwtHandler(IConfiguration configuration)
            {
                _configuration = configuration;
                _jwtSettings = _configuration.GetSection("JwtSettings");
            }

            public SigningCredentials GetSigningCredentials()
            {
                var key = Encoding.UTF8.GetBytes(_jwtSettings["ApplicationSettings:JWT_Secret"]);
                var secret = new SymmetricSecurityKey(key);

                return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
            }

            public List<Claim> GetClaims(IdentityUser user)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email)
        };

                return claims;
            }

            public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
            {
                var tokenOptions = new JwtSecurityToken(
                    issuer: _jwtSettings.GetSection("validIssuer").Value,
                    audience: _jwtSettings.GetSection("validAudience").Value,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("expiryInMinutes").Value)),
                    signingCredentials: signingCredentials);

                return tokenOptions;
            }
        }
    
}
