using DinnerStore.Application.Common.Interfaces.Authentication;
using DinnerStore.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DinnerStore.Application.Common.Interfaces.Services;
using DinnerStore.Infrastructure.Services;
using DinnerStore.Application.Common.Interfaces.Persistence;
using DinnerStore.Infrastructure.Peristence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;

namespace DinnerStore.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
		{
			services.AddAuth(configuration);
			services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

			services.AddScoped<IUserRepository, UserRepository>();

			return services;
		}

		public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
		{
			JwtSettings JwtSettings = new();
			configuration.Bind(JwtSettings.SectionName, JwtSettings);

			services.AddSingleton(Options.Create(JwtSettings));
			services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();


			services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options => 
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateIssuerSigningKey = true,
						ValidateLifetime = true,

						ValidIssuer = JwtSettings.Issuer,
						ValidAudience = JwtSettings.Audience,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.Secret)),
					};
				});
			return services;
		}
	}
}
