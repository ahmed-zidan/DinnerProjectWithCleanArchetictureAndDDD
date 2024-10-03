using Dinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.MenuAggregate.ValueObjects
{
    public class MenuId : ValueObject
    {
        public Guid Value { get; private set; }
        private MenuId(Guid value) {
            Value = value;
        }
        private MenuId()
        {
         
        }
        public static MenuId CreateUniqueId()
        {
            return new MenuId(Guid.NewGuid());
        }
        public static MenuId Create(Guid id)
        {
            return new MenuId(id);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
