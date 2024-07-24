using AutoMapper;
using TravelWithMe.Event.Dtos.EventDetailDtos;
using TravelWithMe.Event.Dtos.EventDtos;
using TravelWithMe.Event.Dtos.EventImageDtos;
using TravelWithMe.Event.Dtos.ParticipantDtos;
using TravelWithMe.Event.Dtos.UserDtos;
using TravelWithMe.Event.Entities;


namespace TravelWithMe.Event.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<TravelWithMe.Event.Entities.Event, CreateEventDto>().ReverseMap();
            CreateMap<TravelWithMe.Event.Entities.Event, UpdateEventDto>().ReverseMap();
            CreateMap<TravelWithMe.Event.Entities.Event, GetByIdEventDto>().ReverseMap();
            CreateMap<TravelWithMe.Event.Entities.Event, ResultEventDto>().ReverseMap();

            CreateMap<EventDetail, CreateEventDetailDto>().ReverseMap();
            CreateMap<EventDetail, UpdateEventDetailDto>().ReverseMap();
            CreateMap<EventDetail, GetByIdEventDetailDto>().ReverseMap();
            CreateMap<EventDetail, ResultEventDetailDto>().ReverseMap();

            CreateMap<EventImage, CreateEventImageDto>().ReverseMap();
            CreateMap<EventImage, UpdateEventImageDto>().ReverseMap();
            CreateMap<EventImage, GetByIdEventImageDto>().ReverseMap();
            CreateMap<EventImage, ResultEventImageDto>().ReverseMap();

            CreateMap<Participant, CreateParticipantDto>().ReverseMap();
            CreateMap<Participant, UpdateParticipantDto>().ReverseMap();
            CreateMap<Participant, GetByIdParticipantDto>().ReverseMap();
            CreateMap<Participant, ResultParticipantDto>().ReverseMap();

            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, GetByIdUserDto>().ReverseMap();
            CreateMap<User, ResultUserDto>().ReverseMap();
        }
    }
}
