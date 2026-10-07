using BridgeTourneringLib.Models;

namespace BridgeTourneringLib.Interfaces
{
	public interface ISectionTeamRepository
	{
		Task<IEnumerable<SectionTeam>> GetSectionTeamsBySectionIDAsync(int sectionId);
	}
}