using BridgeTourneringLib.Models;

namespace BridgeTourneringLib.Interfaces
{
	public interface IMainTournamentRepository
	{
		Task<IEnumerable<MainTournament>> GetMainTournamentAsync();
	}
}