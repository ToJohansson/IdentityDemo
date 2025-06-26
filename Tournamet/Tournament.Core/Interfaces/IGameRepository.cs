using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournamet.Domain.Entities;
using Tournamet.Shared.Dto;

namespace Tournament.Application.Interfaces;
public interface IGameRepository
{
    Task<IEnumerable<GameDto>> GetAllAsync(int id);
    Task<GameDto?> GetByIdAsync(int id);
    Task<GameDto> GetAsync(string id);
    Task<bool> AnyAsync(int id);
    Task<Game> Add(int tournamentId, GameDto game);
    Task Update(int tournamentId, GameDto game);
    Task Remove(int game);
}
