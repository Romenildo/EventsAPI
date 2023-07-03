namespace EventsAPI.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<Speaker> Speakers { get; set; }
    
        public bool IsOver { get; set; }

        public Event() 
        {
            Speakers = new List<Speaker>();
            IsOver= false;
        }

        public void Update(string title, string description, DateTime startDate, DateTime endDate)
        {
            Title= title;
            Description= description;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void Finish() {
            IsOver = true;
        }
    }
}
