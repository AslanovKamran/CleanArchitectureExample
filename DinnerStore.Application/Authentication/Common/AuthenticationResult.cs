using DinnerStore.Domain.Entities;

namespace DinnerStore.Application.Authentication.Common
{
	public record AuthenticationResult(
		User User,
		string Token
		);
}
