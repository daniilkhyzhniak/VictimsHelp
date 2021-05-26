using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VictimsHelp.BLL.Contracts;
using VictimsHelp.BLL.Enums;
using VictimsHelp.BLL.Models;
using VictimsHelp.PL.ViewModels.Account;

namespace VictimsHelp.PL.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("account")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IActionResult> VerifyEmail(string email)
        {
            var user = await _userService.GetByEmailAsync(email);
            return Json(user is null);
        }

        [HttpGet("~/register")]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("~/register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = await _userService.GetByEmailAsync(model.Email);

            if (user != null)
            {
                ModelState.AddModelError("Email", $"Email '{model.Email}' is already in use.");
            }

            if (ModelState.IsValid)
            {
                var newUser = _mapper.Map<UserModel>(model);
                newUser.Roles = new List<string> { Roles.Client };

                var result = await _userService.CreateAsync(newUser);

                if (result)
                {
                    var claims = (await _userService.AuthenticateAsync(newUser)).ToList();
                    await SignInAsync(claims);

                    return RedirectToAction("List", "Article");
                }

                ModelState.AddModelError("", "An error occurred.");
            }

            return BadRequest("Invalid data.");
        }

        [HttpGet("~/login")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("~/login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserModel>(model);
                var claims = (await _userService.AuthenticateAsync(user)).ToList();
                if (!claims.Any())
                {
                    ModelState.AddModelError("", "Invalid credentials.");
                }
                else
                {
                    await SignInAsync(claims);

                    if (!string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("List", "Article");
                }
            }
            return View(model);
        }

        [HttpPost("~/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("List", "Article");
        }

        [HttpGet("~/profile/update")]
        public async Task<IActionResult> Edit()
        {
            var email = User.Identity.Name;
            var user = await _userService.GetByEmailAsync(email);

            if (user is null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            var profile = _mapper.Map<ProfileViewModel>(user);

            return View(profile);
        }

        [HttpPost("~/profile/update")]
        public async Task<IActionResult> Edit(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserModel>(model);

                await _userService.EditAsync(user);

                return RedirectToAction("Profile", new { email = model.Email });
            }

            return View(model);
        }

        [HttpGet("~/profile")]
        public async Task<IActionResult> Profile()
        {
            var email = User.Identity.Name;
            var user = await _userService.GetByEmailAsync(email);

            if (user is null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            var profile = _mapper.Map<ProfileViewModel>(user);

            return View(profile);
        }

        private async Task SignInAsync(IEnumerable<Claim> claims)
        {
            var identity = new ClaimsIdentity(
                claims,
                "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        }
    }
}
