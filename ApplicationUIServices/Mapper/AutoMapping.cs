using ApplicationCQRS.Commands.UserC;
using ApplicationDatabaseModels;
using ApplicationDtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationUIServices.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Answer, AnswerDto>().ReverseMap();
            CreateMap<Topic, TopicDto>().ReverseMap();
            CreateMap<Ticket, TicketDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserCommand>()
                .ForMember(o => o.Infos, d => d.MapFrom(a => a.Infos))
                .ReverseMap();
            CreateMap<UserTestInfo, UserTestInfoDto>().ReverseMap();
        }
    }
}
