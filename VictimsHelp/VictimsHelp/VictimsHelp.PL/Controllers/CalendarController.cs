using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VictimsHelp.BLL.Contracts;
using VictimsHelp.BLL.Enums;
using VictimsHelp.BLL.Models;
using VictimsHelp.PL.ViewModels.Calendar;

namespace VictimsHelp.PL.Controllers
{
    [Authorize]
    [Route("calendar")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CalendarController : Controller
    {
        private readonly IGoogleCalendarApiService _googleCalendarApiService;
        private readonly IMapper _mapper;

        public CalendarController(IGoogleCalendarApiService googleCalendarApiService, IMapper mapper)
        {
            _googleCalendarApiService = googleCalendarApiService;
            _mapper = mapper;
        }

        [HttpGet("events")]
        public async Task<IActionResult> Events()
        {
            var email = HttpContext.User.Identity.Name;
            var events = await _googleCalendarApiService.GetUpcomingEventsAsync(email);

            var models = _mapper.Map<IEnumerable<EventViewModel>>(events);

            return View(models);
        }

        [HttpPost("~/{email}/meeting")]
        [Authorize(Roles = Roles.Psychologist)]
        public async Task<IActionResult> Meeting(OrganizeEventModel model, string email)
        {
            model.Emails.Add(HttpContext.User.Identity.Name);
            model.Emails.Add(email);

            await _googleCalendarApiService.OrganizeMeetingAsync(model);

            return RedirectToAction("Events");
        }
    }
}
