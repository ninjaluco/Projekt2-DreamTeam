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
            LoadShoppingCart();

        }

        private void LoadShoppingCart()
        {
            //Laddar cookien och plockar ut artikelid för artiklarna i varukorgen. Genererar HTML-tabell.
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
                                    int totalPrice = numberOf * artikelInfo.pris;
                                    shoppingCartTable.Rows[i].Cells[2].Text = $"{numberOf.ToString()}";
                                    shoppingCartTable.Rows[i].Cells[4].Text = $"{totalPrice.ToString()}";

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
                                    TableCell newCell4 = new TableCell();
                                    TableCell newCell5 = new TableCell();


                                    newCell1.Text = artikelInfo.AID.ToString();
                                    newCell2.Text = artikelInfo.artikelnamn;
                                    newCell3.Text = "1";
                                    newCell4.Text = $"{artikelInfo.pris.ToString()}";
                                    newCell5.Text = $"{artikelInfo.pris.ToString()}";
                                    newCell5.CssClass = "sum";

                                    newRow.Cells.Add(newCell1);
                                    newRow.Cells.Add(newCell2);
                                    newRow.Cells.Add(newCell3);
                                    newRow.Cells.Add(newCell4);
                                    newRow.Cells.Add(newCell5);

                                    shoppingCartTable.Rows.AddAt(shoppingCartTable.Rows.Count - 1, newRow);
                                }
                            }
                        }
                    }
                }
                int superSum = 0;
                for (int i = 0; i < shoppingCartTable.Rows.Count; i++)
                {
                    if (shoppingCartTable.Rows[i].Cells[4].CssClass == "sum")
                    {
                        superSum += int.Parse(shoppingCartTable.Rows[i].Cells[4].Text);
                    }
                }
                sumOfAll.Text = $"Totalsumma: {superSum.ToString()} kr";


            }
        }
    }
}