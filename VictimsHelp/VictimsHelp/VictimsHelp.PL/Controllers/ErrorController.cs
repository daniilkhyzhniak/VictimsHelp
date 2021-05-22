using Microsoft.AspNetCore.Mvc;

namespace VictimsHelp.PL.Controllers
{
    [Route("error")]
    public class ErrorController : Controller
    {
        [HttpGet("forbidden")]
        public IActionResult Forbidden()
        {
            return View();
        }

        [HttpGet("notFound")]
        public new IActionResult NotFound()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InternalError()
        {
            return View();
        }
    }
}
