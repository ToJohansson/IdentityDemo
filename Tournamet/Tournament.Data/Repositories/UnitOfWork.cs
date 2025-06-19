using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Repositories;
using Tournamet.Api.Data;

namespace Tournament.Data.Repositories;
public class UnitOfWork(TournamentContext context,
    ITournamentRepository tournamentRepository,
    IGameRepository gameRepository)
    : IUnitOfWork
{
    public ITournamentRepository TournamentRepository { get; } = tournamentRepository;

    public IGameRepository GameRepository { get; } = gameRepository;

    public async Task PersistAsync()
    {
        await context.SaveChangesAsync();
    }
}
