namespace SAF.CasualTimes.Infrastructure;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SAF.CasualTimes.Application.Common.Interfaces.Authentication;
using SAF.CasualTimes.Application.Common.Interfaces.Persistence;
using SAF.CasualTimes.Application.Common.Interfaces.Services;
using SAF.CasualTimes.Infrastructure.Authentication;
using SAF.CasualTimes.Infrastructure.Persistence;
using SAF.CasualTimes.Infrastructure.Services;

public static class DependencyInjection
{
	public static IServiceCollection AddSAFInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
	{
		services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
		services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

		services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));

		services.AddScoped<IUserRepository, UserRepository>();

		return services;
	}
}
