using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Morgenmadsbuffeten.Controllers
{
    /* Employee - Chef : Uses iPad */
    //[Authorize("IsChef")]
    public class KitchenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /* Given date, show guest-information (expected amount, checked-in amount, etc.) */
        public IActionResult ShowOverview()
        {
            return View();
        }
    }
}