using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ZenithSociety2.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        : base()
        {
        }

        public ApplicationUser(string userName, string firstName, string lastName)
            : base(userName)
        {
            base.Email = userName;

            this.FirstName = firstName;
            this.LastName = lastName;


        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
