using Dinner.Domain.Common.Models;
using Dinner.Domain.MenuAggregate.Entities;
using Dinner.Domain.MenuAggregate.ValueObjects;


namespace Dinner.Domain.MenuAggregate.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _Items = new();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public  IReadOnlyList<MenuItem> Items => _Items.AsReadOnly();
        
        private MenuSection(MenuSectionId id , string name,
            string description,List<MenuItem>items) : base(id)
        {
            _Items = items;
            Name = name;
            Description = description;
        }
        private MenuSection()
        {
            
        }
        public static MenuSection Create(string name, string description, List<MenuItem> items)
        {
            return new MenuSection(MenuSectionId.CreateUniqueId(), name, description,items);
        }
    }
}
