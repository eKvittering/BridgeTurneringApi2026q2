using BridgeTourneringLib.Interfaces;
using BridgeTourneringLib.Models;
using BridgeTourneringLib.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BridgeTourneringREST.Controllers
{
	[Route("api/Results")]
	public class ResultController : Controller
	{
		private IResultRepository resultRepo;
		private IMatchResultRepository matchResult;

		[HttpGet("{clubNo}/Results/{matchId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<IEnumerable<Result>>> GetResultByMatchIDAsync(string clubNo, int matchId)
		{
			resultRepo = new ResultRepository(clubNo);
			IEnumerable<Result> result = await resultRepo.GetResultByMatchIDAsync(matchId);
			if (result.Count() == 0)
			{
				return NoContent();
			}
			else
			{
				return Ok(result);
			}
		}

		[HttpGet("{clubNo}/MatchResults/{groupTournamentId}/{roundNo}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<IEnumerable<MatchResult>>> GetMatchResultGroupTournamentIDAndRoundNoAsync(string clubNo, int groupTournamentId, int roundNo)
		{
			matchResult = new MatchResultRepository(clubNo);
			IEnumerable<MatchResult> result = await matchResult.GetMatchResultByGroupTournamentIDAndRoundNo(groupTournamentId, roundNo);
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
