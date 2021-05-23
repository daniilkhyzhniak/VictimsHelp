using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using VictimsHelp.BLL.Contracts;
using VictimsHelp.BLL.Enums;
using VictimsHelp.BLL.Models;
using VictimsHelp.PL.ViewModels.User;

namespace VictimsHelp.PL.Controllers
{
    [Route("users")]
    [Authorize(Roles = Roles.Admin)]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await _userService.GetAllAsync();

            var userViewModels = _mapper.Map<IEnumerable<UserViewModel>>(users);

            return View(userViewModels);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Details(string email)
        {
            var user = await _userService.GetByEmailAsync(email);

            var userViewModel = _mapper.Map<UserViewModel>(user);

            return View(userViewModel);
        }

        [HttpGet("new")]
        public IActionResult Create()
        {
            var userCreationViewModel = new UserEditorViewModel
            {
                RolesSelectList = new SelectList(Roles.GetAll())
            };

            return View(userCreationViewModel);
        }

        [HttpPost("new")]
        public async Task<IActionResult> Create(UserEditorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserModel>(model);

                await _userService.EditAsync(user);

                return RedirectToAction("Details", new { email = model.User.Email });
            }

            model.RolesSelectList = new SelectList(Roles.GetAll());
            return View(model);
        }

        [HttpGet("{email}/update")]
        public async Task<IActionResult> Edit(string email)
        {
            var user = await _userService.GetByEmailAsync(email);

            if (user is null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            var userEditorViewModel = new UserEditorViewModel
            {
                User = _mapper.Map<UserViewModel>(user),
                RolesSelectList = new SelectList(Roles.GetAll())
            };

            return View(userEditorViewModel);
        }

        [HttpPost("{email}/update")]
        public async Task<IActionResult> Edit(UserEditorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserModel>(model);

                await _userService.EditAsync(user);

                return RedirectToAction("Details", new { email = model.User.Email });
            }

            model.RolesSelectList = new SelectList(Roles.GetAll());
            return View(model);
        }

        [HttpGet("{email}/remove")]
        public async Task<IActionResult> Delete(string email)
        {
            var user = await _userService.GetByEmailAsync(email);

            if (user is null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            var userViewModel = _mapper.Map<UserViewModel>(user);

            return View(userViewModel);
        }

        [HttpPost("{email}/remove")]
        public async Task<IActionResult> Delete(UserViewModel model)
        {
            await _userService.DeleteByEmailAsync(model.Email);

            return RedirectToAction("List");
        }
    }
}
