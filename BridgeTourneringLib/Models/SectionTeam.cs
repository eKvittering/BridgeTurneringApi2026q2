using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeTourneringLib.Models
{
	public class SectionTeam
	{
		public int ID { get; set; }
		public int MainTournamentID { get; set; }
		public int? SectionID { get; set; }
		public int? TeamNo { get; set; }
		public int? StartScore { get; set; }
		public int? AdjustmentMissing { get; set; }
		public int? AdjustmentOther { get; set; }
		public int? RegulationScore { get; set; }
		public int? TieBreakerTournament { get; set; }
		public int? TransferScore { get; set; }
		public int? TransferBoards { get; set; }
		public int? TieBreakAdd { get; set; }

		public SectionTeam()
		{
			
		}
		public SectionTeam(int id, int mainTournamentId, int? sectionId, int? teamNo, int? startScore, int? adjustmentMissing, int? adjustmentOther, int? regulationScore, int? tieBreakerTournamnent, int? transferScore, int? transferBoards, int? tieBreakAdd)
		{
			ID = id;
			MainTournamentID = mainTournamentId;
			SectionID = sectionId;
			TeamNo = teamNo;
			StartScore = startScore;
			AdjustmentMissing = adjustmentMissing;
			AdjustmentOther = adjustmentOther;
			RegulationScore = regulationScore;
			TieBreakerTournament = tieBreakerTournamnent;
			TransferScore = transferScore;
			TransferBoards = transferBoards;
			TieBreakAdd = tieBreakAdd;
		}
	}
}
