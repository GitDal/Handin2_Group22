using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffeten.Data;
using Morgenmadsbuffeten.Data.DBModels;

namespace Morgenmadsbuffeten.Controllers
{
    /*Employee - Waiter : Uses Mobile-Phone*/
    //[Authorize("IsWaiter")]
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RestaurantController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        /* Check-in guests for breakfast (room-number, amount of adults & children)*/
        public IActionResult CheckInGuests()
        {
            var vm = new CheckedIn();

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckInGuests(CheckedIn newEntry)
        {
            if (ModelState.IsValid)
            {
                var result = _context.AddAsync<CheckedIn>(newEntry);
                await result;

                if (result.IsCompletedSuccessfully)
                {
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View();
        }

    }
}