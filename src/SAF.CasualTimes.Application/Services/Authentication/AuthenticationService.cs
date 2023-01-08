namespace SAF.CasualTimes.Application.Services.Authentication;

internal class AuthenticationService : IAuthenticationService
{
	public AuthenticationResult Login(string email, string password)
	{
		// TODO: For now, this is a temporary implementtion
		return new AuthenticationResult(
			Guid.NewGuid(),
			"Sample First Name",
			"Sample Last Name",
			email,
			"Token goes here"
		);
	}

	public AuthenticationResult Register(string firstName, string lastName, string email, string password)
	{
		// TODO: For now, this is a temporary implementtion
		return new AuthenticationResult(
			Guid.NewGuid(),
			"Sample First Name",
			"Sample Last Name",
			email,
			"Token goes here"
		);
	}

}
