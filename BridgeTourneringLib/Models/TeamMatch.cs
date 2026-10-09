using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeTourneringLib.Models
{
	public class TeamMatch
	{
		public int? RoundNo { get; set; }
		public int? TableNo { get; set; }
		public int? Team1No { get; set; }
		public string? Team1Name { get; set; }
		public int? Team2No { get; set; }
		public string? Team2Name { get; set; }
		public double? Team1Imp { get; set; }
		public double? Team2Imp { get; set; }
		public double? Team1Vp { get; set; }
		public double? Team2Vp { get; set; }

		public TeamMatch()
		{
			
		}
		public TeamMatch(int? roundNo, int? tableNo, int? team1No, string? team1Name, int? team2No, string? team2Name, double? team1Imp, double? team2Imp, double? team1Vp, double? team2Vp)
		{
			RoundNo = roundNo;
			TableNo = tableNo;
			Team1No = team1No;
			Team1Name = team1Name;
			Team2No = team2No;
			Team2Name = team2Name;
			Team1Imp = team1Imp;
			Team2Imp = team2Imp;
			Team1Vp = team1Vp;
			Team2Vp = team2Vp;
		}
	}
}
