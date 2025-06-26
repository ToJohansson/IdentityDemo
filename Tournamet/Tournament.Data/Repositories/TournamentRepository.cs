using AutoMapper.QueryableExtensions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tournament.Infrastructure.Data;
using Tournament.Application.Interfaces;
using Tournamet.Shared.Dto;
using Tournamet.Domain.Entities;


namespace Tournament.Infrastructure.Repositories;
public class TournamentRepository(TournamentContext context, IMapper mapper) : ITournamentRepository
{
    public async Task Add(TournamentDetails tournament)
    {
        await context.AddAsync(tournament);
    }

    public Task<bool> AnyAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TournamentDto>> GetAllAsync(bool includeGames = false)
    {
        var tournament = includeGames ? mapper.Map<IEnumerable<TournamentDto>>(await context.TournamentDetails.Include(t => t.Games).ToListAsync())

                            : mapper.Map<IEnumerable<TournamentDto>>(await context.TournamentDetails.ToListAsync());

        return tournament;
    }

    public async Task<TournamentDto?> GetAsync(int id)
    {
        var tournament = await context.TournamentDetails
            .Include(t => t.Games)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (tournament == null)
            return null;

        return mapper.Map<TournamentDto>(tournament);
    }


    public async Task Remove(int id)
    {
        var tournament = await TournamentDetailsExists(id);

        if (tournament == null)
            throw new Exception("Tournament not found");

        context.TournamentDetails.Remove(tournament);
    }

    public async Task Update(TournamentUpdateDto tournament)
    {
        var existing = await context.TournamentDetails
            .Include(t => t.Games)
            .FirstOrDefaultAsync(t => t.Id == tournament.Id);

        if (existing == null)
            throw new Exception("Tournament not found");

        // Update properties
        mapper.Map(tournament, existing);
    }


    private async Task<TournamentDetails?> TournamentDetailsExists(int id)
    {
        return await context.TournamentDetails
           .Include(t => t.Games)
           .FirstOrDefaultAsync(t => t.Id == id);
    }

}
