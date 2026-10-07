using BridgeTourneringLib.Models;
using BridgeTourneringLib.Repositories;
using BridgeTourneringLib.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BridgeTourneringREST.Controllers
{
	[Route("api/Sections")]
	public class SectionController : Controller
	{
		private ISectionRepository sectionRepo;
		private ISectionTeamRepository sectionTeamRepo;

		[HttpGet("{clubNo}/Sections/{groupTournamentId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<IEnumerable<Section>>> GetSectionsByGroupTournamentIDAsync(string clubNo, int groupTournamentId)
		{
			sectionRepo = new SectionRepository(clubNo);
			IEnumerable<Section> result = await sectionRepo.GetSectionsByGroupTournamentIDAsync(groupTournamentId);
			if (result.Count() == 0)
			{
				return NoContent();
			}
			else
			{
				return Ok(result);
			}
		}

		[HttpGet("{clubNo}/SectionTeams/{sectionId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<IEnumerable<SectionTeam>>> GetSectionTeamsBySectionIDAsync(string clubNo, int sectionId)
		{
			sectionTeamRepo = new SectionTeamRepository(clubNo);
			IEnumerable<SectionTeam> result = await sectionTeamRepo.GetSectionTeamsBySectionIDAsync(sectionId);
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
