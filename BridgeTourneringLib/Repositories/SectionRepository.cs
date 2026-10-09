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
	public class SectionRepository : ISectionRepository
	{
		private string connectionString = Secret.ConnectionString;
		private readonly string selectByGroupTournamentID;

		public SectionRepository(string clubNo)
		{
			selectByGroupTournamentID = "SELECT ID, SECTIONNO, STARTTIME, ENDTIME, STARTROUNDNO, ENDROUNDNO FROM club" + clubNo + ".SECTION WHERE FKGROUPTOURNAMENTID = @GROUPTOURNAMENTID ORDER BY SECTIONNO";
		}

		public async Task<IEnumerable<Section>> GetSectionsByGroupTournamentIDAsync(int groupTournamentId)
		{
			List<Section> sections = new List<Section>();
			using (SqlConnection connect = new SqlConnection(connectionString))
			{
				try
				{
					await connect.OpenAsync();
					using (SqlCommand command = new SqlCommand(selectByGroupTournamentID, connect))
					{
						command.Parameters.AddWithValue("@GROUPTOURNAMENTID", groupTournamentId);
						using (SqlDataReader reader = await command.ExecuteReaderAsync())
						{
							while (await reader.ReadAsync())
							{
								int sectionId = reader.GetInt32("ID");
								int? sectionNo = reader.IsDBNull("SECTIONNO") ? null : reader.GetInt32("SECTIONNO");
								DateTime? startTime = reader.IsDBNull("STARTTIME") ? null : reader.GetDateTime("STARTTIME");
								DateTime? endTime = reader.IsDBNull("ENDTIME") ? null : reader.GetDateTime("ENDTIME");
								int? startRoundNo = reader.IsDBNull("STARTROUNDNO") ? null : reader.GetInt32("STARTROUNDNO");
								int? endRoundNo = reader.IsDBNull("ENDROUNDNO") ? null : reader.GetInt32("ENDROUNDNO");
								Section section = new Section(sectionId, sectionNo, startTime, endTime, startRoundNo, endRoundNo);
								sections.Add(section);
							}
						}
					}
				}
				catch (SqlException sqlEx)
				{
					Console.WriteLine("SQL DB Error: ", sqlEx.Message);
				}
			}
			return sections;
		}
	}
}
