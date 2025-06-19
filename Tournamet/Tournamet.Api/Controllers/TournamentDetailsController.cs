using System;
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
    [Route("api/tournament")]
    [ApiController]
    public class TournamentDetailsController(TournamentContext context, IUnitOfWork unitOfWork) : ControllerBase
    {

        // GET: api/TournamentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentDetails>>> GetTournamentDetails()
        {
            //return await context.TournamentDetails.ToListAsync();
            return await context.TournamentDetails
                .Include(t => t.Games)
                .ToListAsync();
        }

        // GET: api/TournamentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentDetails>> GetTournamentDetails(int id)
        {
            //var tournamentDetails = await context.TournamentDetails.FindAsync(id);
            var tournamentDetails = await context.TournamentDetails
                .Include(t => t.Games)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tournamentDetails == null)
            {
                return NotFound();
            }

            return tournamentDetails;
        }

        // PUT: api/TournamentDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournamentDetails(int id, TournamentDetails tournamentDetails)
        {
            if (id != tournamentDetails.Id)
            {
                return BadRequest();
            }

            //context.Entry(tournamentDetails).State = EntityState.Modified;
            unitOfWork.TournamentRepository.Update(tournamentDetails);

            try
            {
                //await context.SaveChangesAsync();
                await unitOfWork.PersistAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentDetailsExists(id))
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

        // POST: api/TournamentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TournamentDetails>> PostTournamentDetails(TournamentDetails tournamentDetails)
        {
            //context.TournamentDetails.Add(tournamentDetails);
            unitOfWork.TournamentRepository.Add(tournamentDetails);
            await unitOfWork.PersistAsync();

            //await context.SaveChangesAsync();

            return CreatedAtAction("GetTournamentDetails", new { id = tournamentDetails.Id }, tournamentDetails);
        }

        // DELETE: api/TournamentDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournamentDetails(int id)
        {
            //var tournamentDetails = await context.TournamentDetails.FindAsync(id);
            var tournamentDetails = await context.TournamentDetails
                .Include(t => t.Games)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tournamentDetails == null)
            {
                return NotFound();
            }

            context.TournamentDetails.Remove(tournamentDetails);
            await unitOfWork.PersistAsync();

            //await context.SaveChangesAsync();

            return NoContent();
        }

        private bool TournamentDetailsExists(int id)
        {
            //return context.TournamentDetails.Any(e => e.Id == id);
            return context.TournamentDetails
                .Include(t => t.Games)
                .Any(e => e.Id == id);
        }
    }
}
