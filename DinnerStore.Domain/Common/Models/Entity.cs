

namespace DinnerStore.Domain.Common.Models
{
	public abstract class Entity<TId> : IEquatable<Entity<TId>>
		where TId : notnull 
	{
		public TId Id { get; protected set; }
		public Entity(TId id) => Id = id;

		//Two entities are equal when their Ids are equal

		public override bool Equals(object? obj)
		{
			if (obj is null || obj.GetType() != this.GetType()) return false;
			
			var entity = (Entity<TId>)obj;
			return this.Id.Equals(entity.Id);
		}

		public static bool operator ==(Entity<TId> left, Entity<TId> right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Entity<TId> left, Entity<TId> right)
		{
			return !left.Equals(right);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public bool Equals(Entity<TId>? other)
		{
			return Equals((object?)other);
		}
	}
}
