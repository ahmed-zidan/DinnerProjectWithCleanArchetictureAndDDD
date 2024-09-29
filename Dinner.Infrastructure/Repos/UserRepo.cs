using Dinner.Application.Common.Interfaces.Repositories;
using Dinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Infrastructure.Repos
{
    public class UserRepo : IUserRepo
    {
        public bool AddUser(AppUser user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public AppUser GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> GetUsers(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
