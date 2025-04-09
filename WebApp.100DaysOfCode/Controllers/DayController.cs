using Microsoft.AspNetCore.Mvc;
using WebApp._100DaysOfCode.Models;

namespace WebApp._100DaysOfCode.Controllers
{
    public class DayController : Controller
    {
        public IActionResult DayHistory()
        {
            return View();
        }

        public IActionResult DayRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DayRegister(Day day)
        {
            return RedirectToAction("DayHistory");
        }
    }
}