namespace DinnerStore.Infrastructure.Authentication
{
	public class JwtSettings
	{
		public const string SectionName = "JwtSettings";
		public string Secret { get; init; } = string.Empty;
		public int ExpirationTimeInMinutes { get; set; }
		public string Issuer { get; init; } = string.Empty;
		public string Audience { get; init; } = string.Empty;
	}
}
