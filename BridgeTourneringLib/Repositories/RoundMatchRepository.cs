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
	public class RoundMatchRepository : IRoundMatchRepository
	{
		private string connectionString = Secret.ConnectionString;
		private readonly string selectByRoundIdTuple;

		public RoundMatchRepository(string clubNo)
		{
			selectByRoundIdTuple = "SELECT ID, FKROUNDID, TABLENO, NORTHTEAMNO, FKNORTHSECTIONTEAMID, EASTTEAMNO, FKEASTSECTIONTEAMID, SOUTHTEAMNO, FKSOUTHSECTIONTEAMID, WESTTEAMNO, FKWESTSECTIONTEAMID FROM club" + clubNo + ".ROUNDMATCH WHERE FKROUNDID IN (@ROUNDID1, @ROUNDID2) ORDER BY FKROUNDID, TABLENO";
		}

		public async Task<IEnumerable<RoundMatch>> GetRoundMatchByRoundIdTuple(int roundId1, int roundId2)
		{
			List<RoundMatch> roundMatches = new List<RoundMatch>();
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
								int id = reader.GetInt32("ID");
								int? roundId = reader.IsDBNull("FKROUNDID") ? null : reader.GetInt32("FKROUNDID");
								int? tableNo = reader.IsDBNull("TABLENO") ? null : reader.GetInt32("TABLENO");
								int? northTeamNo = reader.IsDBNull("NORTHTEAMNO") ? null : reader.GetInt32("NORTHTEAMNO");
								int? northSectionTeamId = reader.IsDBNull("FKNORTHSECTIONTEAMID") ? null : reader.GetInt32("FKNORTHSECTIONTEAMID");
								int? eastTeamNo = reader.IsDBNull("EASTTEAMNO") ? null : reader.GetInt32("EASTTEAMNO");
								int? eastSectionTeamId = reader.IsDBNull("FKEASTSECTIONTEAMID") ? null : reader.GetInt32("FKEASTSECTIONTEAMID");
								int? southTeamNo = reader.IsDBNull("SOUTHTEAMNO") ? null : reader.GetInt32("SOUTHTEAMNO");
								int? southSectionTeamId = reader.IsDBNull("FKSOUTHSECTIONTEAMID") ? null : reader.GetInt32("FKSOUTHSECTIONTEAMID");
								int? westTeamNo = reader.IsDBNull("WESTTEAMNO") ? null : reader.GetInt32("WESTTEAMNO");
								int? westSectionTeamId = reader.IsDBNull("FKWESTSECTIONTEAMID") ? null : reader.GetInt32("FKWESTSECTIONTEAMID");
								RoundMatch roundMatch = new RoundMatch(id, roundId, tableNo, northTeamNo, northSectionTeamId, eastTeamNo, eastSectionTeamId, southTeamNo, southSectionTeamId, westTeamNo, westSectionTeamId);
								roundMatches.Add(roundMatch);
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
			return roundMatches;
		}
	}
}
