using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VictimsHelp.BLL.Contracts;
using VictimsHelp.BLL.Enums;
using VictimsHelp.PL.ViewModels.Calendar;

namespace VictimsHelp.PL.Controllers.Api
{
    [ApiController]
    [Route("api/calendar")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CalendarApiController : Controller
    {
        private readonly IGoogleCalendarApiService _googleCalendarApiService;
        private readonly IMapper _mapper;

        public CalendarApiController(IGoogleCalendarApiService googleCalendarApiService, IMapper mapper)
        {
            _googleCalendarApiService = googleCalendarApiService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns list of current user's events
        /// </summary>
        /// <returns></returns>
        [HttpGet("events")]
        public async Task<IActionResult> Events()
        {
            var email = HttpContext.User.Identity.Name;
            var events = await _googleCalendarApiService.GetUpcomingEventsAsync(email);

            var models = _mapper.Map<IEnumerable<EventViewModel>>(events);

            return Ok(models);
        }
        
        /// <summary>
        /// Returns link to google meet
        /// </summary>
        /// <param name="email">Required only for guest user</param>
        /// <returns></returns>
        [HttpPost("emergencyCall/{email?}")]
        public async Task<IActionResult> EmergencyMeeting(string email = null)
        {
            if (string.IsNullOrWhiteSpace(email) && !HttpContext.User.IsInRole(Roles.Client))
            {
                return BadRequest();
            }

            email ??= HttpContext.User.Identity.Name;
            var link = await _googleCalendarApiService.OrganizeEmergencyMeetingAsync(email);

            return Ok(link);
        }
    }
}
