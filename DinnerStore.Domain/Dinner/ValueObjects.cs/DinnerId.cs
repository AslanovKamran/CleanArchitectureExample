using DinnerStore.Domain.Common.Models;
using DinnerStore.Domain.Menu.ValueObjects;

namespace DinnerStore.Domain.Dinner.ValueObjects.cs
{
	public sealed class DinnerId : ValueObject
	{
		public Guid Value { get; }

		private DinnerId(Guid value)
		{
			Value = value;
		}

		public static DinnerId GenerateUniqueDinnerId()
		{
			return new DinnerId(Guid.NewGuid());
		}

		public override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}
