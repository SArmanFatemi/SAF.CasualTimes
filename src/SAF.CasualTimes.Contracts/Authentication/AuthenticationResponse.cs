namespace SAF.CasualTimes.Contracts.Authentication;

public record AuthenticationResponse(
	Guid Id,
	string FirstName,
	string LastNamem,
	string Email,
	string Token
);