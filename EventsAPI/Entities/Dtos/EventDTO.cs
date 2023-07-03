namespace EventsAPI.Entities.Dtos
{
    public class EventDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Speaker> Speakers { get; set; }
        public bool IsOver { get; set; }
    }
}
