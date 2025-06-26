using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Tournament.Application.Interfaces;
using Tournamet.Domain.Entities;
using Tournamet.Shared.Dto;

namespace Tournamet.Api.Controllers;

[Route("api/tournament/{tournamentId:int}/games")]
[ApiController]
public class GamesController(IUnitOfWork unitOfWork) : ControllerBase
{

    // GET: api/Games
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GameDto>>> GetAllGames([FromRoute] int tournamentId)
    {
        var games = await unitOfWork.GameRepository.GetAllAsync(tournamentId);
        return Ok(games);

    }

    //// GET: api/Games/5
    [HttpGet("{id}")]
    public async Task<ActionResult<GameDto>> GetGame(string id)
    {
        var game = await unitOfWork.GameRepository.GetAsync(id);

        if (game == null)
        {
            return NotFound();
        }

        return game;
    }


    //// POST: api/Games
    //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Game>> PostGame([FromRoute] int tournamentId, GameDto game)
    {
        var createdGame = await unitOfWork.GameRepository.Add(tournamentId, game);
        await unitOfWork.PersistAsync();

        return CreatedAtAction(
            nameof(GetGame),
            new { tournamentId = tournamentId, id = createdGame.Id },
            createdGame
        );
    }

    //// PUT: api/Games/5
    //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("")]
    public async Task<IActionResult> PutGame([FromRoute] int tournamentId, GameDto game)
    {
        await unitOfWork.GameRepository.Update(tournamentId, game);
        await unitOfWork.PersistAsync();

        return NoContent();
    }


    //// DELETE: api/Games/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(int id)
    {
        await unitOfWork.GameRepository.Remove(id);
        await unitOfWork.PersistAsync();

        return NoContent();
    }


    /// <summary>
    /// Partially updates a game.
    /// </summary>
    /// <remarks>
    /// These three values are required in the JSON body: delete the other properties.
    /// Sample request:
    /// [
    ///   {
    ///     "op": "replace",
    ///     "path": "/title",
    ///     "value": "New Title"
    ///   }
    /// ]
    /// </remarks>
    [HttpPatch("{id:int}")]
    public async Task<IActionResult> PatchGame(
        [FromRoute] int tournamentId,
         int id,
        JsonPatchDocument<GameDto> patchDocument)
    {
        if (patchDocument is null)
            return BadRequest("No patch document provided.");

        var gameDto = await unitOfWork.GameRepository.GetByIdAsync(id);
        if (gameDto == null || gameDto.Id != id)
            return NotFound("Game does not exist.");

        patchDocument.ApplyTo(gameDto, ModelState);
        if (!TryValidateModel(gameDto))
            return UnprocessableEntity(ModelState);

        await unitOfWork.GameRepository.Update(tournamentId, gameDto);
        await unitOfWork.PersistAsync();

        return NoContent();
    }
}
