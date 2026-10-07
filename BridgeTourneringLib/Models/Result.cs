using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeTourneringLib.Models
{
	public class Result
	{
		public int ID { get; set; }
		public int? MatchID { get; set; }
		public int? BoardID { get; set; }
		public int? BoardNo { get; set; }
		public int? BoardGroup { get; set; }
		public string? BiddingSequence { get; set; }
		public string? Contract { get; set; }
		public string? Lead { get; set; }
		public int? MatchResult { get; set; }
		public double? CalculatedScoreNS { get; set; }
		public double? CalculatedScoreNSPCT { get; set; }
		public double? CalculatedScoreEW { get; set; }
		public double? CalculatedScoreEWPCT { get; set; }
		public string? Declarer { get; set; }
		public string? Doubling { get; set; }
		public int? Tricks { get; set; }
		public int? ResultCompleted { get; set; }
		public int? ExcludeGame { get; set; }
		public int? BoardCompared { get; set; }

		public Result()
		{
			
		}
		public Result(int id, int? matchId, int? boardId, int? boardNo, int? boardGroup, string? biddingSequence, string? contract, string? lead, int? matchResult, double? calculatedScoreNS, double? calculatedScoreNSPCT, double? calculatedScoreEW, double? calculatedScoreEWPCT, string? declarer, string? doubling, int? tricks, int? resultCompleted, int? excludeGame, int? boardCompared)
		{
			ID = id;
			MatchID = matchId;
			BoardID = boardId;
			BoardNo = boardNo;
			BoardGroup = boardGroup;
			BiddingSequence = biddingSequence;
			Contract = contract;
			Lead = lead;
			MatchResult = matchResult;
			CalculatedScoreNS = calculatedScoreNS;
			CalculatedScoreNSPCT = calculatedScoreNSPCT;
			CalculatedScoreEW = calculatedScoreEW;
			CalculatedScoreEWPCT = calculatedScoreEWPCT;
			Declarer = declarer;
			Doubling = doubling;
			Tricks = tricks;
			ResultCompleted = resultCompleted;
			ExcludeGame = excludeGame;
			BoardCompared = boardCompared;
		}
	}
}
