using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Application.Common.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepo _userRepo { get; }
        IMenuRepo _menuRepo { get; }
        Task<bool> SaveChangesAsync();
    }
}
