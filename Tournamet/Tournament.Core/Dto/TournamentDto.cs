using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.Core.Dto;
public record TournamentDto(string Title, DateTime Startdate)
{
    public DateTime EndDate => Startdate.AddMonths(3);
}
