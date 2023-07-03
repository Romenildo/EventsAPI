using EventsAPI.Entities;
using EventsAPI.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase {


        private readonly EventsDbContext _context;
        public EventsController(EventsDbContext context) 
        {
            _context= context;
        }

        [HttpGet]
        public IActionResult GetAll() 
        { 
            var Events = _context.Events.Where(e=> !e.IsOver).ToList();
            return Ok(Events);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Event = _context.Events.SingleOrDefault(e => e.Id == id);

            if (Event == null) {
                return NotFound();
            }
            return Ok(Event);
        }

        [HttpPost]
        public IActionResult Create(Event newEvent)
        {
            _context.Events.Add(newEvent);
  
            return CreatedAtAction(nameof(GetById), new { id = newEvent.Id }, newEvent);

        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Event updEvent)
        {
            var Event = _context.Events.SingleOrDefault(e => e.Id == id);

            if (Event == null)
            {
                return NotFound();
            }
            Event.Update(updEvent.Title, updEvent.Description, updEvent.StartDate, updEvent.EndDate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var Event = _context.Events.SingleOrDefault(e => e.Id == id);
            if (Event == null)
            {
                return NotFound();
            }
            Event.Finish();

            return NoContent();
        }

        [HttpPost("{id}/speakers")]
        public IActionResult AddSpeaket(Guid id, Speaker speaker) 
        {
            var Event = _context.Events.SingleOrDefault(e => e.Id == id);
            if (Event == null)
            {
                return NotFound();
            }
            Event.Speakers.Add(speaker);
            return NoContent();
        }
    }
}
