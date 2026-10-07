using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeTourneringLib.Models
{
	public class Round
	{
		public int ID { get; set; }
		public int? SectionID { get; set; }
		public int? RoundNo { get; set; }
		public int? HalfNo { get; set; }
		public DateTime? StartTime { get; set; }
		public DateTime? EndTime { get; set; }
		public int? StartBoard { get; set; }

		public Round()
		{
			
		}
		public Round(int id, int? sectionId, int? roundNo, int? halfNo, DateTime? startTime, DateTime? endTime, int? startBoard)
		{
			ID = id;
			SectionID = sectionId;
			RoundNo = roundNo;
			HalfNo = halfNo;
			StartTime = startTime;
			EndTime = endTime;
			StartBoard = startBoard;
		}
	}
}
