using DinnerStore.Application.Authentication.Common;
using DinnerStore.Application.Common.Errors;
using DinnerStore.Application.Common.Interfaces.Authentication;
using DinnerStore.Application.Common.Interfaces.Persistence;
using DinnerStore.Domain.Entities;
using MediatR;
using OneOf;

namespace DinnerStore.Application.Authentication.Queries.Login
{
	public class LoginQueryHandler : IRequestHandler<LoginQuery, OneOf<AuthenticationResult, IError>>
	{
		private readonly IJwtTokenGenerator _jwtTokenGenerator;
		private readonly IUserRepository _userRepository;

		public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
		{
			_jwtTokenGenerator = jwtTokenGenerator;
			_userRepository = userRepository;
		}

		public async Task<OneOf<AuthenticationResult, IError>> Handle(LoginQuery command, CancellationToken cancellationToken)
		{
			await Task.CompletedTask;
			//1. Validate the user exists
			if (_userRepository.GetUserByEmail(command.Email) is not User user)
			{
				return new InvalidCredentialsError();
			}

			//2. Validate the password is correct 
			if (user.Password != command.Password)
			{
				return new InvalidCredentialsError();
			}

			//3. Create JWT token and return it
			var token = _jwtTokenGenerator.GenerateToken(user);
			return new AuthenticationResult(
				user,
				token);
		}
	}
}
