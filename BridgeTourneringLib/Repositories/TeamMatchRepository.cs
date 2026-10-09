using BridgeTourneringLib.Interfaces;
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
	public class TeamMatchRepository : ITeamMatchRepository
	{
		private string connectionString = Secret.ConnectionString;
		private readonly string selectByRoundId;

		public TeamMatchRepository(string clubNo)
		{
			selectByRoundId = "SELECT\r\n\tR.ROUNDNO,\r\n\tRM.TABLENO,\r\n\tNT.TEAMNO AS TEAM1NO,\r\n\tNT.TEAMNAME AS TEAM1NAME,\r\n\tET.TEAMNO AS TEAM2NO,\r\n\tET.TEAMNAME AS TEAM2NAME,\r\n\tRM.CALCULATEDTEAMSCORENS AS TEAM1IMP,\r\n\tRM.CALCULATEDTEAMSCOREEW AS TEAM2IMP,\r\n\tRM.CALCULATEDTEAMVPNS AS TEAM1VP,\r\n\tRM.CALCULATEDTEAMVPEW AS TEAM2VP\r\n\tFROM club" + clubNo + ".ROUNDMATCH RM\r\n\tJOIN club" + clubNo + ".ROUND R\r\n\t\tON R.ID = RM.FKROUNDID\r\n\tJOIN club" + clubNo + ".SECTIONTEAM NST \r\n\t\tON NST.ID = RM.FKNORTHSECTIONTEAMID\r\n\tJOIN club" + clubNo + ".MAINTOURNAMENTTEAM NT\r\n\t\tON NT.ID = NST.FKMAINTOURNAMENTTEAMID\r\n\tJOIN club" + clubNo + ".SECTIONTEAM EST\r\n\t\tON EST.ID = EST.FKMAINTOURNAMENTTEAMID\r\n\tJOIN club" + clubNo + ".MAINTOURNAMENTTEAM ET\r\n\t\tON ET.ID = EST.FKMAINTOURNAMENTTEAMID\r\nWHERE RM.FKROUNDID = @ROUNDID AND RM.TABLENO BETWEEN 1 AND 9\r\nORDER BY RM.TABLENO;";
		}

		public async Task<IEnumerable<TeamMatch>> GetTeamMatchByRoundID(int roundId)
		{
			List<TeamMatch> teamMatches = new List<TeamMatch>();
			using (SqlConnection connect = new SqlConnection(connectionString))
			{
				try
				{
					await connect.OpenAsync();
					using (SqlCommand command = new SqlCommand(selectByRoundId, connect))
					{
						command.Parameters.AddWithValue("@ROUNDID", roundId);
						using (SqlDataReader reader = await command.ExecuteReaderAsync())
						{
							while (await reader.ReadAsync())
							{
								int? roundNo = reader.IsDBNull("ROUNDNO") ? null : reader.GetInt32("ROUNDNO");
								int? tableNo = reader.IsDBNull("TABLENO") ? null : reader.GetInt32("TABLENO");
								int? team1No = reader.IsDBNull("TEAM1NO") ? null : reader.GetInt32("TEAM1NO");
								string? team1Name = reader.IsDBNull("TEAM1NAME") ? null : reader.GetString("TEAM1NAME");
								int? team2No = reader.IsDBNull("TEAM2NO") ? null : reader.GetInt32("TEAM2NO");
								string? team2Name = reader.IsDBNull("TEAM2NAME") ? null : reader.GetString("TEAM2NAME");
								double? team1Imp = reader.IsDBNull("TEAM1IMP") ? null : reader.GetDouble("TEAM1IMP");
								double? team2Imp = reader.IsDBNull("TEAM2IMP") ? null : reader.GetDouble("TEAM2IMP");
								double? team1Vp = reader.IsDBNull("TEAM1VP") ? null : reader.GetDouble("TEAM1VP");
								double? team2Vp = reader.IsDBNull("TEAM2VP") ? null : reader.GetDouble("TEAM2VP");
								TeamMatch teamMatch = new TeamMatch(roundNo, tableNo, team1No, team1Name, team2No, team2Name, team1Imp, team2Imp, team1Vp, team2Vp);
								teamMatches.Add(teamMatch);
							}
							reader.Close();
						}
					}
				}
				catch (SqlException sqlEx)
				{
					Console.WriteLine("SQL DB Error: ", sqlEx.Message);
				}
			}
			return teamMatches;
		}
	}
}
