namespace SAF.CasualTimes.Infrastructure;

using Microsoft.Extensions.DependencyInjection;
using SAF.CasualTimes.Application.Common.Interfaces.Authentication;
using SAF.CasualTimes.Application.Common.Interfaces.Services;
using SAF.CasualTimes.Infrastructure.Authentication;
using SAF.CasualTimes.Infrastructure.Services;

public static class DependencyInjection
{
	public static IServiceCollection AddSAFInfrastructure(this IServiceCollection services)
	{
		services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
		services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

		return services;
	}
}
