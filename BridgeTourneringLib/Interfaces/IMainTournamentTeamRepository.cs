using BridgeTourneringLib.Models;

namespace BridgeTourneringLib.Interfaces
{
	public interface IMainTournamentTeamRepository
	{
		Task<IEnumerable<MainTournamentTeam>> GetMainTournamentTeamsByMainTournamentTeamIdAsync(int mainTournamentTeamId);
	}
}