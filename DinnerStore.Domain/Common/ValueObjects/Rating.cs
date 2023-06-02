using DinnerStore.Domain.Common.Models;

namespace DinnerStore.Domain.Common.ValueObjects
{
	public sealed class Rating : ValueObject
	{
		public double Value { get; private set; }

		private Rating(double value) => Value = value;

		public static Rating Create(double value = 0) => new(value);

		public override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}
