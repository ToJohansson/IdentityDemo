using Tournamet.Domain.Entities;
using Tournamet.Shared.Dto;

namespace Tournament.Application.Interfaces;

public interface ITournamentService
{
    Task<IEnumerable<TournamentDto>> GetAllAsync(bool includeGames);
    Task<TournamentDto> GetAsync(int id);
    Task<bool> AnyAsync(int id);
    Task Add(TournamentDetails tournament);
    Task Update(TournamentUpdateDto tournament);
    Task Remove(int id);
}
