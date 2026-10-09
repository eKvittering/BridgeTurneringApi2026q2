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
	public class MatchResultRepository : IMatchResultRepository
	{
		private string connectionString = Secret.ConnectionString;
		private readonly string selectByGroupTournamentIdAndRoundNo;

		public MatchResultRepository(string clubNo)
		{
			selectByGroupTournamentIdAndRoundNo = "WITH MATCHES AS (\r\n\tSELECT\r\n\t\tR.ROUNDNO,\r\n\t\tNT.TEAMNO AS TEAM1NO,\r\n\t\tNT.TEAMNAME AS TEAM1NAME,\r\n\t\tRM.CALCULATEDTEAMVPNS AS TEAM1VP,\r\n\t\tET.TEAMNO AS TEAM2NO,\r\n\t\tET.TEAMNAME AS TEAM2NAME,\r\n\t\tRM.CALCULATEDTEAMVPEW AS TEAM2VP\r\n\tFROM club" + clubNo + ".ROUNDMATCH RM\r\n\tJOIN club" + clubNo + ".ROUND R\r\n\t\tON R.ID = RM.FKROUNDID\r\n\tJOIN club" + clubNo + ".SECTION S\r\n\t\tON S.ID = R.FKSECTIONID\r\n\tJOIN club" + clubNo + ".SECTIONTEAM NST\r\n\t\tON NST.ID = RM.FKEASTSECTIONTEAMID\r\n\tJOIN club" + clubNo + ".MAINTOURNAMENTTEAM NT\r\n\t\tON NT.ID = NST.FKMAINTOURNAMENTTEAMID\r\n\tJOIN club" + clubNo + ".SECTIONTEAM EST\r\n\t\tON EST.ID = RM.FKEASTSECTIONTEAMID\r\n\tJOIN club" + clubNo + ".MAINTOURNAMENTTEAM ET\r\n\t\tON ET.ID = EST.FKMAINTOURNAMENTTEAMID\r\n\tWHERE S.FKGROUPTOURNAMENTID = @GROUPTOURNAMENTID\r\n\tAND R.ROUNDNO <= @ROUNDNO\r\n\tAND RM.TABLENO BETWEEN 1 AND 9\r\n),\r\nALLRESULTS AS (\r\n\tSELECT\r\n\t\tTEAM1NO AS TEAMNO,\r\n\t\tTEAM1NAME AS TEAMNAME,\r\n\t\tTEAM1VP AS VP\r\n\tFROM MATCHES\r\n\t\r\n\tUNION ALL\r\n\tSELECT\r\n\t\tTEAM2NO,\r\n\t\tTEAM2NAME,\r\n\t\tTEAM2VP\r\n\tFROM MATCHES\r\n)\r\nSELECT\r\n\tTEAMNO,\r\n\tTEAMNAME,\r\n\tSUM(VP) AS TOTALVP\r\nFROM ALLRESULTS GROUP BY\r\n\tTEAMNO,\r\n\tTEAMNAME\r\nORDER BY\r\n\tTOTALVP DESC;";
		}

		public async Task<IEnumerable<MatchResult>> GetMatchResultByGroupTournamentIDAndRoundNo(int groupTournamentId, int roundNo)
		{
			List<MatchResult> matchResults = new List<MatchResult>();
			using (SqlConnection connect = new SqlConnection(connectionString))
			{
				try
				{
					await connect.OpenAsync();
					using (SqlCommand command = new SqlCommand(selectByGroupTournamentIdAndRoundNo, connect))
					{
						command.Parameters.AddWithValue("@GROUPTOURNAMENTID", groupTournamentId);
						command.Parameters.AddWithValue("@ROUNDNO", roundNo);
						using (SqlDataReader reader = await command.ExecuteReaderAsync())
						{
							while (await reader.ReadAsync())
							{
								int? teamNo = reader.IsDBNull("TEAMNO") ? null : reader.GetInt32("TEAMNO");
								string? teamName = reader.IsDBNull("TEAMNAME") ? null : reader.GetString("TEAMNAME");
								double? totalVp = reader.IsDBNull("TOTALVP") ? null : reader.GetDouble("TOTALVP");
								MatchResult matchResult = new MatchResult(teamNo, teamName, totalVp);
								matchResults.Add(matchResult);
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
			return matchResults;
		}
	}
}
