using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VictimsHelp.BLL.Contracts;

namespace VictimsHelp.PL.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> VerifyEmail(string email)
        {
            var user = await _userService.GetByEmailAsync(email);
            return Json(user is null);
        }
    }
}
