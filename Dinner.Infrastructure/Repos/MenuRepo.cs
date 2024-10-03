using Dinner.Application.Common.Interfaces.Repositories;
using Dinner.Domain.MenuAggregate;
using Dinner.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Infrastructure.Repos
{
    public class MenuRepo : IMenuRepo
    {
        private readonly AppDbContext _context;
        public MenuRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateMenuAsync(Menu menu)
        {
            await _context.AddAsync(menu);
            
        }

        public async Task<List<Menu>> GetMenusAsync()
        {
            return await _context.Menus.ToListAsync();
        }
    }
}
