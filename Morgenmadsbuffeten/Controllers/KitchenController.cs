using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffeten.Data;
using Morgenmadsbuffeten.Data.DBModels;
using Morgenmadsbuffeten.Models;

namespace Morgenmadsbuffeten.Controllers
{
    /* Employee - Chef : Uses iPad */
    //[Authorize("IsChef")]
    public class KitchenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KitchenController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        /* Given date, show guest-information (expected amount, checked-in amount, etc.) */
        public async Task<IActionResult> ShowOverview(DateTime dateTime)
        {
            var expectedGuestsInfo = await _context.Set<ExpectedGuests>().FindAsync(dateTime.Date);
            var checkedInEntries = await _context.Set<CheckedIn>().Where(c => c.Date == dateTime.Date).ToListAsync();

            var vm = new KitchenOverviewViewModel(expectedGuestsInfo, checkedInEntries, dateTime.Date);

            return View(vm);
        }
    }
}