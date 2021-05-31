using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VictimsHelp.BLL.Contracts;

namespace VictimsHelp.PL.Controllers.Api
{
    [Route("api/users")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserApiController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}/available")]
        public async Task<bool> CheckIfEmailIsAvailable(string email)
        {
            var user = await _userService.GetByEmailAsync(email);

            return user is null;
        }
    }
}
