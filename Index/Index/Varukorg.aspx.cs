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
            //Laddar cookien och plockar ut artikelvärde. Byggs ut när databasen är klar.
            if (Request.Cookies["shoppingCart"] != null)
            {
                string[] data = Request.Cookies["shoppingCart"].Value.Split(',');

                foreach (var artikel in data)
                {
                    if (artikel == "1")
                    {
                        shoppingCartTable.Rows[0].Cells[0].Text += "Häftapparat";
                    }
                    else if (artikel == "2")
                    {
                        shoppingCartTable.Rows[1].Cells[0].Text += "Penna";
                    }
                    else if (artikel == "3")
                    {
                        shoppingCartTable.Rows[2].Cells[0].Text += "Gem";
                    }
                    else if (artikel == "4")
                    {
                        shoppingCartTable.Rows[3].Cells[0].Text += "Papper";
                    }
                }
                
            }

        }
    }
}