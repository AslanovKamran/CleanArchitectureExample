using System.Net;

namespace DinnerStore.Application.Common.Errors
{
	public class DuplicateEmailError : IError
	{
		public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

		public string ErrorMessage => "One of -> Email is already exists";
	}
}
