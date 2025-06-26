using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Application.Interfaces;
using Tournamet.Domain.Entities;
using Tournamet.Shared.Dto;

namespace Tournament.Application.Services;
public class TournamentService(ITournamentRepository tournamentRepository) : ITournamentService
{
    public Task Add(TournamentDetails tournament)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AnyAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TournamentDto>> GetAllAsync(bool includeGames)
    {
        throw new NotImplementedException();
    }

    public Task<TournamentDto> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task Remove(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(TournamentUpdateDto tournament)
    {
        throw new NotImplementedException();
    }
}
