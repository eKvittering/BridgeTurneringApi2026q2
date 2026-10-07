using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeTourneringLib.Models
{
	public class RoundMatch
	{
		public int ID { get; set; }
		public int? RoundID { get; set; }
		public int? TableNo { get; set; }
		public int? NorthTeamNo { get; set; }
		public int? NorthSectionTeamID { get; set; }
		public int? EastTeamNo { get; set; }
		public int? EastSectionTeamID { get; set; }
		public int? SouthTeamNo { get; set; }
		public int? SouthSectionTeamID { get; set; }
		public int? WestTeamNo { get; set; }
		public int? WestSectionTeamID { get; set; }

		public RoundMatch()
		{
			
		}
		public RoundMatch(int id, int? roundId, int? tableNo, int? northTeamNo, int? northSectionTeamId, int? eastTeamNo, int? eastSectionTeamId, int? southTeamNo, int? southSectionTeamId, int? westTeamNo, int? westSectionTeamId)
		{
			ID = id;
			RoundID = roundId;
			TableNo = tableNo;
			NorthTeamNo = northTeamNo;
			NorthSectionTeamID = northSectionTeamId;
			EastTeamNo = eastTeamNo;
			EastSectionTeamID = eastSectionTeamId;
			SouthTeamNo = southTeamNo;
			SouthSectionTeamID = southSectionTeamId;
			WestTeamNo = westTeamNo;
			WestSectionTeamID = westSectionTeamId;
		}
	}
}
