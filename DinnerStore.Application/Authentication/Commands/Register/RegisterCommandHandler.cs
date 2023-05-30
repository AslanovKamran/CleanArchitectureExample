using DinnerStore.Application.Authentication.Common;
using DinnerStore.Application.Common.Errors;
using DinnerStore.Application.Common.Interfaces.Authentication;
using DinnerStore.Application.Common.Interfaces.Persistence;
using DinnerStore.Domain.Entities;
using MediatR;
using OneOf;

namespace DinnerStore.Application.Authentication.Commands.Register
{
	public class RegisterCommandHandler : IRequestHandler<RegisterCommand, OneOf<AuthenticationResult, IError>>
	{
		private readonly IJwtTokenGenerator _jwtTokenGenerator;
		private readonly IUserRepository _userRepository;

		public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
		{
			_jwtTokenGenerator = jwtTokenGenerator;
			_userRepository = userRepository;
		}

		public async Task<OneOf<AuthenticationResult, IError>> Handle(RegisterCommand command, CancellationToken cancellationToken)
		{
			// 1. Validate the user doesn't exist
			if (_userRepository.GetUserByEmail(command.Email) is not null)
			{
				return new DuplicateEmailError();
			}

			// 2. Create a user (generate unique ID) and Persist to DB
			var user = new User(command.FirstName, command.LastName, command.Email, command.Password);
			_userRepository.Add(user);

			// 3. Create JWT Token
			var token = _jwtTokenGenerator.GenerateToken(user);
			return new AuthenticationResult(
				user,
				token);
		}
	}
}

