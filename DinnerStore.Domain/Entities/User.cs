

namespace DinnerStore.Domain.Entities
{
	public class User
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;

		public User() { }

		public User(string firstName, string lastName, string email, string password)
		{
			Guid.NewGuid();
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			Password = password;
		}
	}
}
