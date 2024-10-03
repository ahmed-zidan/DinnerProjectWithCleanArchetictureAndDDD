using Dinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Host.ValueObjects
{
    public sealed class HostId : ValueObject
    {
        public Guid Value {  get; private set; }
        private HostId(Guid value)
        {
            Value = value;
        }
        private HostId()
        {

        }
        public static HostId CreateUniqueId()
        {
            return new HostId(Guid.NewGuid());
        }
        public static HostId Create(string hostId)
        {
            return new HostId(Guid.Parse(hostId));
        }
        public static HostId Create(Guid hostId)
        {
            return new HostId(hostId);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
