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

        public async Task<AppUser> GetUserByEmailAsync(string email)
        {
            var user = new AppUser()
            {
                Email = email,
                FirstName = "test",
                LastName = "test2",
                Password = "password",
                Id = Guid.NewGuid()
            };
            return await Task.FromResult(user);
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
