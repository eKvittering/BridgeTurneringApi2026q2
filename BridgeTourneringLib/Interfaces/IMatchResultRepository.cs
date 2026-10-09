using BridgeTourneringLib.Models;

namespace BridgeTourneringLib.Interfaces
{
	public interface IMatchResultRepository
	{
		Task<IEnumerable<MatchResult>> GetMatchResultByGroupTournamentIDAndRoundNo(int groupTournamentId, int roundNo);
	}
}