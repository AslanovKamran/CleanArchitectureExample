using DinnerStore.Domain.Common.Models;
using DinnerStore.Domain.Menu.ValueObjects;

namespace DinnerStore.Domain.Menu.Entities
{
	public sealed class MenuItem : Entity<MenuItemId>
	{

		public string Name { get; }
		public string Descritpion { get; }

		private MenuItem(MenuItemId id, string name, string description) : base(id)
		{
			Name = name;
			Descritpion = description;
		}

		public static MenuItem Create(string name, string description)
		{
			return new MenuItem(MenuItemId.GenerateUniqueMenuItemId(),
					   name,
					   description);
		}
	}
}
