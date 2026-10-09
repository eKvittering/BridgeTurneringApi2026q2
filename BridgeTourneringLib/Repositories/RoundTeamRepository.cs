using BridgeTourneringLib.Interfaces;
using BridgeTourneringLib.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BridgeTourneringLib.Repositories
{
	public class RoundTeamRepository : IRoundTeamRepository
	{
		private string connectionString = Secret.ConnectionString;
		private readonly string selectByRoundIdTuple;

		public RoundTeamRepository(string clubNo)
		{
			selectByRoundIdTuple = "SELECT\r\n R.ROUNDNO,\r\n RM.TABLENO,\r\n RM.NORTHTEAMNO,\r\n NT.TEAMNAME AS NSTEAM,\r\n RM.EASTTEAMNO,\r\n ET.TEAMNAME AS EWTEAM\r\nFROM club2275.ROUNDMATCH RM\r\nJOIN club2275.ROUND R\r\n ON R.ID = RM.FKROUNDID\r\nLEFT JOIN club2275.SECTIONTEAM NST\r\n ON NST.ID = RM.FKNORTHSECTIONTEAMID\r\nLEFT JOIN club2275.MAINTOURNAMENTTEAM NT\r\n ON NT.ID = NST.FKMAINTOURNAMENTTEAMID\r\nLEFT JOIN club2275.SECTIONTEAM EST\r\n ON EST.ID = RM.FKEASTSECTIONTEAMID\r\nLEFT JOIN club2275.MAINTOURNAMENTTEAM ET\r\n ON ET.ID = EST.FKMAINTOURNAMENTTEAMID\r\nWHERE RM.FKROUNDID IN (2048, 2049)\r\nORDER BY R.ROUNDNO, RM.TABLENO;";
		}

		public async Task<IEnumerable<RoundTeam>> GetRoundTeamsByRoundIdTupleAsync(int roundId1, int roundId2)
		{
			List<RoundTeam> roundTeams = new List<RoundTeam>();
			using (SqlConnection connect = new SqlConnection(connectionString))
			{
				try
				{
					await connect.OpenAsync();
					using (SqlCommand command = new SqlCommand(selectByRoundIdTuple, connect))
					{
						command.Parameters.AddWithValue("@ROUNDID1", roundId1);
						command.Parameters.AddWithValue("@ROUNDID2", roundId2);
						using (SqlDataReader reader = await command.ExecuteReaderAsync())
						{
							while (await reader.ReadAsync())
							{
								int? roundNo = reader.IsDBNull("ROUNDNO") ? null : reader.GetInt32("ROUNDNO");
								int? tableNo = reader.IsDBNull("TABLENO") ? null : reader.GetInt32("TABLENO");
								int? northTeamNo = reader.IsDBNull("NORTHTEAMNO") ? null : reader.GetInt32("NORTHTEAMNO");
								string? nsTeam = reader.IsDBNull("NSTEAM") ? null : reader.GetString("NSTEAM");
								int? eastTeamId = reader.IsDBNull("EASTTEAMNO") ? null : reader.GetInt32("EASTTEAMNO");
								string? ewTeam = reader.IsDBNull("EWTEAM") ? null : reader.GetString("EWTEAM");
								RoundTeam roundTeam = new RoundTeam(roundNo, tableNo, northTeamNo, nsTeam, eastTeamId, ewTeam);
								roundTeams.Add(roundTeam);
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
			return roundTeams;
		}
	}
}
