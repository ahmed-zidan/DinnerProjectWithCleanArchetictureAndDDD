using Dinner.Domain.Common.Models;
using Dinner.Domain.MenuAggregate.ValueObjects;


namespace Dinner.Domain.MenuAggregate.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        private MenuItem(MenuItemId id , string name , string description) : base(id)
        {
            Name = name;
            Description = description;
        }
        private MenuItem()
        {}
        public static MenuItem Create(string name , string description)
        {
            return new MenuItem(MenuItemId.CreateUniqueId(), name, description);
        }
    }
}
