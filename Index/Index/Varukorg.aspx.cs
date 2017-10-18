using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SqlLibrary;

namespace Index
{
    public partial class Varukorg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Laddar cookien och plockar ut artikelid för artiklarna i varukorgen.
            if (Request.Cookies["shoppingCart"].Value != null)
            {
                string[] data = Request.Cookies["shoppingCart"].Value.Split(',');
                KlassBibliotek sqlBibliotek = new KlassBibliotek();
                List<Artiklar> artikelList = sqlBibliotek.ReadAllArtiklar();

                foreach (var artikel in data)
                {
                    if (artikel != "")
                    {
                        bool exists = false;
                        Artiklar artikelInfo = artikelList.FirstOrDefault(x => x.AID == int.Parse(artikel));
                        if (artikelInfo != null)
                        {
                            for (int i = 0; i < shoppingCartTable.Rows.Count; i++)
                            {
                                if (artikelInfo.AID.ToString() == shoppingCartTable.Rows[i].Cells[0].Text)
                                {
                                    int numberOf = int.Parse(shoppingCartTable.Rows[i].Cells[2].Text);
                                    numberOf++;
                                    shoppingCartTable.Rows[i].Cells[2].Text = numberOf.ToString();
                                    exists = true;
                                }

                            }
                            if (!exists)
                            {
                                {
                                    TableRow newRow = new TableRow();

                                    TableCell newCell1 = new TableCell();
                                    TableCell newCell2 = new TableCell();
                                    TableCell newCell3 = new TableCell();


                                    newCell1.Text = artikelInfo.AID.ToString();
                                    newCell2.Text = artikelInfo.artikelnamn;
                                    newCell3.Text = "1";

                                    newRow.Cells.Add(newCell1);
                                    newRow.Cells.Add(newCell2);
                                    newRow.Cells.Add(newCell3);

                                    shoppingCartTable.Rows.Add(newRow);


                                }
                            }

                        }







                    }
                    

                    


                    //if (artikel == "1")
                    //{
                    //    if (shoppingCartTable.Rows[0].Cells[0].Text == "")
                    //    {
                    //        shoppingCartTable.Rows[0].Cells[0].Text += "Häftapparat";
                    //        shoppingCartTable.Rows[0].Cells[1].Text = "1";
                    //    }
                    //    else
                    //    {
                    //        int numberOf = int.Parse(shoppingCartTable.Rows[0].Cells[1].Text);
                    //        ++numberOf;
                    //        shoppingCartTable.Rows[0].Cells[1].Text = numberOf.ToString();

                    //    }
                    //}
                    //else if (artikel == "2")
                    //{
                        
                    //    if (shoppingCartTable.Rows[1].Cells[0].Text == "")
                    //    {
                    //        shoppingCartTable.Rows[1].Cells[0].Text += "Penna";
                    //        shoppingCartTable.Rows[1].Cells[1].Text = "1";
                    //    }
                    //    else
                    //    {
                    //        int numberOf = int.Parse(shoppingCartTable.Rows[1].Cells[1].Text);
                    //        ++numberOf;
                    //        shoppingCartTable.Rows[1].Cells[1].Text = numberOf.ToString();
                    //    }
                    //}
                    //else if (artikel == "3")
                    //{
                    //    if (shoppingCartTable.Rows[2].Cells[0].Text == "")
                    //    {
                    //        shoppingCartTable.Rows[2].Cells[0].Text += "Gem";
                    //        shoppingCartTable.Rows[2].Cells[1].Text = "1";
                    //    }
                    //    else
                    //    {
                    //        int numberOf = int.Parse(shoppingCartTable.Rows[2].Cells[1].Text);
                    //        ++numberOf;
                    //        shoppingCartTable.Rows[2].Cells[1].Text = numberOf.ToString();
                    //    }
                    //}
                    //else if (artikel == "4")
                    //{
                    //    if (shoppingCartTable.Rows[3].Cells[0].Text == "")
                    //    {
                    //        shoppingCartTable.Rows[3].Cells[0].Text += "Papper";
                    //        shoppingCartTable.Rows[3].Cells[1].Text = "1";
                    //    }
                    //    else
                    //    {
                    //        int numberOf = int.Parse(shoppingCartTable.Rows[3].Cells[1].Text);
                    //        ++numberOf;
                    //        shoppingCartTable.Rows[3].Cells[1].Text = numberOf.ToString();
                    //    }
                    //}
                }
                
            }

        }
    }
}