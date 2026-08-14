using Microsoft.AspNetCore.Mvc;
using TennisKata.Api.Models;
using TennisKata.Core;

namespace TennisKata.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TennisController : ControllerBase
{
    private static Tennis _tennis = new Tennis("Player 1", "Player 2");

    /// <summary>
    /// GET: api/tennis/score
    /// Fetches the current score.
    /// </summary>
    
    [HttpGet("score")]
    public IActionResult GetScore()
    {
        // Ok(...) returns HTTP 200 with a JSON payload
        return Ok(new { Score = _tennis.GetScore() });
    }
    /// <summary>
    /// POST: api/tennis/point
    /// Adds a point to a player and returns the new score.
    /// </summary>
    [HttpPost("point")]
    public IActionResult PointWon([FromBody] PointRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Player))
        {
            // BadRequest returns HTTP 400
            return BadRequest(new { Message = "Player name cannot be empty." });
        }

        _tennis.PointWon(request.Player);

        return Ok(new 
        { 
            ScoredBy = request.Player, 
            CurrentScore = _tennis.GetScore() 
        });
    }

    /// <summary>
    /// POST: api/tennis/reset
    /// Starts a fresh game.
    /// </summary>
    [HttpPost("reset")]
    public IActionResult ResetGame()
    {
        _tennis = new Tennis("Player 1", "Player 2");
        return Ok(new { Message = "Game reset successfully.", Score = _tennis.GetScore() });
    }

}