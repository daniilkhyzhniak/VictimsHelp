using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VictimsHelp.BLL.Contracts;
using VictimsHelp.BLL.Enums;
using VictimsHelp.BLL.Models;
using VictimsHelp.PL.Authorization;
using VictimsHelp.PL.ViewModels.Account;

namespace VictimsHelp.PL.Controllers.Api
{
    [ApiController]
    [Route("api/account")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountApiController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenFactory _tokenFactory;
        private readonly IMapper _mapper;

        public AccountApiController(
            IUserService userService, 
            ITokenFactory tokenFactory,
            IMapper mapper)
        {
            _userService = userService;
            _tokenFactory = tokenFactory;
            _mapper = mapper;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
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
                    var token = _tokenFactory.CreateToken(claims);

                    return Ok(token);
                }

                ModelState.AddModelError("", "An error occurred.");
            }

            return BadRequest("Invalid data.");
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserModel>(model);
                var claims = (await _userService.AuthenticateAsync(user)).ToList();

                if (!claims.Any())
                {
                    return BadRequest("Invalid credentials.");
                }

                var token = _tokenFactory.CreateToken(claims);

                return Ok(token);
            }

            return BadRequest("Invalid credentials.");
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            var email = User.Identity.Name;

            if (string.IsNullOrWhiteSpace(email))
            {
                return BadRequest();
            }

            var user = await _userService.GetByEmailAsync(email);

            var profile = _mapper.Map<ProfileViewModel>(user);

            return Ok(profile);
        }

        [HttpPut("profile/update")]
        public async Task<IActionResult> Edit(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserModel>(model);

                await _userService.EditAsync(user);

                return RedirectToAction("Profile", new { email = model.Email });
            }

            return BadRequest("Model state is not valid.");
        }
    }
}
