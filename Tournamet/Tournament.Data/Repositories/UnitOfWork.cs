using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Application.Interfaces;
using Tournament.Infrastructure.Data;

namespace Tournament.Infrastructure.Repositories;
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
