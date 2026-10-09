using BridgeTourneringLib.Interfaces;
using BridgeTourneringLib.Models;
using BridgeTourneringLib.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BridgeTourneringREST.Controllers
{
	[Route("api/Matches")]
	public class MatchController : Controller
	{
		private ITeamMatchRepository teamMatchRepo;

		[HttpGet("{clubNo}/TeamMatches/{roundId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<IEnumerable<TeamMatch>>> GetTeamMatchesByRoundID(string clubNo, int roundId)
		{
			teamMatchRepo = new TeamMatchRepository(clubNo);
			IEnumerable<TeamMatch> result = await teamMatchRepo.GetTeamMatchByRoundID(roundId);
			if (result.Count() == 0)
			{
				return NoContent();
			}
			else
			{
				return Ok(result);
			}
		}
	}
}
