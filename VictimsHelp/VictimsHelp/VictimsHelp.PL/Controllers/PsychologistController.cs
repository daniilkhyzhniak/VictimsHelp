using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VictimsHelp.BLL.Contracts;
using VictimsHelp.BLL.Enums;
using VictimsHelp.PL.ViewModels.Psychologist;
using VictimsHelp.PL.ViewModels.User;

namespace VictimsHelp.PL.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("psychologists")]
    [Authorize(Roles = Roles.Psychologist)]
    public class PsychologistController : Controller
    {
        private readonly IPsychologistService _psychologistService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public PsychologistController(
            IPsychologistService psychologistService,
            IUserService userService,
            IMapper mapper)
        {
            _psychologistService = psychologistService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("~/clients/")]
        public async Task<IActionResult> Clients()
        {
            var email = HttpContext.User.Identity.Name;
            var clients = await _psychologistService.GetClientsAsync(email);

            var userViewModels = _mapper.Map<IEnumerable<UserViewModel>>(clients);

            return View(userViewModels);
        }

        [HttpGet("~/clients/{email}")]
        public async Task<IActionResult> Client(string email)
        {
            var client = await _userService.GetByEmailAsync(email);
            var userViewModel = _mapper.Map<UserViewModel>(client);

            var model = new ClientViewModel
            {
                User = userViewModel
            };

            return View(model);
        }
    }
}
