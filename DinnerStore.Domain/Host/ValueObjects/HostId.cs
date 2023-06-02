using DinnerStore.Domain.Common.Models;
using DinnerStore.Domain.Menu.ValueObjects;

namespace DinnerStore.Domain.Host.ValueObjects
{
	public sealed class HostId : ValueObject
	{
		public Guid Value { get; }

		private HostId(Guid value)
		{
			Value = value;
		}

		public static HostId GenerateUniqueHostId()
		{
			return new HostId(Guid.NewGuid());
		}

		public override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}
