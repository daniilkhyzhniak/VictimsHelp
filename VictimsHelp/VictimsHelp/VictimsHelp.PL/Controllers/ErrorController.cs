using Microsoft.AspNetCore.Mvc;
using VictimsHelp.PL.ViewModels.Error;

namespace VictimsHelp.PL.Controllers
{
    [Route("error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : Controller
    {
        [HttpGet("accessDenied")]
        public IActionResult AccessDenied()
        {
            var error = new ErrorViewModel
            {
                Title = "Access denied",
                Message = "Access to this resource is denied."
            };
            return View("Error", error);
        }

        [HttpGet("forbidden")]
        public IActionResult Forbidden()
        {
            var error = new ErrorViewModel
            {
                Title = "Forbidden",
                Message = "Access to this resource is denied."
            };
            return View("Error", error);
        }

        [HttpGet("notFound")]
        public new IActionResult NotFound()
        {
            var error = new ErrorViewModel
            {
                Title = "Not Found",
                Message = "The requested resource could not be found."
            };
            return View("Error", error);
        }

        [HttpGet]
        public IActionResult InternalError()
        {
            var error = new ErrorViewModel
            {
                Title = "Internal Error",
                Message = "An internal error occured."
            };
            return View("Error", error);
        }
    }
}
