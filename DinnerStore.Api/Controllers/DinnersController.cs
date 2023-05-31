using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DinnerStore.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DinnersController : ControllerBase
	{
		[HttpGet]
		[Authorize]
		public IActionResult ListDinners() 
		{
			return Ok(Array.Empty<string>());
		}
	}
}
