using DinnerStore.Application.Authentication.Commands.Register;
using DinnerStore.Application.Authentication.Common;
using DinnerStore.Application.Authentication.Queries.Login;
using DinnerStore.Application.Common.Errors;
using DinnerStore.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace DinnerStore.Api.Controllers
{
	[Route("auth")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AuthenticationController(IMediator mediator) => _mediator = mediator;

		[HttpPost]
		[Route("register")]
		public async Task<IActionResult> Register(RegisterRequest request)
		{
			var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);

			OneOf<AuthenticationResult, IError> registerResult = await _mediator.Send(command);

			return registerResult.Match(
				authResult => Ok(MapAuthResult(authResult)),
				error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage)
				);
		}



		[HttpPost]
		[Route("login")]
		public async Task<IActionResult> Login(LoginRequest request)
		{
			var query = new LoginQuery(request.Email, request.Password);
			OneOf<AuthenticationResult, IError> loginResult = await _mediator.Send(query);

			return loginResult.Match(
				authResult => Ok(MapAuthResult(authResult)),
				error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage)
				);
		}


		[NonAction]
		private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
		{
			return new AuthenticationResponse(
			authResult.User.Id,
			authResult.User.FirstName,
			authResult.User.LastName,
			authResult.User.Email,
			authResult.Token
			);
		}

	}
}
