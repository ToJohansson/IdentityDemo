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

    }
}
