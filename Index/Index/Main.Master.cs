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
			SqlConnection sqlConnection = new SqlConnection();
			string user = textBoxUser.Text;
			string password = textBoxLösen.Text;
			klassBibliotek.ReadAllContacts();
			//ReadAllCon(user);

			SqlCommand checkNameValidation = new SqlCommand("SELECT * FROM Kunder WHERE ([NickName] = @nick)", sqlConnection);
			checkNameValidation.Parameters.AddWithValue("@nick", user);

			SqlCommand checkNameValidation1 = new SqlCommand("SELECT * FROM Kunder WHERE ([passWord] = @pass)", sqlConnection);
			checkNameValidation1.Parameters.AddWithValue("@pass", password);

			//if ((textBoxUser.Text.ToUpper() == "KIM") &&
			//   (textBoxLösen.Text.ToUpper() == "KIM"))

			if (checkNameValidation == checkNameValidation1)
			{
				Response.Redirect("LogOn.aspx");

			}
			else
			{
				Response.Redirect("Gem.aspx");

			}

		}

		//private void ReadAllCon(string kund)
		//{
		//	//SqlCommand checkNameValidation = new SqlCommand("SELECT * FROM Kunder WHERE ([NickName] = @nick)", sqlConnection);
		//	//checkNameValidation.Parameters.AddWithValue("@nick", nickName);
		//	klassBibliotek.ReadAllContacts();
		//	List<Kunder> kunder = new List<Kunder>();
		//	foreach (var item in kunder)
		//	{
		//		if (item.nickName == kund)
		//		{
		//			Response.Redirect("LogOn.apsx");
		//		}
		//	}
		//}

		protected void SignIn(object sender, EventArgs e)
		{

			string user = textBoxUser.Text;
			string password = textBoxLösen.Text;

			if (true)
			{

			}
		}
	}
}