﻿using Dinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.MenuAggregate.Events
{
    public record MenuCreated(Menu Menu):IDomainEvent;
}
