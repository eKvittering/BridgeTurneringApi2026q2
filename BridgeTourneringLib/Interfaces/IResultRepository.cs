using BridgeTourneringLib.Models;

namespace BridgeTourneringLib.Interfaces
{
	public interface IResultRepository
	{
		Task<IEnumerable<Result>> GetResultByMatchIDAsync(int matchId);
	}
}