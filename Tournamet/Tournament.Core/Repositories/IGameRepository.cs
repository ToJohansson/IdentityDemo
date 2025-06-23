using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Dto;
using Tournament.Core.Entities;

namespace Tournament.Core.Repositories;
public interface IGameRepository
{
    Task<IEnumerable<GameDto>> GetAllAsync(int id);
    Task<GameDto> GetAsync(int id);
    Task<bool> AnyAsync(int id);
    Task<Game> Add(int tournamentId, GameDto game);
    Task Update(int tournamentId, GameDto game);
    Task Remove(int game);
}
