using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Contracts.Menu
{
    public sealed class MenuResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float AverageRating { get; set; }
        public List<MenuSectionRes> MenuSections { get; set; }
        public string HostId { get; set; }
        public List<string> DinnerIds { get; set; }
        public List<string> MenuReviewIds { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
    public sealed class MenuSectionRes
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MenuItemRes> MenuItems { get; set; }
    }

    public sealed class MenuItemRes
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
