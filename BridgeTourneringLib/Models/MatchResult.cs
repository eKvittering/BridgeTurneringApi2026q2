using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeTourneringLib.Models
{
	public class MatchResult
	{
		public int? TeamNo { get; set; }
		public string? TeamName { get; set; }
		public double? TotalVP { get; set; }

		public MatchResult()
		{
			 
		}
		public MatchResult(int? teamNo, string? teamName, double? totalVp)
		{
			TeamNo = teamNo;
			TeamName = teamName;
			TotalVP = totalVp;
		}
	}
}
