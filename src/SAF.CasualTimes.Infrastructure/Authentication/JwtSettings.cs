namespace SAF.CasualTimes.Infrastructure.Authentication;

internal class JwtSettings
{
	required public string Secret { get; init; }

	required public int ExpiryMinutes { get; init; }

	required public string Issuer { get; init; }

	required public string Audience { get; init; }
}
