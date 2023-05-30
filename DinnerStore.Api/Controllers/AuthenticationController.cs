using DinnerStore.Application.Authentication.Common;
using DinnerStore.Application.Authentication.Commands.Register;
using DinnerStore.Application.Authentication.Queries.Login;
using DinnerStore.Application.Common.Errors;
using DinnerStore.Contracts.Authentication;
using MapsterMapper;
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
		private readonly IMapper _mapper;

		public AuthenticationController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}


		[HttpPost]
		[Route("register")]
		public async Task<IActionResult> Register(RegisterRequest request)
		{
			var command = _mapper.Map<RegisterCommand>(request);

			OneOf<AuthenticationResult, IError> registerResult = await _mediator.Send(command);

			return registerResult.Match(
				authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
				error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage)
				);
		}



		[HttpPost]
		[Route("login")]
		public async Task<IActionResult> Login(LoginRequest request)
		{
			var query = _mapper.Map<LoginQuery>(request);
			OneOf<AuthenticationResult, IError> loginResult = await _mediator.Send(query);

			return loginResult.Match(
				authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
				error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage)
				);
		}


		

	}
}
