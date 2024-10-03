using Dinner.Application.Common.Interfaces.Repositories;
using Dinner.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Infrastructure.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IUserRepo _userRepo => new UserRepo(_context);
        public IMenuRepo _menuRepo => new MenuRepo(_context);

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync()> 0;
        }
    }
}
