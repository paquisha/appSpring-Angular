using AutoMapper;
using Nexti.Application.Dtos.Request;
using Nexti.Application.Dtos.Response;
using Nexti.Domain.Entities;
using Nexti.Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexti.Application.Mappers
{
    public class EventoMappingProfile : Profile
    {
        public EventoMappingProfile()
        {
            CreateMap<BaseEntityResponse<Evento>, BaseEntityResponse<EventoResponseDto>>()
                .ReverseMap();

            CreateMap<EventoRequestDto, Evento>();

            CreateMap<Evento, EventoSelectResponseDto>()
                .ReverseMap();
        }
    }
}