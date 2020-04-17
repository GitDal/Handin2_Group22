using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Morgenmadsbuffeten.Controllers
{
    /* Employee - Receptionist : Uses PC */
    //[Authorize("IsReceptionist")]
    public class ReceptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /* Indicate amount of guests that has ordered breakfast (this day)  */
        public IActionResult IndicateBreakfastOrders()
        {
            return View();
        }

        /* List of room-numbers (adults, children) that has eaten breakfast (this day) */
        public IActionResult ListRooms()
        {
            return View();
        }

    }
}