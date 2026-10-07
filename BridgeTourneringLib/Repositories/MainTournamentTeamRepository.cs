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
	public class MainTournamentTeamRepository : IMainTournamentTeamRepository
	{
		private string connectionString = Secret.ConnectionString;
		private readonly string selectSql;

		public MainTournamentTeamRepository(string clubNo)
		{
			selectSql = "SELECT ID, FKMAINTOURNAMENTID, TEAMNO, TEAMNAME, TOURNAMENTTYPE FROM club" + clubNo + ".MAINTOURNAMENTTEAM WHERE FKMAINTOURNAMENTID = @MAINTOURNAMENTTEAMID ORDER BY TEAMNO";
		}

		public async Task<IEnumerable<MainTournamentTeam>> GetMainTournamentTeamsByMainTournamentTeamIdAsync(int mainTournamentTeamId)
		{
			List<MainTournamentTeam> mainTournamentTeams = new List<MainTournamentTeam>();
			using (SqlConnection connect = new SqlConnection(connectionString))
			{
				try
				{
					await connect.OpenAsync();
					using (SqlCommand command = new SqlCommand(selectSql, connect))
					{
						command.Parameters.AddWithValue("@GROUPTOURNAMENTID", mainTournamentTeamId);
						using (SqlDataReader reader = await command.ExecuteReaderAsync())
						{
							while (await reader.ReadAsync())
							{
								int teamId = reader.GetInt32("ID");
								int? teamNo = reader.IsDBNull("TEAMNO") ? null : reader.GetInt32("TEAMNO");
								string? teamName = reader.IsDBNull("TEAMNAME") ? null : reader.GetString("TEAMNAME");
								int? tournamentType = reader.IsDBNull("TOURNAMENTTYPE") ? null : reader.GetInt32("TOURNAMENETTYPE");
								MainTournamentTeam mainTournamentTeam = new MainTournamentTeam(teamId, mainTournamentTeamId, teamNo, teamName, tournamentType);
								mainTournamentTeams.Add(mainTournamentTeam);
							}
						}
					}
				}
				catch (SqlException sqlEx)
				{
					Console.WriteLine("SQL DB Error: ", sqlEx.Message);
				}
			}
			return mainTournamentTeams;
		}
	}
}
