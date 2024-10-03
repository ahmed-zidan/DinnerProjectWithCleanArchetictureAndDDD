using Dinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Dinner.ValueObjects
{
    public sealed class DinnerId : ValueObject
    {
        public Guid Value { get; private set; }
        private DinnerId(Guid id)
        {
            Value = id;
        }
        private DinnerId()
        {
            
        }
        public static DinnerId CreateUnique()
        {
            return new DinnerId(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
