using gladOS.Core.Models;

namespace gladOS.Core.Services
{
    public interface IEventProperties
    {
        Event CreateEvent();

        Event CreateEvent(string EventName, string StartTime, string EndTime);

    }
}
