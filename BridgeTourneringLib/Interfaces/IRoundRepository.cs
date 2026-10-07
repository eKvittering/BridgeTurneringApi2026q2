using BridgeTourneringLib.Models;

namespace BridgeTourneringLib.Interfaces
{
	public interface IRoundRepository
	{
		Task<IEnumerable<Round>> GetRoundsBySectionId(int sectionId);
	}
}