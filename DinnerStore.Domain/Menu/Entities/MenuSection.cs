using DinnerStore.Domain.Common.Models;
using DinnerStore.Domain.Menu.ValueObjects;

namespace DinnerStore.Domain.Menu.Entities
{
	public sealed class MenuSection : Entity<MenuSectionId>
	{
		private readonly List<MenuItem> _menuItems = new();

	

		public string Name { get; }
		public string Descritpion { get; }

		public IReadOnlyList<MenuItem> Items => _menuItems.AsReadOnly();

		private MenuSection(MenuSectionId id, string name, string description) : base(id)
		{
			Name = name;
			Descritpion = description; 
		}

		public static MenuSection Create(string name, string description) 
		{
			return new MenuSection(
				MenuSectionId.GenerateUniqueMenuSectionId(),
				name,
				description);
		}
	}
}
