using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Common.Models
{
    public abstract class AggregateRoot<TID> : Entity<TID>
        where TID : notnull
    {
        protected AggregateRoot(TID id) : base(id)
        {

        }
    }
}
