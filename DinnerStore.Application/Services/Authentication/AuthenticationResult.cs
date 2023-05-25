using DinnerStore.Domain.Entities;

namespace DinnerStore.Application.Services.Authentication
{
	public record AuthenticationResult(
		User User,
		string Token
		);
}
