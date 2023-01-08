namespace SAF.CasualTimes.Application.Services;

using Microsoft.Extensions.DependencyInjection;
using SAF.CasualTimes.Application.Services.Authentication;

public static class DependencyInjection
{
	public static IServiceCollection AddSAFApplication(this IServiceCollection services)
	{
		services.AddScoped<IAuthenticationService, AuthenticationService>();

		return services;
	}
}
