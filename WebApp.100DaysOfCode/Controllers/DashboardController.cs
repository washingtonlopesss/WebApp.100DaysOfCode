using Microsoft.AspNetCore.Mvc;

namespace WebApp._100DaysOfCode.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
