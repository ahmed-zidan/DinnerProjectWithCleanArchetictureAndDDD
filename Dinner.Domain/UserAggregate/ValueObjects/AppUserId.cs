using Dinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.UserAggregate.ValueObjects
{
    public sealed class AppUserId : ValueObject
    {
        public Guid Value { get;}
        private AppUserId(Guid value) {
            Value = value;
        }
        public static AppUserId CreateUnique()
        {
            return new AppUserId(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
