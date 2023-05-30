using DinnerStore.Application.Authentication.Common;
using DinnerStore.Application.Common.Errors;
using MediatR;
using OneOf;

namespace DinnerStore.Application.Authentication.Commands.Register
{

	public record RegisterCommand(string FirstName,
							   string LastName,
							   string Email,
							   string Password) : IRequest<OneOf<AuthenticationResult, IError>>;

}
