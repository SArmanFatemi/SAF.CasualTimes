namespace SAF.CasualTimes.Application.Services.Authentication;

public record AuthenticationResult(
	Guid Id,
	string FirstName,
	string LastNamem,
	string Email,
	string Token
);
