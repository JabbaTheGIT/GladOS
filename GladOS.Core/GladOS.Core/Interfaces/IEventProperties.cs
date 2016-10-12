using GladOS.Core.Models;

namespace GladOS.Core.Services
{
    public interface IEventProperties
    {
        Event CreateEvent();

        Event CreateEvent(string EventName, string StartTime, string EndTime);

    }
}
