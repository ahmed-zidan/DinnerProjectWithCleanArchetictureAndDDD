using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Common.Models
{
    public abstract class Entity<TID> : IEquatable<Entity<TID>>, IHasDomainEvents where TID : notnull
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        public TID Id{ get; protected set; }
        protected Entity(TID id)
        {
            Id = id;
        }
        protected Entity()
        {

        }

        public void AddDomainEvent(IDomainEvent domainEvent){
            _domainEvents.Add(domainEvent);
        }

        public override bool Equals(object? obj)
        {
            return obj is Entity<TID>  entity && Equals((Entity<TID>)obj);
        }

        public static bool operator ==(Entity<TID> left, Entity<TID> right) { 
            return Equals(left, right);
        }
        public static bool operator !=(Entity<TID> left, Entity<TID> right)
        {
            return !Equals(left, right);
        }
       
        public bool Equals(Entity<TID>? other)
        {
            return Equals(this, other);
        }
        public override int GetHashCode() { 
            return Id.GetHashCode();
        }

        public void ClreaDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
