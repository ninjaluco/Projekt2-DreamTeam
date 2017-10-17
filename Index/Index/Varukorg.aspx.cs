using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Index
{
    public partial class Varukorg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.Cookies["shoppingCart"] != null)
            {
                shoppingCartTable.Rows[0].Cells[0].Text = Request.Cookies["shoppingCart"].Value;
                
            }

        }
    }
}