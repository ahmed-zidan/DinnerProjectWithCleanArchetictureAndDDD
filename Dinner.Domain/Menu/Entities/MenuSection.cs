using Dinner.Domain.Common.Models;
using Dinner.Domain.Menu.Entities;
using Dinner.Domain.Menu.ValueObjects;


namespace Dinner.Domain.Menu.Entity
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _Items = new();
        public string Name { get; }
        public string Description { get; }
        public  IReadOnlyList<MenuItem> Items => _Items.AsReadOnly();
        
        private MenuSection(MenuSectionId id , string name,
            string description) : base(id)
        {
            
        }
        public static MenuSection Create(string name, string description)
        {
            return new MenuSection(MenuSectionId.CreateUniqueId(), name, description);
        }
    }
}
