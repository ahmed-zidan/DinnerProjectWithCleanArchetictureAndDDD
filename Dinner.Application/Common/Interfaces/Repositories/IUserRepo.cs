using Dinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Application.Common.Interfaces.Repositories
{
    public interface IUserRepo
    {
        AppUser GetUserByEmail(string email);
        List<AppUser> GetUsers(Guid id);
        bool AddUser(AppUser user);
        bool UpdateUser(AppUser user);
        bool DeleteUser(Guid id);

    }
}
