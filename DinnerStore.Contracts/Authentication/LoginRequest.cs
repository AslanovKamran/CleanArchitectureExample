using System.ComponentModel.DataAnnotations;

namespace DinnerStore.Contracts.Authentication
{
	public record LoginRequest(
		
		[Required(AllowEmptyStrings =false)]		
		string Email,
		
		[Required(AllowEmptyStrings =false)]
		string Password
		);
}