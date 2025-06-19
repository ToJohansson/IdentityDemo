using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.Core.Dto;
public record GameDto
{
    int Id { get; init; }
    public string Title { get; init; }
    public DateTime StartTime { get; init; }
}
