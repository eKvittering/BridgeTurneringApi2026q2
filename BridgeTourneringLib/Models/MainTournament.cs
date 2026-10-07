using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeTourneringLib.Models
{
	public class MainTournament
	{
		public int ID { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public int? TournamentForm { get; set; }
		public int? CommonTop { get; set; }
		public int? ClubID { get; set; }
		public int? IncludeClubName { get; set; }
		public int? UseLeads { get; set; }
		public int? StrengthGroupCount { get; set; }
		public string? LastChangedBy { get; set; }
		public DateOnly? LastChangedDate { get; set; }
		public int? NumberOfGroups { get; set; }
		public int? NumberOfPlayingDays { get; set; }
		public int? IsVisible { get; set; }
		public int? DoWebPublish { get; set; }
		public int? IsFlexible { get; set; }
		public int? FlexiblePercent { get; set; }

		public MainTournament()
		{
			
		}
		public MainTournament(int id, string? name, string? description, int? tournamentForm, int? commonTop, int? clubID, int? includeClubName, int? useLeads, int? strengthGroupCount, string? lastChangedBy, DateOnly? lastChangedDate, int? numberOfGroups, int? numberOfPlayingDays, int? isVisible, int? doWebPublish, int? isFlexible, int? flexiblePercent)
		{
			ID = id;
			Name = name;
			Description = description;
			TournamentForm = tournamentForm;
			CommonTop = commonTop;
			ClubID = clubID;
			IncludeClubName = includeClubName;
			UseLeads = useLeads;
			StrengthGroupCount = strengthGroupCount;
			LastChangedBy = lastChangedBy;
			LastChangedDate = lastChangedDate;
			NumberOfGroups = numberOfGroups;
			NumberOfPlayingDays = numberOfPlayingDays;
			IsVisible = isVisible;
			DoWebPublish = doWebPublish;
			IsFlexible = isFlexible;
			FlexiblePercent = flexiblePercent;
		}
	}
}
