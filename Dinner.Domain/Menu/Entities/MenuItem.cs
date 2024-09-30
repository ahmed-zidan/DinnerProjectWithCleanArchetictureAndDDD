﻿using Dinner.Domain.Common.Models;
using Dinner.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; }
        public string Description { get; }
        private MenuItem(MenuItemId id , string name , string description) : base(id)
        {
            Name = name;
            Description = description;
        }
        public static MenuItem Create(string name , string description)
        {
            return new MenuItem(MenuItemId.CreateUniqueId(), name, description);
        }
    }
}
