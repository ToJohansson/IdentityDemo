﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Tournamet.Api.Data;

namespace Tournamet.Api.Controllers
{
    [Route("api/tournament/{tournamentId:int}/games")]
    [ApiController]
    public class GamesController(TournamentContext context, IUnitOfWork unitOfWork) : ControllerBase
    {

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGame()
        {
            //return await context.Game.ToListAsync();
            return await context.Game
                .Include(g => g.Tournament)
                .ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await context.Game.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }

            context.Entry(game).State = EntityState.Modified;

            try
            {
                //await context.SaveChangesAsync();
                await unitOfWork.PersistAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            context.Game.Add(game);
            //await context.SaveChangesAsync();
            await unitOfWork.PersistAsync();


            return CreatedAtAction("GetGame", new { id = game.Id }, game);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            context.Game.Remove(game);
            await unitOfWork.PersistAsync();

            //await context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameExists(int id)
        {
            return context.Game.Any(e => e.Id == id);
        }
    }
}
