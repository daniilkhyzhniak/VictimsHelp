using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace VictimsHelp.PL.Controllers
{
    [Route("")]
    [ApiExplorerSettings(IgnoreApi = true)]
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

        [HttpGet("download-mobile-app")]
        public IActionResult DownloadMobileApp()
        {
            var filePath = Path.GetFullPath("victims_help.apk");
            var fileType = "application/octet-stream";

            return PhysicalFile(filePath, fileType, "victims_help.apk");
        }
    }
}
