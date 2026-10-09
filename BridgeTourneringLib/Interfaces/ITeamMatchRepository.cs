using BridgeTourneringLib.Models;

namespace BridgeTourneringLib.Interfaces
{
	public interface ITeamMatchRepository
	{
		Task<IEnumerable<TeamMatch>> GetTeamMatchByRoundID(int roundId);
	}
}