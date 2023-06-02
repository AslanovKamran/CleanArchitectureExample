using DinnerStore.Domain.Common.Models;

namespace DinnerStore.Domain.Menu.ValueObjects
{
	public sealed class MenuItemId : ValueObject
	{
		public Guid Value { get; }

		private MenuItemId(Guid value)
		{
			Value = value;
		}

		public static MenuItemId GenerateUniqueMenuItemId()
		{
			return new MenuItemId(Guid.NewGuid());
		}

		public override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}
