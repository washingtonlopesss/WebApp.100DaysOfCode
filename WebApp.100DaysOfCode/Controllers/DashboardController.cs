using Microsoft.AspNetCore.Mvc;
using WebApp._100DaysOfCode.Services;

namespace WebApp._100DaysOfCode.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        var _commits = new GitHubAPI().SearchLatestCommits();

        ViewData["DaysOn"] = 1;

        return View(_commits);
    }
}
