using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Index
{
	public partial class Pennor : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            
        }

        protected void buttonFivePackBuy_Click(object sender, EventArgs e)
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