using Dinner.Application.Common.Interfaces.Repositories;
using Dinner.Domain.UserAggregate;
using Dinner.Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Infrastructure.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;
        public UserRepo(AppDbContext context)
        {
            _context = context;
        }
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
            AppUser user = AppUser.CreateNew("test", "test2", email,
                "password");
            
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
