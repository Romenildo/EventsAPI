using AutoMapper;
using EventsAPI.Entities;
using EventsAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase {


        private readonly EventsDbContext _context;
        private readonly IMapper _mapper;

        public EventsController(EventsDbContext context, IMapper mapper)
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
            var Event = _context.Events
                .Include(e=>e.Speakers)
                .SingleOrDefault(e => e.Id == id);

            if (Event == null) {
                return NotFound();
            }
            var EventDto = _mapper.Map<Event>(Event);
            return Ok(EventDto);
        }

        [HttpPost]
        public IActionResult Create(Event newEvent)
        {
            _context.Events.Add(newEvent);
            _context.SaveChanges();
  
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

            _context.Events.Update(Event);
            _context.SaveChanges();
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
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost("{id}/speakers")]
        public IActionResult AddSpeaket(Guid id, Speaker speaker) 
        {
            speaker.EventId = id;

            var Event = _context.Events.Any(e => e.Id == id);
            if (!Event)
            {
                return NotFound();
            }
            _context.Speakers.Add(speaker);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
