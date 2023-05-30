using DinnerStore.Application.Authentication.Common;
using DinnerStore.Application.Common.Errors;
using MediatR;
using OneOf;

namespace DinnerStore.Application.Authentication.Queries.Login
{
	public record LoginQuery(string Email,
							   string Password) : IRequest<OneOf<AuthenticationResult, IError>>;
}
