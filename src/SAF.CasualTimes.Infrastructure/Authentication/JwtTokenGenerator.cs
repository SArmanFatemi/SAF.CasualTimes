namespace SAF.CasualTimes.Infrastructure.Authentication;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SAF.CasualTimes.Application.Common.Interfaces.Authentication;
using SAF.CasualTimes.Application.Common.Interfaces.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


internal class JwtTokenGenerator : IJwtTokenGenerator
{
	private readonly IDateTimeProvider dateTimeProvider;
	private readonly JwtSettings jwtSettings;

	public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
	{
		this.dateTimeProvider = dateTimeProvider;
		this.jwtSettings = jwtSettings.Value;
	}

	public string GenerateToken(Guid userId, string firstName, string lastName)
	{
		var signingCredentials = new SigningCredentials(
			new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
			SecurityAlgorithms.HmacSha256
		);

		var claims = new[]
		{
			new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
			new Claim(JwtRegisteredClaimNames.GivenName, firstName),
			new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
		};

		var securityToken = new JwtSecurityToken(
			issuer: jwtSettings.Issuer,
			audience: jwtSettings.Audience,
			expires: dateTimeProvider.UtcNow.AddMinutes(jwtSettings.ExpiryMinutes),
			claims: claims,
			signingCredentials: signingCredentials);

		return new JwtSecurityTokenHandler().WriteToken(securityToken);
	}
}
