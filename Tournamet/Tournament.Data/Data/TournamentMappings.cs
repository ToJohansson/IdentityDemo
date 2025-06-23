using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.Data.Data;
public class TournamentMappings : Profile
{
    public TournamentMappings()
    {
        CreateMap<Core.Entities.TournamentDetails, Core.Dto.TournamentDto>()
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.StartDate.AddMonths(3)))
            .ForMember(dest => dest.GameDtos, opt => opt.MapFrom(src => src.Games));


        CreateMap<Core.Entities.Game, Core.Dto.GameDto>();
        CreateMap<Core.Dto.GameDto, Core.Entities.Game>();
        CreateMap<Core.Dto.TournamentUpdateDto, Core.Entities.TournamentDetails>()
            .ForMember(dest => dest.Games, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.Startdate));

    }
}
