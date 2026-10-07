using BridgeTourneringLib.Models;

namespace BridgeTourneringLib.Interfaces
{
	public interface ISectionRepository
	{
		Task<IEnumerable<Section>> GetSectionsByGroupTournamentIDAsync(int groupTournamentId);
	}
}