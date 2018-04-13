using System;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin;

namespace JamnationApp.Core
{
	public class DatabaseManager
	{

		private SQLiteConnection _connection;

		public DatabaseManager()
		{
			CreateTable ();
		}

		private void CreateTable()
		{
			//_connection = (App.Resolve<ISQLite> () as ISQLite).GetConnection ();
			//_connection.CreateTable<AutoLocation> ();
			
		}

       
        /*
		public void InsertAutoLocations(List<AutoLocation> autoLocationList)
		{
			lock (_connection) {
				_connection.InsertAll (autoLocationList); 
			}
		}

        
		public void InsertMemberDetails(MemberDetails memberDetails)
		{ 

			lock (_connection) {
				
				memberDetails.LoggedInDate = DateTime.Now;

				_connection.Insert (memberDetails); 
				int id = (int)_connection.ExecuteScalar<int> ("SELECT last_insert_rowid()");
				if (memberDetails.Outfits != null) {
					InsertMemberOutfits (memberDetails.Outfits, id);
				}

				if (memberDetails.BusinessPartners != null && memberDetails.BusinessPartners.Party.Count > 0) {
					InsertBusinessPartners (memberDetails.BusinessPartners.Party, id);
				}


				if (memberDetails.Address != null) {
					InsertMemberAddress (memberDetails.Address, id);
				}
			}
		}*/
        
	}
}