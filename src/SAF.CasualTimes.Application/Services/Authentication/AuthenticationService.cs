using SAF.CasualTimes.Application.Common.Interfaces.Authentication;
using SAF.CasualTimes.Application.Common.Interfaces.Persistence;
using SAF.CasualTimes.Domain.Entities;

namespace SAF.CasualTimes.Application.Services.Authentication;

internal class AuthenticationService : IAuthenticationService
{
	private readonly IJwtTokenGenerator jwtTokenGenerator;
	private readonly IUserRepository userRepository;

	public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
	{
		this.jwtTokenGenerator = jwtTokenGenerator;
		this.userRepository = userRepository;
	}

	public AuthenticationResult Login(string email, string password)
	{
		// 1. Validate the user exist
		if (userRepository.GetUserByEmail(email) is not User user)
		{
			throw new Exception("User with given email does not exists");
		}

		// 2. Validate the password is correct
		if (user.Password != password)
		{
			throw new Exception("Invalid password");
		}

		// 3. Create JWT token
		string token = jwtTokenGenerator.GenerateToken(user);

		return new AuthenticationResult(user, token);
	}

	public AuthenticationResult Register(string firstName, string lastName, string email, string password)
	{
		// 1. Validate user does not exist
		if (userRepository.GetUserByEmail(email) is not null)
		{
			throw new Exception("User with given email already exist");
		}

		// 2. Create user (generate unique ID) & Persist to DB

		User user = new() { FirstName = firstName, LastName = lastName, Email = email, Password = password };
		userRepository.Add(user);

		// 3. Create JWT token
		string token = jwtTokenGenerator.GenerateToken(user);

		return new AuthenticationResult(user, token);
	}

}
