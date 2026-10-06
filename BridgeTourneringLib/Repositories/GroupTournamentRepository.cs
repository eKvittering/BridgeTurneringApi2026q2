using BridgeTourneringLib.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeTourneringLib.Repositories
{
	public class GroupTournamentRepository
	{
		private string connectionString = Secret.ConnectionString;
		private readonly string selectByMTID;

		public GroupTournamentRepository(string clubNo)
		{
			selectByMTID = "SELECT ID, FKMAINTOURNAMENTID, GROUPNO, DESCRIPTION, TOURNAMENTTYPE, NUMBEROFTEAMS, NUMBEROFSECTIONS, NUMBEROFROUNDS, NUMBEROFTABLES, BOARDSPERROUND, HALVESPERMATCH, ISMITCHELL, ISMONRAD, REGISTERMP, USEBOARDSPEC, FKMOVEMENTPLANID, CALCULATEHAC, WAVEGROUP, VPSCALETYPE, TOURNAMENTTEAMTYPE, TOURNAMENTPAIRCALCTYPE, TOURNAMENTMATCHPOINTTYPE, GIVEHACPRIZES, AUTOTRANSFERSCORES, MONRADSTARTROUND, MONRADRANKING, SPECIALTOURNAMENTID, INPUTSCORE, INPUTSCOREBYTEN, SAVESCORE, TRAVELER, TRAVELERBYGAMENO, PLACEMENTPERCENT, GROUPTOURNAMENTNO, MPSTRENGTHGROUP, STARTNOTES, RESULTNOTES, CALCULATEMULTI, SIMPLIFIEDHAC, KNOCKOUTTYPE, LAST_CHANGED_BY, LAST_CHANGED_DATE FROM club" + clubNo + ".GROUPTOURNAMENT WHERE FKMAINTOURNAMENTID = @MAINTOURNAMENTID";
		}

		public async Task<IEnumerable<GroupTournament>> GetGroupTournamentByMaintournamentIDAsync(int mainTournamentId)
		{
			List<GroupTournament> groupTournaments = new List<GroupTournament>();
			using (SqlConnection connect = new SqlConnection(connectionString))
			{
				try
				{
					await connect.OpenAsync();
					using (SqlCommand command = new SqlCommand(selectByMTID, connect))
					{
						command.Parameters.AddWithValue("@MAINTOURNAMENTID", mainTournamentId);
						using (SqlDataReader reader = await command.ExecuteReaderAsync())
						{
							while (await reader.ReadAsync())
							{
								int groupTournamentId = reader.GetInt32("ID");
								int? groupNo = reader.IsDBNull("GROUPNO") ? null : reader.GetInt32("GROUPNO");
								string? description = reader.IsDBNull("DESCRIPTION") ? null : reader.GetString("DESCRIPTION");
								int? tournamentType = reader.IsDBNull("TOURNAMENTTYPE") ? null : reader.GetInt32("TOURNAMENTTYPE");
								int? numberOfTeams = reader.IsDBNull("NUMBEROFTEAMS") ? null : reader.GetInt32("NUMBEROFTEAMS");
								int? numberOfSections = reader.IsDBNull("NUMBEROFSECTIONS") ? null : reader.GetInt32("NUMBEROFSECTIONS");
								int? numberOfRounds = reader.IsDBNull("NUMBEROFROUNDS") ? null : reader.GetInt32("NUMBEROFROUNDS");
								int? numberOfTables = reader.IsDBNull("NUMBEROFTABLES") ? null : reader.GetInt32("NUMBEROFTABLES");
								int? boardsPerRound = reader.IsDBNull("BOARDSPERROUND") ? null : reader.GetInt32("BOARDSPERROUND");
								int? halvesPerMatch = reader.IsDBNull("HALVESPERMATCH") ? null : reader.GetInt32("HALVESPERMATCH");
								int? isMitchell = reader.IsDBNull("ISMITCHELL") ? null : reader.GetInt16("ISMITCHELL");
								int? isMonrad = reader.IsDBNull("ISMONRAD") ? null : reader.GetInt16("ISMONRAD");
								int? registerMP = reader.IsDBNull("REGISTERMP") ? null : reader.GetInt16("REGISTERMP");
								int? useBoardSpec = reader.IsDBNull("USEBOARDSPEC") ? null : reader.GetInt16("USEBOARDSPEC");
								int? movementPlanID = reader.IsDBNull("MOVEMENTPLANID") ? null : reader.GetInt32("MOVEMENTPLANID");
								int? calculateHac = reader.IsDBNull("CALCULATEHAC") ? null : reader.GetInt16("CALCULATEHAC");
								int? waveGroup = reader.IsDBNull("WAVEGROUP") ? null : reader.GetInt32("WAVEGROUP");
								int? vpScaleType = reader.IsDBNull("VPSCALETYPE") ? null : reader.GetInt32("VPSCALETYPE");
								int? tournamentTeamType = reader.IsDBNull("TOURNAMENTTEAMTYPE") ? null : reader.GetInt32("TOURNAMENTTEAMTYPE");
								int? tournamentMatchPointType = reader.IsDBNull("TOURNAMENTMATCHPOINTTYPE") ? null : reader.GetInt32("TOURNAMENTMATCHPOINTTYPE");
								int? tournamentPairCalcType = reader.IsDBNull("TOURNAMENTPAIRCALCTYPE") ? null : reader.GetInt32("TOURNAMENTPAIRCALCTYPE"); 
								int? giveHacPrizes = reader.IsDBNull("GIVEHACPRIZES") ? null : reader.GetInt16("GIVEHACPRIZES");
								int? autoTransferScore = reader.IsDBNull("AUTOTRANSFERSCORES") ? null : reader.GetInt16("AUTOTRANSFERSCORES");
								int? monradStartRound = reader.IsDBNull("MONRADSTARTROUND") ? null : reader.GetInt32("MONRADSTARTROUND");
								int? monradRanking = reader.IsDBNull("MONRADRANKING") ? null : reader.GetInt32("MONRADRANKING");
								int? specialTournamentID = reader.IsDBNull("SPECIALTOURNAMENTID") ? null : reader.GetInt32("SPECIALTOURNAMENTID");
								int? inputScore = reader.IsDBNull("INPUTSCORE") ? null : reader.GetInt16("INPUTSCORE");
								int? inputScoreByten = reader.IsDBNull("INPUTSCOREBYTEN") ? null : reader.GetInt16("INPUTSCOREBYTEN");
								int? saveScore = reader.IsDBNull("SAVESCORE") ? null : reader.GetInt16("SAVESCORE");
								int? traveler = reader.IsDBNull("TRAVELER") ? null : reader.GetInt16("TRAVELER");
								int? travelerByGameNo = reader.IsDBNull("TRAVELERBYGAMENO") ? null : reader.GetInt16("TRAVELERBYGAMENO");
								int? placementPercent = reader.IsDBNull("PLACEMENTPERCENT") ? null : reader.GetInt32("PLACEMENTPERCENT");
								int? groupTournamentNo = reader.IsDBNull("GROUPTOURNAMENTNO") ? null : reader.GetInt32("GROUPTOURNAMENTNO");
								int? mpStrengthGroup = reader.IsDBNull("MPSTRENGTHGROUP") ? null : reader.GetInt32("MPSTRENGTHGROUP");
								string? startNotes = reader.IsDBNull("STARTNOTES") ? null : reader.GetString("STARTNOTES");
								string? resultNotes = reader.IsDBNull("RESULTNOTES") ? null : reader.GetString("RESULTNOTES");
								int? calculateMulti = reader.IsDBNull("CALCULATEMULTI") ? null : reader.GetInt16("CALCULATEMULTI");
								int? simplifiedHac = reader.IsDBNull("SIMPLIFIEDHAC") ? null : reader.GetInt16("SIMPLIFIEDHAC");
								int? knockoutType = reader.IsDBNull("KNOCKOUTTYPE") ? null : reader.GetInt32("KNOCKOUTTYPE");
								string? lastChangedBy = reader.IsDBNull("LAST_CHANGED_BY") ? null : reader.GetString("LAST_CHANGED_BY");
								DateTime? lastChangedDate = reader.IsDBNull("LAST_CHANGED_DATE") ? null : reader.GetDateTime("LAST_CHANGED_DATE");
								GroupTournament groupTournament = new GroupTournament(groupTournamentId, mainTournamentId, groupNo, description, tournamentType, numberOfTeams, numberOfSections, numberOfRounds, numberOfTables, boardsPerRound, halvesPerMatch, isMitchell, isMonrad, registerMP, useBoardSpec, movementPlanID, calculateHac, waveGroup, vpScaleType, tournamentTeamType, tournamentPairCalcType, tournamentMatchPointType, giveHacPrizes, autoTransferScore, monradStartRound, monradRanking, specialTournamentID, inputScore, inputScoreByten, saveScore, traveler, travelerByGameNo, placementPercent, groupTournamentNo, mpStrengthGroup, startNotes, resultNotes, calculateMulti, simplifiedHac, knockoutType, lastChangedBy, lastChangedDate);
							}
						}
					}
				}
				catch (SqlException sqlEx)
				{
					Console.WriteLine("SQL DB Error: ", sqlEx.Message);
				}
			}
			return groupTournaments;
		}
	}
}
