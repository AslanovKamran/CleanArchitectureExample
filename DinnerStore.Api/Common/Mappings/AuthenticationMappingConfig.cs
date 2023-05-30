using DinnerStore.Application.Authentication.Common;
using DinnerStore.Application.Authentication.Commands.Register;
using DinnerStore.Application.Authentication.Queries.Login;
using DinnerStore.Contracts.Authentication;
using Mapster;

namespace DinnerStore.Api.Common.Mappings
{
	public class AuthenticationMappingConfig : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{

			config.NewConfig<RegisterRequest, RegisterCommand>();

			config.NewConfig<LoginRequest, LoginQuery>();
			
			config.NewConfig<AuthenticationResult, AuthenticationResponse>()
				.Map(dest => dest, src => src.User);
		}
	}
}
