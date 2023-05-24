
using DinnerStore.Application.Common.Interfaces.Services;

namespace DinnerStore.Infrastructure.Services
{
	public class DateTimeProvider : IDateTimeProvider
	{
		public DateTime UtcNow => DateTime.UtcNow;
	}
}
