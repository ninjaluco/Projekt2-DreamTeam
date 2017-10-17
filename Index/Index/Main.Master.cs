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
        //Kallas på från alla sidor. Lägger till varan i cookie. TODO: lägg till funktionalitet för mer än en vara.
        public void buttonBuyThings_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            //implementera cookies olika beroende på vem som är inloggad
            if (Request.Cookies["shoppingCart"] != null)
            {
                string newCookie = Request.Cookies["shoppingCart"].Value;
                newCookie += clickedButton.CommandArgument;
                Response.Cookies["shoppingCart"].Value = newCookie;
                Response.Cookies["shoppingCart"].Expires = DateTime.Now.AddDays(1);
            }
            else
            {
                Response.Cookies["shoppingCart"].Value = clickedButton.CommandArgument;
                Response.Cookies["shoppingCart"].Expires = DateTime.Now.AddDays(1);
            }
        }
    }
}