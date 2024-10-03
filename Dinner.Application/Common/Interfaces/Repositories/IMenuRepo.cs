using Dinner.Domain.MenuAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Application.Common.Interfaces.Repositories
{
    public interface IMenuRepo
    {
        Task CreateMenuAsync(Menu menu);
        Task<List<Menu>> GetMenusAsync();
    }
}
