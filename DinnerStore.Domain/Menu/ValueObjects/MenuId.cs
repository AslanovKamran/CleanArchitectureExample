using DinnerStore.Domain.Common.Models;

namespace DinnerStore.Domain.Menu.ValueObjects
{
	public sealed class MenuId : ValueObject
	{
		public Guid Value { get;  }
		
		private MenuId(Guid value)
		{
			Value = value;
		}

		public static MenuId GenerateUniqueMenuId() 
		{
			return new MenuId(Guid.NewGuid());
		}

		public override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;	
		}
	}
}
