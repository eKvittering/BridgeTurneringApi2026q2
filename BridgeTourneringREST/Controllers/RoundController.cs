using BridgeTourneringLib.Interfaces;
using BridgeTourneringLib.Models;
using BridgeTourneringLib.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BridgeTourneringREST.Controllers
{
	[Route("api/Rounds")]
	public class RoundController : Controller
	{
		private IRoundRepository roundRepo;
		private IRoundMatchRepository roundMatchRepo;
		private IRoundTeamRepository roundTeamRepo;

		[HttpGet("{clubNo}/Rounds/{sectionId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<IEnumerable<Round>>> GetRoundsBySectionIDAsync(string clubNo, int sectionId)
		{
			roundRepo = new RoundRepository(clubNo);
			IEnumerable<Round> result = await roundRepo.GetRoundsBySectionId(sectionId);
			if (result.Count() == 0)
			{
				return NoContent();
			}
			else
			{
				return Ok(result);
			}
		}

		[HttpGet("{clubNo}/RoundMatches/{roundId1}/{roundId2}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<IEnumerable<RoundMatch>>> GetRoundsByRoundIDTupleAsync(string clubNo, int roundId1, int roundId2)
		{
			roundMatchRepo = new RoundMatchRepository(clubNo);
			IEnumerable<RoundMatch> result = await roundMatchRepo.GetRoundMatchByRoundIdTuple(roundId1, roundId2);
			if (result.Count() == 0)
			{
				return NoContent();
			}
			else
			{
				return Ok(result);
			}
		}

		[HttpGet("{clubNo}/RoundTeams/{roundId1}/{roundId2}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<IEnumerable<RoundTeam>>> GetRoundTeamsByRoundIDTupleAsync(string clubNo, int roundId1, int roundId2)
		{
			roundTeamRepo = new RoundTeamRepository(clubNo);
			IEnumerable<RoundTeam> result = await roundTeamRepo.GetRoundTeamsByRoundIdTupleAsync(roundId1, roundId2);
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
