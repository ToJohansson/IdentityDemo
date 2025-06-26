using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournamet.Domain.Entities;
using Tournamet.Shared.Dto;

namespace Tournament.Infrastructure.Data;
public class TournamentMappings : Profile
{
    public TournamentMappings()
    {
        CreateMap<TournamentDetails, TournamentDto>()
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.StartDate.AddMonths(3)))
            .ForMember(dest => dest.GameDtos, opt => opt.MapFrom(src => src.Games));


        CreateMap<Game, GameDto>();
        CreateMap<GameDto, Game>();
        CreateMap<TournamentUpdateDto, TournamentDetails>()
            .ForMember(dest => dest.Games, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.Startdate));

    }
}
