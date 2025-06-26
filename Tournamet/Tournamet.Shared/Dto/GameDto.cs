﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournamet.Shared.Dto;
public record GameDto
{
    public int Id { get; init; }
    public string Title { get; init; }
    public DateTime Time { get; init; }
}
