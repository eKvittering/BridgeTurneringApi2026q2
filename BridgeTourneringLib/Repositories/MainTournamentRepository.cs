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
	public class MainTournamentRepository
	{
		private string connectionString = Secret.ConnectionString;
		private readonly string selectSql;

		public MainTournamentRepository(string clubNo)
		{
			selectSql = "SELECT ID, NAME, DESCRIPTION, TOURNAMENTFORM, COMMONTOP, FKCLUBID, INCLUBCLUBNAME, USELEADS, STRENGTHGROUPCOUNT, LASTCHANGEDBY, LAST_CHANGED_BY, LAST_CHANGED_DATE, NUMBEROFGROUPS, NUMBEROFPLAYINGDAYS, IS_VISIBLE, DO_WEB_PUBLISH, IS_FLEXIBLE, FLEXIBLEPERCENT FROM club" + clubNo + ".MAINTOURNAMENT";
		}

		public async Task<IEnumerable<MainTournament>> GetMainTournament()
		{
			List<MainTournament> mainTournaments = new List<MainTournament>();
			using (SqlConnection connect = new SqlConnection(connectionString))
			{
				try
				{
					await connect.OpenAsync();
					using (SqlCommand command = new SqlCommand(selectSql, connect))
					{
						using (SqlDataReader reader = await command.ExecuteReaderAsync())
						{
							while (await reader.ReadAsync())
							{
								int mainTournamentId = reader.GetInt32("ID");
								string? name = reader.IsDBNull("NAME") ? null : reader.GetString("NAME");
								string? description = reader.IsDBNull("DESCRIPTION") ? null : reader.GetString("DESCRIPTION");
								int? tournamentForm = reader.IsDBNull("TOURNAMENTFORM") ? null : reader.GetInt32("TOURNAMENTFORM");
								int? commonTop = reader.IsDBNull("COMMONTOP") ? null : reader.GetInt16("COMMONTOP");
								int? clubId = reader.IsDBNull("FKCLUBID") ? null : reader.GetInt32("FKCLUBID");
								int? inClubName = reader.IsDBNull("INCLUBNAME") ? null : reader.GetInt16("INCLUBNAME");
								int? useLeads = reader.IsDBNull("USELEADS") ? null : reader.GetInt16("USELEADS");
								int? strengthGroupCount = reader.IsDBNull("STRENGTHGROUPCOUNT") ? null : reader.GetInt32("STRENGTHGROUPCOUNT");
								string? lastChangedBy = reader.IsDBNull("LAST_CHANGED_BY") ? null : reader.GetString("LAST_CHANGED_BY");
								DateOnly? lastChangedDate = reader.IsDBNull("LAST_CHANGED_DATE") ? null : DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("LAST_CHANGED_DATE")));
								int? numberOfGroups = reader.IsDBNull("NUMBEROFGROUPS") ? null : reader.GetInt16("NUMBEROFGROUPS");
								int? numberOfPlayingDays = reader.IsDBNull("NUMBEROFPLAYINGDAYS") ? null : reader.GetInt16("NUMBEROFPLAYINGDAYS");
								int? isVisible = reader.IsDBNull("ISVISIBLE") ? null : reader.GetInt16("ISVISIBLE");
								int? doWebPublish = reader.IsDBNull("DO_WEB_PUBLISH") ? null : reader.GetInt16("DO_WEB_PUBLISH");
								int? isFlexible = reader.IsDBNull("IS_FLEXIBLE") ? null : reader.GetInt16("IS_FLEXIBLE");
								int? flexiblePercent = reader.IsDBNull("FLEXIBLEPERCENT") ? null : reader.GetInt32("FLEXIBLEPERCENT");
								MainTournament mainTournament = new MainTournament(mainTournamentId, name, description, tournamentForm, commonTop, clubId, inClubName, useLeads, strengthGroupCount, lastChangedBy, lastChangedDate, numberOfGroups, numberOfPlayingDays, isVisible, doWebPublish, isFlexible, flexiblePercent);
								mainTournaments.Add(mainTournament);
							}
						}
					}
				}
				catch (SqlException sqlEx)
				{
					Console.WriteLine("SQL DB Error: ", sqlEx.Message);
				}
			}
			return mainTournaments;
		}
	}
}
