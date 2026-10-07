using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeTourneringLib.Models
{
	public class MainTournamentTeam
	{
		public int ID { get; set; }
		public int? MainTournamentID { get; set; }
		public int? TeamNo { get; set; }
		public string? TeamName { get; set; }
		public int? TournamentType { get; set; }

		public MainTournamentTeam()
		{
			
		}
		public MainTournamentTeam(int id, int? mainTournamentId, int? teamNo, string? teamName, int? tournamentType)
		{
			ID = id;
			MainTournamentID = mainTournamentId;
			TeamNo = teamNo;
			TeamName = teamName;
			TournamentType = tournamentType;
		}
	}
}
