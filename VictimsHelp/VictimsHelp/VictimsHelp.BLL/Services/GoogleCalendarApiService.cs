using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VictimsHelp.BLL.Contracts;
using VictimsHelp.BLL.Models;

namespace VictimsHelp.BLL.Services
{
    public class GoogleCalendarApiService : IGoogleCalendarApiService
    {
        private readonly CalendarService _googleCalendarApiService;
        private readonly IPsychologistService _psychologistService;

        public GoogleCalendarApiService(
            IGoogleCalendarApiContext googleCalendarApiContext,
            IPsychologistService psychologistService)
        {
            _googleCalendarApiService = new CalendarService(new BaseClientService.Initializer()
            {
                ApplicationName = googleCalendarApiContext.ApplicationName,
                HttpClientInitializer = googleCalendarApiContext.HttpClientInitializer
            });
            _psychologistService = psychologistService;
        }

        public async Task<IList<Event>> GetUpcomingEventsAsync(string email)
        {
            EventsResource.ListRequest request = _googleCalendarApiService.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.TimeMax = DateTime.Now.AddDays(7);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            Events events = await request.ExecuteAsync();

            IList<Event> userEvents = events.Items
                .Where(e => e.Attendees.Select(a => a.Email).Contains(email))
                .ToList();

            return userEvents;
        }

        public async Task<string> OrganizeEmergencyMeetingAsync(string clientEmail)
        {
            var psychologists = await _psychologistService.GetAllAsync();
            var eventAtendees = psychologists.Select(p => new EventAttendee { Email = p.Email }).ToList();
            eventAtendees.Add(new EventAttendee { Email = clientEmail });

            var newEvent = CreateEvent(DateTime.Now, DateTime.Now.AddMinutes(30), eventAtendees, "Emergency meeting");

            var request = new EventsResource.InsertRequest(_googleCalendarApiService, newEvent, "primary")
            {
                ConferenceDataVersion = 1,
            };

            var resultEvent = await request.ExecuteAsync();

            return resultEvent.HangoutLink;
        }

        public async Task<string> OrganizeMeetingAsync(OrganizeEventModel model)
        {
            var eventAtendees = model.Emails.Select(email => new EventAttendee { Email = email }).ToList();

            var newEvent = CreateEvent(model.StartDateTime, model.EndDateTime, eventAtendees, "Regular meeting");

            var request = new EventsResource.InsertRequest(_googleCalendarApiService, newEvent, "primary") 
            { 
                ConferenceDataVersion = 1,
            };

            var resultEvent = await request.ExecuteAsync();

            return resultEvent.HangoutLink;
        }

        private Event CreateEvent(
            DateTime start, 
            DateTime end, 
            IList<EventAttendee> attendees, 
            string meetingTitle)
        {
            return new Event()
            {
                Start = new EventDateTime { DateTime = start },
                End = new EventDateTime { DateTime = end },
                Attendees = attendees,
                ConferenceData = new ConferenceData
                {
                    CreateRequest = new CreateConferenceRequest()
                    {
                        RequestId = "fjdsjfp023",
                        ConferenceSolutionKey = new ConferenceSolutionKey { Type = "hangoutsMeet" },
                    }
                },
                Summary = meetingTitle,
                Location = "online",
                Kind = "calendar#event"
            };
        }
    }
}
