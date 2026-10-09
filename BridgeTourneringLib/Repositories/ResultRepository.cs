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
	public class ResultRepository : IResultRepository
	{
		private string connectionString = Secret.ConnectionString;
		private readonly string selectByMatchID;

		public ResultRepository(string clubNo)
		{
			selectByMatchID = "SELECT ID, FKBOARDID, BOARDNO, BOARDGROUP, BIDDINGSEQUENCE, CONTRACT, LEAD, RESULT, CALCULATEDSCORENS, CALCULATEDSCORENSPCT, CALCULATEDSCOREEW, CALCULATEDSCOREEWPCT, DECLARER, DOUBLING, TRICKS, RESULTCOMPLETED, EXCLUDEGAME, BOARDCOMPARED FROM club" + clubNo + ".RESULT WHERE FKMATCHID = @MATCHID ORDER BY BOARDNO;";
		}

		public async Task<IEnumerable<Result>> GetResultByMatchIDAsync(int matchId)
		{
			List<Result> results = new List<Result>();
			using (SqlConnection connect = new SqlConnection(connectionString))
			{
				try
				{
					await connect.OpenAsync();
					using (SqlCommand command = new SqlCommand(selectByMatchID, connect))
					{
						command.Parameters.AddWithValue("@MATCHID", matchId);
						using (SqlDataReader reader = await command.ExecuteReaderAsync())
						{
							while (await reader.ReadAsync())
							{
								int resultId = reader.GetInt32("ID");
								int? boardId = reader.IsDBNull("FKBOARDID") ? null : reader.GetInt32("FKBOARDID");
								int? boardGroup = reader.IsDBNull("BOARDGROUP") ? null : reader.GetInt32("BOARDGROUP");
								int? boardNo = reader.IsDBNull("BOARDNO") ? null : reader.GetInt32("BOARDNO");
								string? biddingSequence = reader.IsDBNull("BIDDINGSEQUENCE") ? null : reader.GetString("BIDDINGSEQUENCE");
								string? contract = reader.IsDBNull("CONTRACT") ? null : reader.GetString("CONTRACT");
								string? lead = reader.IsDBNull("LEAD") ? null : reader.GetString("LEAD");
								int? matchResult = reader.IsDBNull("RESULT") ? null : reader.GetInt32("RESULT");
								double? calculatedScoreNS = reader.IsDBNull("CALCULATEDSCORENS") ? null : reader.GetDouble("CALCULATEDSCORENS");
								double? calculatedScoreNSPCT = reader.IsDBNull("CALCULATEDSCORENSPCT") ? null : reader.GetDouble("CALCULATEDSCORENSPCT");
								double? calculatedScoreEW = reader.IsDBNull("CALCULATEDSCOREEW") ? null : reader.GetDouble("CALCULATEDSCOREEW");
								double? calculatedScoreEWPCT = reader.IsDBNull("CALCULATEDSCOREEWPCT") ? null : reader.GetDouble("CALCULATEDSCOREEWPCT");
								string? declarer = reader.IsDBNull("DECLARER") ? null : reader.GetString("DECLARER");
								string? doubling = reader.IsDBNull("DOUBLING") ? null : reader.GetString("DOUBLING");
								int? tricks = reader.IsDBNull("TRICKS") ? null : reader.GetInt32("TRICKS");
								int? resultCompleted = reader.IsDBNull("RESULTCOMPLETED") ? null : reader.GetInt16("RESULTCOMPLETED");
								int? excludeGame = reader.IsDBNull("EXCLUDEGAME") ? null : reader.GetInt16("EXCLUDEGAME");
								int? boardCompared = reader.IsDBNull("BOARDCOMPARED") ? null : reader.GetInt16("BOARDCOMPARED");
								Result result = new Result(resultId, matchId, boardId, boardGroup, boardNo, biddingSequence, contract, lead, matchResult, calculatedScoreNS, calculatedScoreNSPCT, calculatedScoreEW, calculatedScoreEWPCT, declarer, doubling, tricks, resultCompleted, excludeGame, boardCompared);
								results.Add(result);
							}
						}
					}
				}
				catch (SqlException sqlEx)
				{
					Console.WriteLine("SQL DB Error: ", sqlEx.Message);
				}
			}
			return results;
		}
	}
}
