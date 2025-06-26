using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Application.Interfaces;
using Tournamet.Domain.Entities;
using Tournamet.Shared.Dto;

namespace Tournament.Application.Services;
public class TournamentService(IUnitOfWork unitOfWork) : ITournamentService
{
    public async Task Add(TournamentDetails tournament)
    {
        await unitOfWork.TournamentRepository.Add(tournament);
        await IsPersisted();
    }

    public Task<bool> AnyAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TournamentDto>> GetAllAsync(bool includeGames)
    {
        return unitOfWork.TournamentRepository.GetAllAsync(includeGames);
    }

    public Task<TournamentDto> GetAsync(int id)
    {
        return unitOfWork.TournamentRepository.GetAsync(id);
    }

    public async Task Remove(int id)
    {
        await unitOfWork.TournamentRepository.Remove(id);
        await IsPersisted();
    }

    public async Task Update(TournamentUpdateDto tournament)
    {
        await unitOfWork.TournamentRepository.Update(tournament);
        await IsPersisted();
    }
    public async Task IsPersisted() => await unitOfWork.PersistAsync();

}
