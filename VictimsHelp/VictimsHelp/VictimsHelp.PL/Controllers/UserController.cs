using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VictimsHelp.BLL.Contracts;

namespace VictimsHelp.PL.Controllers
{
    [Route("users")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("~/")]
        public async Task<IActionResult> List()
        {
            var users = await _userService.GetAllAsync();
            return View(users);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Details(string email)
        {
            var user = await _userService.GetByEmailAsync(email);
            return View(user);
        }
    }
}
