using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithSociety2.Models;
using ZenithSociety2.Data;
using Microsoft.EntityFrameworkCore;

namespace ZenithSociety2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            DateTime thisMonday = DateTime.Today.AddDays(((int)(DateTime.Today.DayOfWeek) * -1) + 1);
            DateTime nextMonday = thisMonday.AddDays(7);

            var upcomingEvents = _context.Events
                                .Where(e => e.DateFrom >= thisMonday && e.DateFrom < nextMonday && e.IsActive == true)
                                .OrderBy(e => e.DateFrom)
                                .Include(e => e.ActivityCategory);
            return View(upcomingEvents.ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
