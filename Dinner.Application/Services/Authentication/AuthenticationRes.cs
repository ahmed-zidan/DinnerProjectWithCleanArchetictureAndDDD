using Dinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Application.Services.Authentication
{
    public record AuthenticationRes
    (   
        AppUser user,
        string Token
    );
}
