using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithSociety2.Data;
using ZenithSociety2.Models;

namespace ZenithWebSite.Models
{
    public class DBInitializer
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
        {
            

            // Look for any users.
            if (context.Users.Any() && context.ActivityCategories.Any())
            {
                return; // DB has been seeded
            }

            //create user role and role for application
            const string administratorRole = "Admin";
            const string email = "a@a.a";
            const string name = "a";
            //create admin role
            await roleManager.CreateAsync(new IdentityRole(administratorRole));
            //create user role
            var user = new ApplicationUser(name, "First", "Last");
            await userManager.CreateAsync(user);
            //set password for user
            const string password = "P@$$w0rd";
            await userManager.AddPasswordAsync(user, password);
            //add role to user
            await userManager.AddToRoleAsync(user, administratorRole);

            //create user role and role for application
            const string memberRole = "Member";
            const string mEmail = "m@m.m";
            const string mName = "m";
            //create member role
            await roleManager.CreateAsync(new IdentityRole(memberRole));
            //create user role
            var mUser = new ApplicationUser(mName, "First", "Last");
            await userManager.CreateAsync(mUser);
            //set password for user
            const string mPassword = "P@$$w0rd";
            await userManager.AddPasswordAsync(mUser, mPassword);
            //add role to user
            await userManager.AddToRoleAsync(mUser, memberRole);

            List<ActivityCategory> activitycategories = new List<ActivityCategory>()
            {
                new ActivityCategory()
                {
                    ActivityDescription = "Senior's Golf Tournament",
                    CreationDate = new DateTime(2017, 1, 1, 9, 00, 0)
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Leadership General Assembly Meeting",
                    CreationDate = new DateTime(2017, 1, 2, 10, 00, 0)
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Youth Bowling Tournament",
                    CreationDate = new DateTime(2017, 1, 3, 11, 00, 0)
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Young ladies cooking lessons",
                    CreationDate = new DateTime(2017, 1, 4, 12, 00, 0)
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Youth craft lessons",
                    CreationDate = new DateTime(2017, 2, 1, 9, 00, 0)
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Youth choir practice",
                    CreationDate = new DateTime(2017, 2, 2, 10, 00, 0)
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Lunch",
                    CreationDate = new DateTime(2017, 2, 3, 11, 00, 0)
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Pancake Breakfast",
                    CreationDate = new DateTime(2017, 2, 4, 12, 00, 0)
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Swimming Lessons for the youth",
                    CreationDate = new DateTime(2017, 3, 1, 9, 00, 0)
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Swimming Exercise for parents",
                    CreationDate = new DateTime(2017, 3, 2, 10, 00, 0)
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Bingo Tournament",
                    CreationDate = new DateTime(2017, 3, 3, 11, 00, 0)
                },
                new ActivityCategory()
                {
                    ActivityDescription = "BBQ Lunch",
                    CreationDate = new DateTime(2017, 3, 4, 12, 00, 0)
                },
                new ActivityCategory()
                {
                    ActivityDescription = "Garage Sale",
                    CreationDate = new DateTime(2017, 4, 1, 9, 00, 0)
                }
            };

            foreach (ActivityCategory c in activitycategories)
            {
                context.ActivityCategories.Add(c);
            }
            context.SaveChanges();

            List<Event> events = new List<Event>()
            {
                new Event()
                {
                    DateFrom = new DateTime(2017, 10, 17, 8, 30, 0),
                    DateTo = new DateTime(2017, 10, 17, 10, 30, 0),
                    EnteredBy = "Eric Lin",
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(a => a.ActivityDescription == "Senior's Golf Tournament"),
                    CreationDate = new DateTime(2017, 10, 17, 8, 30, 0),
                    IsActive = true
                },
                new Event()
                {
                    DateFrom = new DateTime(2017, 10, 18, 8, 30, 0),
                    DateTo = new DateTime(2017, 10, 18, 10, 30, 0),
                    EnteredBy = "Eric Lin",
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(a => a.ActivityDescription == "Leadership General Assembly Meeting"),
                    CreationDate = new DateTime(2017, 10, 18, 8, 30, 0),
                    IsActive = true
                },
                new Event()
                {
                    DateFrom = new DateTime(2017, 10, 20, 17, 30, 0),
                    DateTo = new DateTime(2017, 10, 20, 19, 15, 0),
                    EnteredBy = "Eric Lin",
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(a => a.ActivityDescription == "Youth Bowling Tournament"),
                    CreationDate = new DateTime(2017, 10, 20, 17, 30, 0),
                    IsActive = true
                },
                new Event()
                {
                    DateFrom = new DateTime(2017, 10, 20, 19, 00, 0),
                    DateTo = new DateTime(2017, 10, 20, 20, 00, 0),
                    EnteredBy = "Eric Lin",
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(a => a.ActivityDescription == "Young ladies cooking lessons"),
                    CreationDate = new DateTime(2017, 10, 20, 19, 00, 0),
                    IsActive = true
                },
                new Event()
                {
                    DateFrom = new DateTime(2017, 10, 21, 8, 30, 0),
                    DateTo = new DateTime(2017, 10, 21, 10, 30, 0),
                    EnteredBy = "Eric Lin",
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(a => a.ActivityDescription == "Youth craft lessons"),
                    CreationDate = new DateTime(2017, 10, 21, 8, 30, 0),
                    IsActive = true
                },
                new Event()
                {
                    DateFrom = new DateTime(2017, 10, 21, 10, 30, 0),
                    DateTo = new DateTime(2017, 10, 21, 12, 00, 0),
                    EnteredBy = "Eric Lin",
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(a => a.ActivityDescription == "Youth choir practice"),
                    CreationDate = new DateTime(2017, 10, 21, 10, 30, 0),
                    IsActive = true
                },
                new Event()
                {
                    DateFrom = new DateTime(2017, 10, 21, 12, 00, 0),
                    DateTo = new DateTime(2017, 10, 21, 13, 30, 0),
                    EnteredBy = "Eric Lin",
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(a => a.ActivityDescription == "Lunch"),
                    CreationDate = new DateTime(2017, 10, 21, 12, 00, 0),
                    IsActive = true
                },
                new Event()
                {
                    DateFrom = new DateTime(2017, 10, 22, 7, 30, 0),
                    DateTo = new DateTime(2017, 10, 22, 8, 30, 0),
                    EnteredBy = "Eric Lin",
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(a => a.ActivityDescription == "Pancake Breakfast"),
                    CreationDate = new DateTime(2017, 10, 22, 7, 30, 0),
                    IsActive = true
                },
                new Event()
                {
                    DateFrom = new DateTime(2017, 10, 22, 8, 30, 0),
                    DateTo = new DateTime(2017, 10, 22, 10, 30, 0),
                    EnteredBy = "Eric Lin",
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(a => a.ActivityDescription == "Swimming Lessons for the youth"),
                    CreationDate = new DateTime(2017, 10, 22, 8, 30, 0),
                    IsActive = true
                },
                new Event()
                {
                    DateFrom = new DateTime(2017, 10, 22, 8, 30, 0),
                    DateTo = new DateTime(2017, 10, 22, 10, 30, 0),
                    EnteredBy = "Eric Lin",
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(a => a.ActivityDescription == "Swimming Exercise for parents"),
                    CreationDate = new DateTime(2017, 10, 22, 8, 30, 0),
                    IsActive = true
                },
                new Event()
                {
                    DateFrom = new DateTime(2017, 10, 22, 10, 30, 0),
                    DateTo = new DateTime(2017, 10, 22, 12, 00, 0),
                    EnteredBy = "Eric Lin",
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(a => a.ActivityDescription == "Bingo Tournament"),
                    CreationDate = new DateTime(2017, 10, 22, 10, 30, 0),
                    IsActive = true
                },
                new Event()
                {
                    DateFrom = new DateTime(2017, 10, 22, 12, 00, 0),
                    DateTo = new DateTime(2017, 10, 22, 13, 00, 0),
                    EnteredBy = "Eric Lin",
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(a => a.ActivityDescription == "BBQ Lunch"),
                    CreationDate = new DateTime(2017, 10, 22, 12, 30, 0),
                    IsActive = true
                },
                new Event()
                {
                    DateFrom = new DateTime(2017, 10, 22, 13, 00, 0),
                    DateTo = new DateTime(2017, 10, 22, 18, 00, 0),
                    EnteredBy = "Eric Lin",
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(a => a.ActivityDescription == "Garage Sale"),
                    CreationDate = new DateTime(2017, 10, 22, 13, 00, 0),
                    IsActive = true
                },
                new Event()
                {
                    DateFrom = new DateTime(2017, 10, 23, 8, 30, 0),
                    DateTo = new DateTime(2017, 10, 23, 10, 30, 0),
                    EnteredBy = "Eric Lin",
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(a => a.ActivityDescription == "Senior's Golf Tournament"),
                    CreationDate = new DateTime(2017, 10, 17, 8, 30, 0),
                    IsActive = true
                },
                new Event()
                {
                    DateFrom = new DateTime(2017, 10, 24, 8, 30, 0),
                    DateTo = new DateTime(2017, 10, 24, 10, 30, 0),
                    EnteredBy = "Eric Lin",
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(a => a.ActivityDescription == "Leadership General Assembly Meeting"),
                    CreationDate = new DateTime(2017, 10, 18, 8, 30, 0),
                    IsActive = true
                },
                new Event()
                {
                    DateFrom = new DateTime(2017, 10, 26, 17, 30, 0),
                    DateTo = new DateTime(2017, 10, 26, 19, 15, 0),
                    EnteredBy = "Eric Lin",
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(a => a.ActivityDescription == "Youth Bowling Tournament"),
                    CreationDate = new DateTime(2017, 10, 20, 17, 30, 0),
                    IsActive = true
                },
                new Event()
                {
                    DateFrom = new DateTime(2017, 10, 26, 19, 00, 0),
                    DateTo = new DateTime(2017, 10, 26, 20, 00, 0),
                    EnteredBy = "Eric Lin",
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(a => a.ActivityDescription == "Young ladies cooking lessons"),
                    CreationDate = new DateTime(2017, 10, 20, 19, 00, 0),
                    IsActive = true
                },
                new Event()
                {
                    DateFrom = new DateTime(2017, 10, 27, 8, 30, 0),
                    DateTo = new DateTime(2017, 10, 27, 10, 30, 0),
                    EnteredBy = "Eric Lin",
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(a => a.ActivityDescription == "Youth craft lessons"),
                    CreationDate = new DateTime(2017, 10, 21, 8, 30, 0),
                    IsActive = true
                }
            };


            foreach (Event e in events)
            {
                context.Events.Add(e);
            }
            context.SaveChanges();
        }

    }
}