using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using ZenithSociety2.Data;
using Microsoft.AspNetCore.Identity;
using ZenithSociety2.Models;
using ZenithWebSite.Models;
using Microsoft.EntityFrameworkCore;

namespace ZenithSociety2
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = BuildWebHost(args);


            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<ApplicationDbContext>();
                if(context.Database.IsSqlite())
                {
                    context.Database.EnsureCreated();
                }
                
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                DBInitializer.Initialize(context, userManager, roleManager).Wait();
                
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
