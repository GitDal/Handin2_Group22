using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffeten.Data.DBModels;

namespace Morgenmadsbuffeten.Controllers
{
    /* Employee - Receptionist : Uses PC */
    //[Authorize("IsReceptionist")]
    public class ReceptionController : Controller
    {
        private readonly DbContext _context;

        public ReceptionController(DbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        /* Indicate amount of guests that has ordered breakfast (this day)  */
        public IActionResult IndicateExpectedGuests()
        {
            var vm = new ExpectedGuests();

            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IndicateExpectedGuests(ExpectedGuests expectedGuests)
        {
            if (ModelState.IsValid)
            {
                expectedGuests.TotalAmount = expectedGuests.NumberOfAdults + expectedGuests.NumberOfChildren;
                var task = _context.Set<ExpectedGuests>().AddAsync(expectedGuests);
                await task;

                if (task.IsCompletedSuccessfully)
                {
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }

            return View();
        }

        /* List of room-numbers (adults, children) that has eaten breakfast (this day) */
        public IActionResult ListRestaurantCheckIns(DateTime datetime)
        {
            var restaurantCheckIns = _context.Set<ExpectedGuests>().Where(e => e.Date == datetime.Date).ToList();

            return View(restaurantCheckIns);
        }

    }
}