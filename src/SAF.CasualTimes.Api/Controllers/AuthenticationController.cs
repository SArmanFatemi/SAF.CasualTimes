using Microsoft.AspNetCore.Mvc;
using SAF.CasualTimes.Application.Services.Authentication;
using SAF.CasualTimes.Contracts.Authentication;

namespace SAF.CasualTimes.Api.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthenticationController : ControllerBase
{
	[HttpPost("register")]
	public IActionResult Register(
		[FromServices] IAuthenticationService authenticationService, 
		RegisterRequest request)
	{
		var authResult = authenticationService.Register(request.FirstName, request.LastNamem, request.Email, request.Password);

		var response = new AuthenticationResponse(
			authResult.Id,
			authResult.FirstName,
			authResult.LastNamem,
			authResult.Email,
			authResult.Token
		);

		return Ok(response);
	}

	[HttpPost("login")]
	public IActionResult Login(
		[FromServices] IAuthenticationService authenticationService,
		LoginRequest request)
	{
		var authResult = authenticationService.Login(request.Email, request.Password);

		var response = new AuthenticationResponse(
			authResult.Id,
			authResult.FirstName,
			authResult.LastNamem,
			authResult.Email,
			authResult.Token
		);

		return Ok(response);
	}
}
