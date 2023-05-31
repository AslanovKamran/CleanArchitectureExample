using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace DinnerStore.Api
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPresentation(this IServiceCollection services)
		{

			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen(options => 
			{
				var securityScheme = new OpenApiSecurityScheme
				{
					Name = "Jwt Authentication",
					Description = "Type in a valid JWT Bearer",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Scheme = "Bearer",
					BearerFormat = "Jwt",
					Reference = new OpenApiReference
					{
						Id = JwtBearerDefaults.AuthenticationScheme,
						Type = ReferenceType.SecurityScheme
					}
				};
				options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
				options.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{securityScheme,Array.Empty<string>() }
				});
			});

			var config = TypeAdapterConfig.GlobalSettings;
			config.Scan(Assembly.GetExecutingAssembly());

			services.AddSingleton(config);
			services.AddScoped<IMapper, ServiceMapper>();


			return services;
		}
	}
}
