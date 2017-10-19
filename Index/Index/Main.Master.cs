using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SqlLibrary;
using System.Data.SqlClient;

namespace Index
{
	public partial class Main : System.Web.UI.MasterPage
	{
		KlassBibliotek klassBibliotek = new KlassBibliotek();

		protected void Page_Load(object sender, EventArgs e)
		{
			
		}
		
		public void buttonBuyThings_Click(object sender, EventArgs e, int amount)
		{
			Button clickedButton = (Button)sender;
			//skapa en sträng med artikelnumret antal valda gånger och lägg till i cookien
			string newCookie = "";
			//cookiens gamla värde hamnar i strängen om den finns.
			if (Request.Cookies["shoppingCart"] != null)
				newCookie = Request.Cookies["shoppingCart"].Value;

			for (int i = 0; i < amount; i++)
			{
				newCookie += clickedButton.CommandArgument;
			}
			Response.Cookies["shoppingCart"].Value = newCookie;
			Response.Cookies["shoppingCart"].Expires = DateTime.Now.AddDays(1);
		}

		protected void LogIn(object sender, EventArgs e)
		{
			bool invalidNick = true;
			bool invalidPass = true;
            int KID = 0;
			string user = textBoxUser.Text;
			string password = textBoxLösen.Text;
			SqlConnection sqlConnection = new SqlConnection(KlassBibliotek.connString);
			try
			{
				sqlConnection.Open();
				SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM Kunder WHERE [NickName] = '{user}'", sqlConnection);
				sqlCommand.Connection = sqlConnection;
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					string index = sqlDataReader["NickName"].ToString();
					if (user == index)
					{

						SqlConnection sqlConnection2 = new SqlConnection(KlassBibliotek.connString);
						sqlConnection2.Open();
						SqlCommand sqlCommand2 = new SqlCommand($"SELECT * FROM Kunder WHERE [NickName] = '{user}' and [passWord] = '{password}'", sqlConnection2);
						sqlCommand2.Connection = sqlConnection2;
						SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
						invalidNick = false;
						while (sqlDataReader2.Read())
						{
                            KID= int.Parse(sqlDataReader2["KundID"].ToString());
							string pass = sqlDataReader2["Password"].ToString();
							if (password == pass)
							{
								invalidPass = false;
								if (user == "Admin")
									Response.Redirect("/Admin.aspx");
									
								else
									Response.Redirect("/UserProfile.aspx");
							}
                           
                        }
						sqlConnection2.Close();
						if (invalidPass)
							Response.Redirect("/Index_1.aspx");
					}
					else
					{
						Response.Redirect("/Index_1.aspx");
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				sqlConnection.Close();
			}

			if (invalidNick)
				Response.Redirect("/RegisterUser.aspx");
            
        }

        protected void Registrera(object sender, EventArgs e)
		{
            Response.Redirect("/RegisterUser.aspx");
        }
	}
}