using GladOS.Core.Models;


namespace GladOS.Core.Services
{
    public class EventProperties : IEventProperties
    {

        public Event CreateEvent()
        {
            return new Event()
            {
                EventTitle = "",
                StartTime = "",
                EndTime = "",

            };
        }

        public Event CreateEvent(string eventTitle, string startTime, string endTime)
        {
            return new Event()
            {
                EventTitle = eventTitle,
                StartTime = startTime,
                EndTime = endTime,
            };
        }
    }
}
