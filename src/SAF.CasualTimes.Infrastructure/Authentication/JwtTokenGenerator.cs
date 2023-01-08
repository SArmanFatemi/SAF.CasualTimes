namespace SAF.CasualTimes.Infrastructure.Authentication;

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

	public JwtTokenGenerator(IDateTimeProvider dateTimeProvider)
	{
		this.dateTimeProvider = dateTimeProvider;
	}

	public string GenerateToken(Guid userId, string firstName, string lastName)
	{
		var signingCredentials = new SigningCredentials(
			new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key")),
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
			issuer: "Casual Times",
			expires: dateTimeProvider.UtcNow.AddDays(1),
			claims: claims,
			signingCredentials: signingCredentials);

		return new JwtSecurityTokenHandler().WriteToken(securityToken);
	}
}
