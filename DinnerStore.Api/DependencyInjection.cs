using Mapster;
using MapsterMapper;
using System.Reflection;

namespace DinnerStore.Api
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPresentation(this IServiceCollection services)
		{

			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

			var config = TypeAdapterConfig.GlobalSettings;
			config.Scan(Assembly.GetExecutingAssembly());

			services.AddSingleton(config);
			services.AddScoped<IMapper, ServiceMapper>();


			return services;
		}
	}
}
