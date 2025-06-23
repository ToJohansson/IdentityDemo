using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Dto;
using Tournament.Core.Entities;

namespace Tournament.Core.Repositories;
public interface ITournamentRepository
{
    Task<IEnumerable<TournamentDto>> GetAllAsync();
    Task<TournamentDto> GetAsync(int id);
    Task<bool> AnyAsync(int id);
    Task Add(TournamentDetails tournament);
    Task Update(TournamentUpdateDto tournament);
    Task Remove(int id);
}
