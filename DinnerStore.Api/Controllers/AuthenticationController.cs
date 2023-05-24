using DinnerStore.Application.Services.Authentication;
using DinnerStore.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

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
			var authResult = _authencticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
			var authResponse = new AuthenticationResponse
				(
				authResult.Id,
				authResult.FirstName,
				authResult.LastName,
				authResult.Email,
				authResult.Token
				);
			return Ok(authResponse);
		}

		[Route("login")]
		[HttpPost]
		public IActionResult Login(LoginRequest request)
		{
			var authResult = _authencticationService.Login(request.Email, request.Password);
			var authResponse = new AuthenticationResponse
				(
				authResult.Id,
				authResult.FirstName,
				authResult.LastName,
				authResult.Email,
				authResult.Token
				);
			return Ok(authResponse);

		}

	}
}
