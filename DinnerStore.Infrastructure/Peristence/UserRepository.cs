using DinnerStore.Application.Common.Interfaces.Persistence;
using DinnerStore.Domain.Entities;

namespace DinnerStore.Infrastructure.Peristence
{
	public class UserRepository : IUserRepository
	{
		private static readonly List<User> _users = new();

		public void Add(User user)
		{
			if(user is not null) _users.Add(user);
		}

		public User? GetUserByEmail(string email)
		{
			return _users.SingleOrDefault(u => u.Email == email);
			
		}
	}
}
