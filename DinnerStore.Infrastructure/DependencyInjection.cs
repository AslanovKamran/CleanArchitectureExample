using DinnerStore.Application.Common.Interfaces.Authentication;
using DinnerStore.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DinnerStore.Application.Common.Interfaces.Services;
using DinnerStore.Infrastructure.Services;

namespace DinnerStore.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
		{
			services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

			services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
			services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
			return services;
		}
	}
}
