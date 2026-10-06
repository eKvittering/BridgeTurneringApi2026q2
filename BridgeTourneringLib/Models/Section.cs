using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeTourneringLib.Models
{
	public class Section
	{
		public int ID { get; set; }
		public int? SectionNo { get; set; }
		public DateTime? StartTime { get; set; }
		public DateTime? EndTime { get; set; }
		public int? StartRoundNo { get; set; }
		public int? EndRoundNo { get; set; }

		public Section()
		{
			
		}

		public Section(int id, int? sectionNo, DateTime? startTime, DateTime? endTime, int? startRoundNo, int? endRoundNo)
		{
			ID = id;
			SectionNo = sectionNo;
			StartTime = startTime;
			EndTime = endTime;
			StartRoundNo = startRoundNo;
			EndRoundNo = endRoundNo;
		}
	}
}
