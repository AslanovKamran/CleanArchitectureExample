using System.ComponentModel.DataAnnotations;

namespace DinnerStore.Contracts.Authentication
{
	public record RegisterRequest(
		[Required(AllowEmptyStrings =false)]
		string FirstName,
		[Required(AllowEmptyStrings =false)]
		string LastName,
		[Required(AllowEmptyStrings =false)]
		string Email,
		[Required(AllowEmptyStrings =false)]
		string Password
		);
}