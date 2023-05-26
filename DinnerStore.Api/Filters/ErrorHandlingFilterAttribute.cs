using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace DinnerStore.Api.Filters
{
	public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			if (context.Exception is null) return;

			var problemDetails = new ProblemDetails()
			{
				Title = "An error occured while processing your request",
				Instance = context.HttpContext.Request.Path,
				Status = (int)HttpStatusCode.InternalServerError, //500
				Detail = context.Exception.Message
			};

			context.Result = new ObjectResult(problemDetails);
			context.ExceptionHandled = true;
		}
	}
}
