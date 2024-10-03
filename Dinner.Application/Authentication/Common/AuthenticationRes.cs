using Dinner.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Application.Authentication.Common
{
    public record AuthenticationRes
    (
        AppUser user,
        string Token
    );
}
