using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Index
{
	public partial class Main : System.Web.UI.MasterPage
	{
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
	}
}