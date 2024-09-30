using Dinner.Domain.Common.Models;
using Dinner.Domain.Common.ValueObjects;
using Dinner.Domain.Dinner.ValueObjects;
using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.Menu.Entity;
using Dinner.Domain.Menu.ValueObjects;
using Dinner.Domain.MenuReview.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        private readonly List<DinnerId> _dinnerIds = new();
        public string Name { get;}
        public string Description { get;}
        public AverageRating AverageRating { get;}
        public IReadOnlyList<MenuSection> menuSections=> _sections.AsReadOnly();

        public IReadOnlyList<DinnerId> DinnerId => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public HostId HostId {  get;}

        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Menu(MenuId id, string name, string description, AverageRating averageRating,
            HostId hostId , DateTime createdDate, DateTime updatedDate)
        :base(id){
            Name = name;
            Description = description;
            AverageRating = averageRating;
            HostId = hostId;
            CreatedDateTime = createdDate;
            UpdatedDateTime = updatedDate;
        }
        
        public static Menu Create(string name, string description, AverageRating averageRating,
            HostId hostId)
        {
            return new Menu(MenuId.CreateUniqueId(), name, description, averageRating,
                hostId , DateTime.UtcNow , DateTime.UtcNow);
        }
    }
}
