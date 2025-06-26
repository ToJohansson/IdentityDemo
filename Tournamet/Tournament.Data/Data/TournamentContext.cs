using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tournamet.Domain.Entities;

namespace Tournament.Infrastructure.Data;

public class TournamentContext : DbContext
{
    public TournamentContext(DbContextOptions<TournamentContext> options)
        : base(options)
    {
    }

    public DbSet<TournamentDetails> TournamentDetails { get; set; } = default!;
    public DbSet<Game> Game { get; set; } = default!;
}
