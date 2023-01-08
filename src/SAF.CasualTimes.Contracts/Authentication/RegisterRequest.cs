namespace SAF.CasualTimes.Contracts.Authentication;

public record RegisterRequest(
	string FirstName,
	string LastNamem,
	string Email,
	string Password
);