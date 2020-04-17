using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffeten.Data.DBModels;
using Morgenmadsbuffeten.Models;

namespace Morgenmadsbuffeten.Controllers
{
    /* Employee - Chef : Uses iPad */
    //[Authorize("IsChef")]
    public class KitchenController : Controller
    {
        private readonly DbContext _context;

        public KitchenController(DbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        /* Given date, show guest-information (expected amount, checked-in amount, etc.) */
        public IActionResult ShowOverview(DateTime date)
        {
            var expectedGuestsInfo = _context.Set<ExpectedGuests>().Find(date);
            var checkedInEntries = _context.Set<CheckedIn>().Where(c => c.Date == date).ToList();
            
            var vm = new KitchenOverviewViewModel(expectedGuestsInfo, checkedInEntries);

            return View(vm);
        }
    }
}