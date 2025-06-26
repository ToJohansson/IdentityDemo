using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Application.Interfaces;
using Tournamet.Domain.Entities;
using Tournamet.Shared.Dto;

namespace Tournament.Application.Services;
public class GameService(IGameRepository gameRepository) : IGameService
{
    public Task<Game> Add(int tournamentId, GameDto game)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AnyAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GameDto>> GetAllAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<GameDto> GetAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<GameDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task Remove(int game)
    {
        throw new NotImplementedException();
    }

    public Task Update(int tournamentId, GameDto game)
    {
        throw new NotImplementedException();
    }
}
