using Dinner.Domain.Common.Models;
using Dinner.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.UserAggregate
{
    public class AppUser : AggregateRoot<AppUserId>
    {
        public string FirstName { set; get; } = null!;
        public string LastName { set; get; } = null!;
        public string Email { set; get; } = null!;
        public string Password { get; set; } = null!;

        private AppUser(AppUserId id, string firstName, string lastName, string email, string password)
        :base(id){
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
        public static AppUser CreateNew(string firstName, string lastName, string email, string password)
        {
            return new AppUser(AppUserId.CreateUnique(),firstName, lastName, email, password);   
        }
    }
}
