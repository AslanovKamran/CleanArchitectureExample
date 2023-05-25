using DinnerStore.Domain.Entities;

namespace DinnerStore.Application.Common.Interfaces.Authentication
{
	public interface IJwtTokenGenerator
	{
		string GenerateToken(User user);
	}
}
