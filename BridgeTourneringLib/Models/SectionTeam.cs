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
		public int MainTournamentTeamID { get; set; }
		public int? SectionID { get; set; }
		public int? TeamNo { get; set; }
		public double? StartScore { get; set; }
		public int? AdjustmentMissing { get; set; }
		public int? AdjustmentOther { get; set; }
		public double? RegulationScore { get; set; }
		public int? TieBreakerTournament { get; set; }
		public double? TransferScore { get; set; }
		public int? TransferBoards { get; set; }
		public double? TransferPercent { get; set; }
		public int? TieBreakAdd { get; set; }

		public SectionTeam()
		{
			
		}
		public SectionTeam(int id, int mainTournamentId, int? sectionId, int? teamNo, double? startScore, int? adjustmentMissing, int? adjustmentOther, double? regulationScore, int? tieBreakerTournamnent, double? transferScore, int? transferBoards, double? transferPercent, int? tieBreakAdd)
		{
			ID = id;
			MainTournamentTeamID = mainTournamentId;
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
