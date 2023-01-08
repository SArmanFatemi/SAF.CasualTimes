using SAF.CasualTimes.Application.Common.Interfaces.Authentication;

namespace SAF.CasualTimes.Application.Services.Authentication;

internal class AuthenticationService : IAuthenticationService
{
	private readonly IJwtTokenGenerator jwtTokenGenerator;

	public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
	{
		this.jwtTokenGenerator = jwtTokenGenerator;
	}

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
		Guid userId = Guid.NewGuid();
		string token = jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

		return new AuthenticationResult(
			userId,
			firstName,
			lastName,
			email,
			token
		);
	}

}
