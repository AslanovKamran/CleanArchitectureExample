using System.Net;

namespace DinnerStore.Application.Common.Errors
{
	public class InvalidCredentialsError : IError
	{
		public HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

		public string ErrorMessage => "Invalid Credentials. Check your email and password once again";
	}
}
