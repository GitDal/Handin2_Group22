using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Morgenmadsbuffeten.Controllers
{
    /*Employee - Waiter : Uses Mobile-Phone*/
    //[Authorize("IsWaiter")]
    public class RestaurantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /* Check-in guests for breakfast (room-number, amount of adults & children)*/
        public IActionResult CheckInGuests()
        {
            return View();
        }

        /*
        [HttpPost]
        public async Task<IActionResult> CheckInGuests()
        {
            return View();
        }
        */
    }
}