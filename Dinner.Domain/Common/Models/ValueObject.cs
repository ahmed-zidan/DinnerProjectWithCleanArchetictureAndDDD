﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Common.Models
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public abstract IEnumerable<Object> GetEqualityComponents();
        public override bool Equals(object? obj)
        {
            if(obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            var objValue = obj as ValueObject;
            return GetEqualityComponents()
                .SequenceEqual(objValue.GetEqualityComponents());
        }

        public static bool operator ==(ValueObject left, ValueObject right) { 
            return Equals(left,right);
        }
        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !Equals(left, right);
        }
        public override int GetHashCode() {

            return GetEqualityComponents()
                .Select(x => x?.GetHashCode() ?? 0)
                .Aggregate((x, y) => x ^ y);
        
        }

        public bool Equals(ValueObject? other)
        {
            return Equals(this,other);
        }
    }
}
