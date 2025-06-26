using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Application.Interfaces;
using Tournamet.Domain.Entities;
using Tournamet.Shared.Dto;

namespace Tournament.Application.Services;
public class GameService(IUnitOfWork unitOfWork) : IGameService
{
    public async Task<Game> Add(int tournamentId, GameDto game)
    {
        return await unitOfWork.GameRepository.Add(tournamentId, game);
    }

    public async Task<bool> AnyAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GameDto>> GetAllAsync(int id)
    {
        return unitOfWork.GameRepository.GetAllAsync(id);
    }

    public Task<GameDto> GetAsync(string id)
    {
        return unitOfWork.GameRepository.GetAsync(id);
    }

    public Task<GameDto?> GetByIdAsync(int id)
    {
        return unitOfWork.GameRepository.GetByIdAsync(id);
    }


    public async Task Remove(int game)
    {
        await unitOfWork.GameRepository.Remove(game);
        await IsPersisted();
    }

    public async Task Update(int tournamentId, GameDto game)
    {
        await unitOfWork.GameRepository.Update(tournamentId, game);
        await IsPersisted();

    }
    public async Task IsPersisted() => await unitOfWork.PersistAsync();

}
