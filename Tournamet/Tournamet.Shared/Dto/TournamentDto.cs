using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournamet.Shared.Dto;
public record TournamentDto(int Id, string Title, DateTime Startdate)
{
    public DateTime EndDate => Startdate.AddMonths(3);
    public ICollection<GameDto> GameDtos { get; set; } = new List<GameDto>();
}
