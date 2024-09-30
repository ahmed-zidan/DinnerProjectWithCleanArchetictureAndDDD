using Dinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Menu.ValueObjects
{
    public class MenuSectionId : ValueObject
    {
        public Guid Value { get; }
        private MenuSectionId(Guid value)
        {
            Value = value;
        }
        public static MenuSectionId CreateUniqueId()
        {
            return new MenuSectionId(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
