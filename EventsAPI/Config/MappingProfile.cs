using AutoMapper;
using EventsAPI.Entities;
using EventsAPI.Entities.Dtos;

namespace EventsAPI.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Event, EventDTO>();
            CreateMap<Speaker, SpeakerDto>();
        }
    }
}
