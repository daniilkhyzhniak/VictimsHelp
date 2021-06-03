using Microsoft.AspNetCore.Mvc;

namespace VictimsHelp.PL.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet("join-us")]
        public IActionResult JoinUs()
        {
            return View();
        }
    }
}
