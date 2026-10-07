using BridgeTourneringLib.Models;

namespace BridgeTourneringLib.Interfaces
{
	public interface IRoundTeamRepository
	{
		Task<IEnumerable<RoundTeam>> GetRoundTeamsByRoundIdTupleAsync(int roundId1, int roundId2);
	}
}