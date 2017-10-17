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
                        if (shoppingCartTable.Rows[0].Cells[0].Text == "")
                        {
                            shoppingCartTable.Rows[0].Cells[0].Text += "Häftapparat";
                            shoppingCartTable.Rows[0].Cells[1].Text = "1";
                        }
                        else
                        {
                            int numberOf = int.Parse(shoppingCartTable.Rows[0].Cells[1].Text);
                            ++numberOf;
                            shoppingCartTable.Rows[0].Cells[1].Text = numberOf.ToString();

                        }
                    }
                    else if (artikel == "2")
                    {
                        
                        if (shoppingCartTable.Rows[1].Cells[0].Text == "")
                        {
                            shoppingCartTable.Rows[1].Cells[0].Text += "Penna";
                            shoppingCartTable.Rows[1].Cells[1].Text = "1";
                        }
                        else
                        {
                            int numberOf = int.Parse(shoppingCartTable.Rows[1].Cells[1].Text);
                            ++numberOf;
                            shoppingCartTable.Rows[1].Cells[1].Text = numberOf.ToString();
                        }
                    }
                    else if (artikel == "3")
                    {
                        if (shoppingCartTable.Rows[2].Cells[0].Text == "")
                        {
                            shoppingCartTable.Rows[2].Cells[0].Text += "Gem";
                            shoppingCartTable.Rows[2].Cells[1].Text = "1";
                        }
                        else
                        {
                            int numberOf = int.Parse(shoppingCartTable.Rows[2].Cells[1].Text);
                            ++numberOf;
                            shoppingCartTable.Rows[2].Cells[1].Text = numberOf.ToString();
                        }
                    }
                    else if (artikel == "4")
                    {
                        if (shoppingCartTable.Rows[3].Cells[0].Text == "")
                        {
                            shoppingCartTable.Rows[3].Cells[0].Text += "Papper";
                            shoppingCartTable.Rows[3].Cells[1].Text = "1";
                        }
                        else
                        {
                            int numberOf = int.Parse(shoppingCartTable.Rows[3].Cells[1].Text);
                            ++numberOf;
                            shoppingCartTable.Rows[3].Cells[1].Text = numberOf.ToString();
                        }
                    }
                }
                
            }

        }
    }
}