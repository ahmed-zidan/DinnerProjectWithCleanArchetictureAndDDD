using Dinner.Domain.Common.Models;
using Dinner.Domain.Common.ValueObjects;
using Dinner.Domain.Dinner.ValueObjects;
using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.MenuAggregate.Entities;
using Dinner.Domain.MenuAggregate.Events;
using Dinner.Domain.MenuAggregate.ValueObjects;
using Dinner.Domain.MenuReview.ValueObjects;


namespace Dinner.Domain.MenuAggregate
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _menuSections = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        private readonly List<DinnerId> _dinnerIds = new();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public AverageRating AverageRating { get; private set; }
        public IReadOnlyList<MenuSection> MenuSections=> _menuSections.AsReadOnly();

        public IReadOnlyList<DinnerId> MenuDinnerId => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public HostId HostId {  get; private set; }

        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Menu(MenuId id, string name, string description, AverageRating averageRating,
            HostId hostId ,List<MenuSection> menuSections, DateTime createdDate, DateTime updatedDate)
        :base(id){
            Name = name;
            Description = description;
            AverageRating = averageRating;
            HostId = hostId;
            CreatedDateTime = createdDate;
            UpdatedDateTime = updatedDate;
            _menuSections = menuSections;
        }
        private Menu()
        {

        }
        public static Menu Create(string name, string description,
            HostId hostId,List<MenuSection>menuSections)
        {
            var menu = new Menu(MenuId.CreateUniqueId(), name, description, AverageRating.CreateNew(),
                hostId ,menuSections, DateTime.UtcNow , DateTime.UtcNow);

            menu.AddDomainEvent(new MenuCreated(menu));

            return menu;
        }
    }
}
