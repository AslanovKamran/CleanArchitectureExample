using DinnerStore.Domain.Common.Models;
using DinnerStore.Domain.Common.ValueObjects;
using DinnerStore.Domain.Dinner.ValueObjects.cs;
using DinnerStore.Domain.Host.ValueObjects;
using DinnerStore.Domain.Menu.Entities;
using DinnerStore.Domain.Menu.ValueObjects;
using DinnerStore.Domain.MenuReview.ValueObjects;

namespace DinnerStore.Domain.Menu
{
	public sealed class Menu : AggregateRoot<MenuId>
	{
		private readonly List<MenuSection> _sections = new();
		private readonly List<DinnerId> _dinnerIds = new();
		private readonly List<MenuReviewId> _reviewsIds = new();

		public string Name { get; }
		public string Descritpion { get; }
		public AverageRating? AverageRating { get; } 
		public HostId HostId { get; }

		public DateTime CreatedDateTime { get; }
		public DateTime UpdatedDateTime { get; }

		public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
		public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
		public IReadOnlyList<MenuReviewId> MenuReviewIds => _reviewsIds.AsReadOnly();

		private Menu(MenuId menuId, string name, string descritpion, AverageRating averageRating, HostId hostId, DateTime createdDateTime, DateTime updatedDateTime) : base(menuId)
		{
			Name = name;
			Descritpion = descritpion;
			HostId = hostId;
			CreatedDateTime = createdDateTime;
			UpdatedDateTime = updatedDateTime;
		}

		public static Menu Create(string name, string description, AverageRating averageRating, HostId hostId)
		{
			return new Menu(
				MenuId.GenerateUniqueMenuId(),
				name,
				description,
				averageRating,
				hostId,
				DateTime.UtcNow,
				DateTime.UtcNow
				) ;
		}
	}
}
