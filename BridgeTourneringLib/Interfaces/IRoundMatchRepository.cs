using BridgeTourneringLib.Models;

namespace BridgeTourneringLib.Interfaces
{
	public interface IRoundMatchRepository
	{
		Task<IEnumerable<RoundMatch>> GetRoundMatchByRoundIdTuple(int roundId1, int roundId2);
	}
}