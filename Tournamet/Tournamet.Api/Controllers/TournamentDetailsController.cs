using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tournament.Core.Dto;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Tournamet.Api.Data;

namespace Tournamet.Api.Controllers
{
    [Route("api/tournament")]
    [ApiController]
    public class TournamentDetailsController(IUnitOfWork unitOfWork) : ControllerBase
    {

        // GET: api/TournamentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentDto>>> GetTournamentDetails()
        {
            var tournaments = await unitOfWork.TournamentRepository.GetAllAsync();
            return Ok(tournaments);
        }

        // GET: api/TournamentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentDto>> GetTournamentDetails(int id)
        {
            var tournamentDetails = await unitOfWork.TournamentRepository.GetAsync(id);
            if (tournamentDetails == null)
            {
                return NotFound();
            }
            return tournamentDetails;
        }

        // PUT: api/TournamentDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("")]
        public async Task<IActionResult> PutTournamentDetails(TournamentUpdateDto tournamentDetails)
        {

            await unitOfWork.TournamentRepository.Update(tournamentDetails);

            await unitOfWork.PersistAsync();

            return NoContent();
        }

        // POST: api/TournamentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TournamentDetails>> PostTournamentDetails(TournamentDetails tournamentDetails)
        {
            unitOfWork.TournamentRepository.Add(tournamentDetails);
            await unitOfWork.PersistAsync();

            return CreatedAtAction("GetTournamentDetails", new { id = tournamentDetails.Id }, tournamentDetails);
        }

        // DELETE: api/TournamentDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournamentDetails(int id)
        {

            unitOfWork.TournamentRepository.Remove(id);
            await unitOfWork.PersistAsync();

            return NoContent();
        }


    }
}
