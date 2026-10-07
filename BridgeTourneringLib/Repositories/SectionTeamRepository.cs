using BridgeTourneringLib.Interfaces;
using BridgeTourneringLib.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
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
			selectBySectionID = "SELECT ID, FKMAINTOURNAMENTTEAMID, FKSECTIONID, TEAMNO, STARTSCORE, ADJUSTMENTMISSING, ADJUSTMENTOTHER, REGULATIONSCORE, TIEBREAKTOURNAMENT, TRANSFERSCORE, TRANSFERBOARDS, TRANSFERPERCENT, TIEBREAKADD FROM club" + clubNo + ".SECTIONTEAM WHERE FKSECTIONID = @SECTIONID ORDER BY TEAMNO";
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
								SectionTeam sectionTeam = new SectionTeam();
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
