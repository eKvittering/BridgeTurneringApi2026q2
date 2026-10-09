using BridgeTourneringLib.Interfaces;
using BridgeTourneringLib.Models;
using BridgeTourneringLib.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BridgeTourneringREST.Controllers
{
	[Route("api/Tournaments")]
	public class TournamentController : Controller
	{
		private IMainTournamentRepository mainTournamentRepo;
		private IMainTournamentTeamRepository mainTournamentTeamRepo;
		private IGroupTournamentRepository groupTournamentRepo;

		[HttpGet("{clubNo}/MainTournaments")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<IEnumerable<MainTournament>>> GetMainTournaments(string clubNo)
		{
			mainTournamentRepo = new MainTournamentRepository(clubNo);
			IEnumerable<MainTournament> result = await mainTournamentRepo.GetMainTournamentAsync();
			if (result.Count() == 0)
			{
				return NoContent();
			}
			else
			{
				return Ok(result);
			}
		}

		[HttpGet("{clubNo}/MainTournaments/{mainTournamentId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<MainTournament>> GetMainTournamentByID(string clubNo, int mainTournamentId)
		{
			mainTournamentRepo = new MainTournamentRepository(clubNo);
			MainTournament result = await mainTournamentRepo.GetMainTournamentByIDAsync(mainTournamentId);
			if (result == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(result);
			}
		}

		[HttpGet("{clubNo}/MainTournamentTeams/{mainTournamentId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<IEnumerable<MainTournamentTeam>>> GetMainTournamentTeams(string clubNo, int mainTournamentId)
		{
			mainTournamentTeamRepo = new MainTournamentTeamRepository(clubNo);
			IEnumerable<MainTournamentTeam> result = await mainTournamentTeamRepo.GetMainTournamentTeamsByMainTournamentTeamIdAsync(mainTournamentId);
			if (result.Count() == 0)
			{
				return NoContent();
			}
			else
			{
				return Ok(result);
			}
		}

		[HttpGet("{clubNo}/GroupTournaments/{mainTournamentId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<IEnumerable<GroupTournament>>> GetGroupTournaments(string clubNo, int mainTournamentId)
		{
			groupTournamentRepo = new GroupTournamentRepository(clubNo);
			IEnumerable<GroupTournament> result = await groupTournamentRepo.GetGroupTournamentByMaintournamentIDAsync(mainTournamentId);
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
