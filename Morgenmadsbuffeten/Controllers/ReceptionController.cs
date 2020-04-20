using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffeten.Data;
using Morgenmadsbuffeten.Data.DBModels;

namespace Morgenmadsbuffeten.Controllers
{
    /* Employee - Receptionist : Uses PC */
    [Authorize("IsReceptionist")]
    public class ReceptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceptionController(ApplicationDbContext context)
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
            vm.Date = DateTime.Now; //Default today

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
        public async Task<IActionResult> ListRestaurantCheckIns()
        {
            DateTime date = DateTime.Now.Date;

            var restaurantCheckIns = await _context.Set<CheckedIn>().Where(c => c.Date == date).ToListAsync();

            return View(restaurantCheckIns);
        }

    }
}