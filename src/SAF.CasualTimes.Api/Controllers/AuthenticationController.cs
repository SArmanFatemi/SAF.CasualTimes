using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SAF.CasualTimes.Application.Services.Authentication;
using SAF.CasualTimes.Contracts.Authentication;

namespace SAF.CasualTimes.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController : ApiController
{
	[HttpPost("register")]
	public IActionResult Register(
		[FromServices] IAuthenticationService authenticationService,
		RegisterRequest request)
	{
		ErrorOr<AuthenticationResult> authResult = authenticationService
			.Register(request.FirstName, request.LastName, request.Email, request.Password);

		return authResult.Match(authResult => Ok(MapAuthReuslt(authResult)), Problem);
	}

	[HttpPost("login")]
	public IActionResult Login(
		[FromServices] IAuthenticationService authenticationService,
		LoginRequest request)
	{
		var authResult = authenticationService.Login(request.Email, request.Password);

		return authResult.Match(authResult => Ok(MapAuthReuslt(authResult)), Problem);
	}

	private static AuthenticationResponse MapAuthReuslt(AuthenticationResult authResult)
	{
		return new(
			authResult.User.Id,
			authResult.User.FirstName,
			authResult.User.LastName,
			authResult.User.Email,
			authResult.Token
		);
	}

}
