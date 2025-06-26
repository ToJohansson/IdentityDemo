using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournamet.Shared.Dto;
public record TournamentUpdateDto(int Id, string Title, DateTime Startdate)
{
    public DateTime EndDate => Startdate.AddMonths(3);
}