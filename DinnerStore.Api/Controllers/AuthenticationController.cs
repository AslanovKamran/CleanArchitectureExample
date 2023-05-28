using DinnerStore.Application.Common.Errors;
using DinnerStore.Application.Services.Authentication;
using DinnerStore.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace DinnerStore.Api.Controllers
{
	[Route("auth")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{

		private readonly IAuthenticationService _authencticationService;
		public AuthenticationController(IAuthenticationService authencticationService)
		{
			_authencticationService = authencticationService;
		}

		[Route("register")]
		[HttpPost]
		public IActionResult Register(RegisterRequest request)
		{
			OneOf<AuthenticationResult, IError> registerResult =
				_authencticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

			return registerResult.Match(
				authResult => Ok(MapAuthResult(authResult)),
				error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage)
				);
		}



		[Route("login")]
		[HttpPost]
		public IActionResult Login(LoginRequest request)
		{
			OneOf<AuthenticationResult, IError> loginResult = _authencticationService.Login(request.Email, request.Password);

			return loginResult.Match(
				authResult => Ok(MapAuthResult(authResult)),
				error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage)
				);
		}

		private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
		{
			return new AuthenticationResponse
								(
								authResult.User.Id,
								authResult.User.FirstName,
								authResult.User.LastName,
								authResult.User.Email,
								authResult.Token
								);
		}

	}
}
