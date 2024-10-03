using Dinner.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Application.Common.Interfaces.Authentication
{
    public interface IJWTTokenGenerator
    {
        string GenerateToken(AppUser user);
    }
}
