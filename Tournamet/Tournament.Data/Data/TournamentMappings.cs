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
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.StartDate.AddMonths(3)));

        CreateMap<Core.Entities.Game, Core.Dto.GameDto>();
        //.ForMember(dest => dest.TournamentId, opt => opt.MapFrom(src => src.TournamentId))
        //.ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
        //.ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time));
    }
}
