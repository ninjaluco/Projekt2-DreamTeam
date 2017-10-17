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
            if (Request.Cookies["shoppingCart"] != null)
            {
                string newCookie = Request.Cookies["shoppingCart"].Value;
                newCookie += "penna";
                Response.Cookies["shoppingCart"].Value = newCookie;
                Response.Cookies["shoppingCart"].Expires = DateTime.Now.AddDays(1);
            }
            else
            {
                Response.Cookies["shoppingCart"].Value = "penna";
                Response.Cookies["shoppingCart"].Expires = DateTime.Now.AddDays(1);
            }
        }

        


    }
}