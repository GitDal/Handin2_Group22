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
            DateTime datetime = DateTime.Now;
            return RedirectToAction(nameof(ShowOverview), datetime.Date);
        }

        /* Given date, show guest-information (expected amount, checked-in amount, etc.) */
        public IActionResult ShowOverview(DateTime datetime)
        {
            var expectedGuestsInfo = _context.Set<ExpectedGuests>().Find(datetime.Date);
            var checkedInEntries = _context.Set<CheckedIn>().Where(c => c.Date == datetime.Date).ToList();
            
            var vm = new KitchenOverviewViewModel(expectedGuestsInfo, checkedInEntries);

            return View(vm);
        }
    }
}