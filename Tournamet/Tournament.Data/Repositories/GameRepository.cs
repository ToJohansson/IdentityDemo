using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Dto;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Tournamet.Api.Data;

namespace Tournament.Data.Repositories;
public class GameRepository(TournamentContext context, IMapper mapper) : IGameRepository
{
    public async Task<Game> Add(int tournamentId, GameDto gameDto)
    {
        var tournament = await context.TournamentDetails
            .Include(t => t.Games)
            .FirstOrDefaultAsync(t => t.Id == tournamentId);

        if (tournament == null)
            throw new Exception("Tournament not found");

        var game = mapper.Map<Game>(gameDto);

        game.TournamentId = tournamentId;

        tournament.Games.Add(game);
        return game;
    }

    public Task<bool> AnyAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<GameDto>> GetAllAsync(int id)
    {
        return await context.Game
            .Where(g => g.TournamentId == id)
            .ProjectTo<GameDto>(mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<GameDto?> GetAsync(int id)
    {
        var game = await context.Game
            .FirstOrDefaultAsync(g => g.Id.Equals(id));

        return mapper.Map<GameDto>(game);
    }

    public async Task Remove(int id)
    {
        var game = await context.Game
            .FirstOrDefaultAsync(g => g.Id.Equals(id));
        if (game == null)
        {
            throw new Exception("Game not found");
        }
        context.Game.Remove(game);
    }

    public async Task Update(int tournamentId, GameDto gameDto)
    {

        var tournament = await context.TournamentDetails
        .Include(t => t.Games)
        .FirstOrDefaultAsync(t => t.Id == tournamentId);

        if (tournament == null)
            throw new Exception("Tournament not found");


        var existingGame = tournament.Games
            .FirstOrDefault(g => g.Id == gameDto.Id);
        if (existingGame == null)
        {
            throw new Exception("Game not found");
        }
        mapper.Map(gameDto, existingGame);
        //context.Game.Update(existingGame);
    }
    private bool GameExists(int id)
    {
        return context.Game.Any(e => e.Id == id);
    }
}
