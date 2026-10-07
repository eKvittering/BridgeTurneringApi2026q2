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
	public class RoundRepository : IRoundRepository
	{
		private string connectionString = Secret.ConnectionString;
		private readonly string selectBySectionId;

		public RoundRepository(string clubNo)
		{
			selectBySectionId = "SELECT ID, ROUNDNO, HALFNO, STARTTIME, ENDTIME, STARTBOARD FROM club" + clubNo + ".ROUND WHERE FKSECTIONID = @SECTIONID ORDER BY ID";
		}

		public async Task<IEnumerable<Round>> GetRoundsBySectionId(int sectionId)
		{
			List<Round> rounds = new List<Round>();
			using (SqlConnection connect = new SqlConnection(connectionString))
			{
				try
				{
					await connect.OpenAsync();
					using (SqlCommand command = new SqlCommand(selectBySectionId, connect))
					{
						command.Parameters.AddWithValue("@SECTIONID", sectionId);
						using (SqlDataReader reader = await command.ExecuteReaderAsync())
						{
							while (await reader.ReadAsync())
							{
								int roundId = reader.GetInt32("ID");
								int? roundNo = reader.IsDBNull("ROUNDNO") ? null : reader.GetInt32("ROUNDNO");
								int? halfNo = reader.IsDBNull("HALFNO") ? null : reader.GetInt32("HALFNO");
								DateTime? startTime = reader.IsDBNull("STARTTIME") ? null : reader.GetDateTime("STARTTIME");
								DateTime? endTime = reader.IsDBNull("ENDTIME") ? null : reader.GetDateTime("ENDTIME");
								int? startBoard = reader.IsDBNull("STARTBOARD") ? null : reader.GetInt32("STARTBOARD");
								Round round = new Round(roundId, sectionId, roundNo, halfNo, startTime, endTime, startBoard);
								rounds.Add(round);
							}
						}
					}
				}
				catch (SqlException sqlEx)
				{
					Console.WriteLine("SQL DB Error: ", sqlEx.Message);
				}
			}
			return rounds;
		}
	}
}
