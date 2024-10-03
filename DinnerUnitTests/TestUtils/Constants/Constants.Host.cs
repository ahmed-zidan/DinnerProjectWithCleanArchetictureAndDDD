

using Dinner.Domain.Host.ValueObjects;

namespace DinnerUnitTests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class Host
        {
            //public const string HostId =
           public static readonly HostId Id = HostId.CreateUniqueId();

        }
    }
}   
