using BridgeTourneringLib.Interfaces;
using BridgeTourneringLib.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Pipelines;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BridgeTourneringLib.Repositories
{
	public class SectionTeamRepository : ISectionTeamRepository
	{
		private string connectionString = Secret.ConnectionString;
		private readonly string selectBySectionID;

		public SectionTeamRepository(string clubNo)
		{
			selectBySectionID = "SELECT ID, FKMAINTOURNAMENTTEAMID, TEAMNO, STARTSCORE, ADJUSTMENTMISSING, ADJUSTMENTOTHER, REGULATIONSCORE, TIEBREAKTOURNAMENT, TRANSFERSCORE, TRANSFERBOARDS, TRANSFERPERCENT, TIEBREAKADD FROM club" + clubNo + ".SECTIONTEAM WHERE FKSECTIONID = @SECTIONID ORDER BY TEAMNO";
		}

		public async Task<IEnumerable<SectionTeam>> GetSectionTeamsBySectionIDAsync(int sectionId)
		{
			List<SectionTeam> sectionTeams = new List<SectionTeam>();
			using (SqlConnection connect = new SqlConnection(connectionString))
			{
				try
				{
					await connect.OpenAsync();
					using (SqlCommand command = new SqlCommand(selectBySectionID, connect))
					{
						command.Parameters.AddWithValue("@SECTIONID", sectionId);
						using (SqlDataReader reader = await command.ExecuteReaderAsync())
						{
							while (await reader.ReadAsync())
							{
								int teamId = reader.GetInt32("ID");
								int? mainTournamentTeamId = reader.IsDBNull("FKMAINTOURNAMENTTEAMID") ? null : reader.GetInt32("FKMAINTOURNAMENTTEAMID");
								int? teamNo = reader.IsDBNull("TEAMNO") ? null : reader.GetInt32("TEAMNO");
								double? startScore = reader.IsDBNull("STARTSCORE") ? null : reader.GetDouble("STARTSCORE");
								int? adjustmentMissing = reader.IsDBNull("ADJUSTMENTMISSING") ? null : reader.GetInt32("ADJUSTMENTMISSING");
								int? adjustmentOther = reader.IsDBNull("ADJUSTMENTOTHER") ? null : reader.GetInt32("ADJUSTMENTOTHER");
								double? regulationScore = reader.IsDBNull("REGULATIONSCORE") ? null : reader.GetDouble("REGULATIONSCORE");
								int? tieBreakTournament = reader.IsDBNull("TIEBREAKTOURNAMENT") ? null : reader.GetInt32("TIEBREAKTOURNAMENT");
								double? transferScore = reader.IsDBNull("TRANSFERSCORE") ? null : reader.GetDouble("TRANSFERSCORE");
								int? transferBoards = reader.IsDBNull("TRANSFERBOARDS") ? null : reader.GetInt32("TRANSFERBOARDS");
								double? transferPercent = reader.IsDBNull("TRANSFERPERCENT") ? null : reader.GetDouble("TRANSFERPERCENT");
								int? tieBreakAdd = reader.IsDBNull("TIEBREAKADD") ? null : reader.GetInt32("TIEBREAKADD");
								SectionTeam sectionTeam = new SectionTeam(teamId, sectionId, mainTournamentTeamId, teamNo, startScore, adjustmentMissing, adjustmentOther, regulationScore, tieBreakTournament, transferScore, transferBoards, transferPercent, tieBreakAdd);
								sectionTeams.Add(sectionTeam);
							}
						}
					}
				}
				catch (SqlException sqlEx)
				{
					Console.WriteLine("SQL DB Error: ", sqlEx.Message);
				}
			}
			return sectionTeams;
		}
	}
}
