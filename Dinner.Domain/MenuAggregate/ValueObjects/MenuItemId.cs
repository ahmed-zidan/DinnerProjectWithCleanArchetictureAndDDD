using Dinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.MenuAggregate.ValueObjects
{
    public class MenuItemId : ValueObject
    {
        public Guid Value { get; private set; }
        private MenuItemId(Guid value)
        {
            Value = value;
        }
        private MenuItemId()
        {
            
        }
        public static MenuItemId CreateUniqueId()
        {
            return new MenuItemId(Guid.NewGuid());
        }
        public static MenuItemId Create(Guid id)
        {
            return new MenuItemId(id);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
