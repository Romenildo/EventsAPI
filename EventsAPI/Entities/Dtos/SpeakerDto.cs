namespace EventsAPI.Entities.Dtos
{
    public class SpeakerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TalkTitle { get; set; }
        public string TalkDescription { get; set; }
    }
}
