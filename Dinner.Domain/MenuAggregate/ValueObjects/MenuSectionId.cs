using Dinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.MenuAggregate.ValueObjects
{
    public class MenuSectionId : ValueObject
    {
        public Guid Value { get; private set; }
        private MenuSectionId(Guid value)
        {
            Value = value;
        }

        private MenuSectionId()
        {
            
        }
        public static MenuSectionId CreateUniqueId()
        {
            return new MenuSectionId(Guid.NewGuid());
        }
        public static MenuSectionId Create(Guid id)
        {
            return new MenuSectionId(id);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
