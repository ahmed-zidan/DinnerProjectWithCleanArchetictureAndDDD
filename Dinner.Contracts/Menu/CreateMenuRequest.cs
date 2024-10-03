using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Contracts.Menu
{
    public sealed class CreateMenuRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MenuSection> MenuSections { get; set; }
    }

    public sealed class MenuSection
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }

    public sealed class MenuItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
