using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeTourneringLib.Models
{
	public class RoundTeam
	{
		public int? RoundNo { get; set; }
		public int? TableNo { get; set; }
		public int? NorthTeamNo { get; set; }
		public string? NSTeam { get; set; }
		public int? EastTeamNo { get; set; }
		public string? EWTeam { get; set; }

		public RoundTeam()
		{
			
		}
		public RoundTeam(int? roundNo, int? tableNo, int? northTeamNo, string? nsTeam, int? eastTeamNo, string? ewTeam)
		{
			RoundNo = roundNo;
			TableNo = tableNo;
			NorthTeamNo = northTeamNo;
			NSTeam = nsTeam;
			EastTeamNo = eastTeamNo;
			EWTeam = ewTeam;
		}
	}
}
