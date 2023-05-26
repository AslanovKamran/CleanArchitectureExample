
using DinnerStore.Application.Common.Interfaces.Authentication;
using DinnerStore.Application.Common.Interfaces.Persistence;
using DinnerStore.Domain.Entities;

namespace DinnerStore.Application.Services.Authentication
{
	public class AuthenticationService : IAuthenticationService
	{
		private readonly IJwtTokenGenerator _jwtTokenGenerator;
		private readonly IUserRepository _userRepository;
		public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
		{
			_jwtTokenGenerator = jwtTokenGenerator;
			_userRepository = userRepository;
		}

		public AuthenticationResult Login(string email, string password)
		{
			//1. Validate the user exists
			if (_userRepository.GetUserByEmail(email) is not User user) 
			{
				throw new Exception(message: "User with this email doesn't exists");
			}

			//2. Validate the password is correct 
			if (user.Password != password) 
			{
				throw new Exception(message: "Invalid Password");
			}

			//3. Create JWT token and return it
			var token = _jwtTokenGenerator.GenerateToken(user);
			return new AuthenticationResult(
				user,
				token);
		}

		public AuthenticationResult Register(string firstName, string lastName, string email, string password)
		{
			// 1. Validate the user doesn't exist
			if (_userRepository.GetUserByEmail(email) is not null) 
			{
				throw new Exception(message: "User with this email already exists");
			}

			// 2. Create a user (generate unique ID) and Persist to DB
			var user = new User(firstName, lastName, email, password);
			_userRepository.Add(user);

			// 3. Create JWT Token
			var token = _jwtTokenGenerator.GenerateToken(user);
			return new AuthenticationResult(
				user,
				token);
		}
	}
}
