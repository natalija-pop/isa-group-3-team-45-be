﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FluentResults;
using ISAProject.Modules.Stakeholders.API.Dtos;
using ISAProject.Modules.Stakeholders.Core.Domain;
using ISAProject.Modules.Stakeholders.Core.UseCases;
using Microsoft.IdentityModel.Tokens;

namespace ISAProject.Modules.Stakeholders.Infrastructure.Security
{
    public class JwtGenerator : ITokenGenerator
    {
        private readonly string _key = Environment.GetEnvironmentVariable("JWT_KEY") ?? "explorer_secret_key";
        private readonly string _issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "explorer";
        private readonly string _audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "explorer-front.com";

        public Result<AuthenticationTokensDto> GenerateAccessToken(User user)
        {
            var authenticationResponse = new AuthenticationTokensDto();

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new("id", user.Id.ToString()),
                new("email", user.Email),
                new(ClaimTypes.Role, user.GetPrimaryRoleName())
            };

            var jwt = CreateToken(claims, 60 * 24);
            authenticationResponse.Id = user.Id;
            authenticationResponse.AccessToken = jwt;

            return authenticationResponse;
        }

        private string CreateToken(IEnumerable<Claim> claims, double expirationTimeInMinutes)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _issuer,
                _audience,
                claims,
                expires: DateTime.Now.AddMinutes(expirationTimeInMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
