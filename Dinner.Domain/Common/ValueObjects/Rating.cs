using Dinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Common.ValueObjects
{
    public sealed class Rating : ValueObject
    {
        public double Value { get; private set; }
        private Rating(double value)
        {
            Value = value;
        }
        public static Rating CreateNew(double value = 0)
        {
            return new Rating(value);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
