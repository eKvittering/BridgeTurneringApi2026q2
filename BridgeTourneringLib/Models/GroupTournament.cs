using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeTourneringLib.Models
{
	public class GroupTournament
	{
		public int ID { get; set; }
		public int MainTournamentID { get; set; }
		public int? GroupNo { get; set; }
		public string? Description { get; set; }
		public int? TournamentType { get; set; }
		public int? NumberOfTeams { get; set; }
		public int? NumberOfSections { get; set; }
		public int? NumberOfRounds { get; set; }
		public int? NumberOfTables { get; set; }
		public int? BoardsPerRound { get; set; }
		public int? HalvesPerMatch { get; set; }
		public int? IsMitchell { get; set; }
		public int? IsMonrad { get; set; }
		public int? RegisterMP { get; set; }
		public int? UseBoardsSpec { get; set; }
		public int? MovePlanID { get; set; }
		public int? CalculateHAC { get; set; }
		public int? WaveGroup { get; set; }
		public int? VPScaleType { get; set; }
		public int? TournamentTeamType { get; set; }
		public int? TournamentPairCalcType { get; set; }
		public int? TournamentMatchPointType { get; set; }
		public int? GiveHacPrizes { get; set; }
		public int? AutoTransferScores { get; set; }
		public int? MonradStartRound { get; set; }
		public int? MonradRanking { get; set; }
		public int? SpecialTournamentID { get; set; }
		public int? InputScore { get; set; }
		public int? InputScoreBYTEN { get; set; }
		public int? SaveScore { get; set; }
		public int? Traveller { get; set; }
		public int? TravellerByGame { get; set; }
		public int? PlacementPercent { get; set; }
		public int? GroupTournamentNo { get; set; }
		public int? MPStrengthGroup { get; set; }
		public string? StartNotes { get; set; }
		public string? ResultNotes { get; set; }
		public int? CalculateMulti { get; set; }
		public int? SimplifiedHac { get; set; }
		public int? KnockOutType { get; set; }
		public string? LastChangedBy { get; set; }
		public DateTime? LastChangedDate { get; set; }

		public GroupTournament()
		{
			
		}
		public GroupTournament(int id, int mainTournamentID, int? groupNo, string? description, int? tournamentType, int? numberOfTeams, int? numberOfSections, int? numberOfRounds, int? numberOfTables, int? boardsPerRound, int? halvesPerMatch, int? isMitchell, int? isMonrad, int? registerMP, int? useBoardsSpec, int? movePlanID, int? calculateHAC, int? waveGroup, int? vPScaleType, int? tournamentTeamType, int? tournamentPairCalcType, int? tournamentMatchPointType, int? giveHacPrizes, int? autoTransferScores, int? monradStartRound, int? monradRanking, int? specialTournamentID, int? inputScore, int? inputScoreBYTEN, int? saveScore, int? traveller, int? travellerByGame, int? placementPercent, int? groupTournamentNo, int? mPStrengthGroup, string? startNotes, string? resultNotes, int? calculateMulti, int? simplifiedHac, int? knockOutType, string? lastChangedBy, DateTime? lastChangedDate)
		{
			ID = id;
			MainTournamentID = mainTournamentID;
			GroupNo = groupNo;
			Description = description;
			TournamentType = tournamentType;
			NumberOfTeams = numberOfTeams;
			NumberOfSections = numberOfSections;
			NumberOfRounds = numberOfRounds;
			NumberOfTables = numberOfTables;
			BoardsPerRound = boardsPerRound;
			HalvesPerMatch = halvesPerMatch;
			IsMitchell = isMitchell;
			IsMonrad = isMonrad;
			RegisterMP = registerMP;
			UseBoardsSpec = useBoardsSpec;
			MovePlanID = movePlanID;
			CalculateHAC = calculateHAC;
			WaveGroup = waveGroup;
			VPScaleType = vPScaleType;
			TournamentTeamType = tournamentTeamType;
			TournamentPairCalcType = tournamentPairCalcType;
			TournamentMatchPointType = tournamentMatchPointType;
			GiveHacPrizes = giveHacPrizes;
			AutoTransferScores = autoTransferScores;
			MonradStartRound = monradStartRound;
			MonradRanking = monradRanking;
			SpecialTournamentID = specialTournamentID;
			InputScore = inputScore;
			InputScoreBYTEN = inputScoreBYTEN;
			SaveScore = saveScore;
			Traveller = traveller;
			TravellerByGame = travellerByGame;
			PlacementPercent = placementPercent;
			GroupTournamentNo = groupTournamentNo;
			MPStrengthGroup = mPStrengthGroup;
			StartNotes = startNotes;
			ResultNotes = resultNotes;
			CalculateMulti = calculateMulti;
			SimplifiedHac = simplifiedHac;
			KnockOutType = knockOutType;
			LastChangedBy = lastChangedBy;
			LastChangedDate = lastChangedDate;
		}
	}
}
