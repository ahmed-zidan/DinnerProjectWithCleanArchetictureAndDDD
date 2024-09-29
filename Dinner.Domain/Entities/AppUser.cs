using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Entities
{
    public class AppUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { set; get; } = null!;
        public string LastName { set; get; } = null!;
        public string Email { set; get; } = null!;
        public string Password { get; set; } = null!;
    }
}
