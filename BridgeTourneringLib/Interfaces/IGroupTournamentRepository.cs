using BridgeTourneringLib.Models;

namespace BridgeTourneringLib.Interfaces
{
	public interface IGroupTournamentRepository
	{
		Task<IEnumerable<GroupTournament>> GetGroupTournamentByMaintournamentIDAsync(int mainTournamentId);
	}
}