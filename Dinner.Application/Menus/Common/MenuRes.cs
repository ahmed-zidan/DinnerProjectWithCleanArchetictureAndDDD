using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Application.Menus.Common
{
    public class MenuRes
    {
        public string Id { get; set; }
        public string Name { get; }
        public string Description { get; }
        public float AverageRating { get; set; }
        public List<MenuSectionRes> MenuSections { get; set; }
        public string HostId { get; set; }
        public List<string> DinnerIds { get; set; }
        public List<string> MenuReviewIds { get; set; }

        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
    }
    public sealed class MenuSectionRes
    {
        public string Id { get; set; }
        public string Name { get; }
        public string Description { get; }
        public List<MenuItemRes> MenuItems { get; set; }
    }

    public sealed class MenuItemRes
    {
        public string Id { get; set; }
        public string Name { get; }
        public string Description { get; }
    }
}
