using Dinner.Application.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Infrastructure.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepo _userRepo => new UserRepo();

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
