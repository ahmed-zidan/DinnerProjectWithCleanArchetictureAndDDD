using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Common.Models
{
    public abstract class Entity<TID> : IEquatable<Entity<TID>> where TID : notnull
    {
        public TID Id{ get; protected set; }
        protected Entity(TID id)
        {
            Id = id;
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
    }
}
