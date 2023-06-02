using DinnerStore.Domain.Common.Models;

namespace DinnerStore.Domain.Menu.ValueObjects
{
	public sealed class MenuSectionId : ValueObject
	{
		public Guid Value { get; }

		private MenuSectionId(Guid value)
		{
			Value = value;
		}

		public static MenuSectionId GenerateUniqueMenuSectionId() 
		{
			return new MenuSectionId(Guid.NewGuid());
		}

		public override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;	
		}
	}
}
