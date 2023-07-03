using EventsAPI.Entities;

namespace EventsAPI.Persistence
{
    public class EventsDbContext
    {
        public List<Event> Events { get; set; }

        public EventsDbContext() { 
            Events = new List<Event>();
        }
    }
}
