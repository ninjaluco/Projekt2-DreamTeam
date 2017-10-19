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


            if (Request.Cookies["shoppingCart"] != null)
            {
                string cookieData = Request.Cookies["shoppingCart"].Value;

                cookieData = cookieData.Replace("%2C", ",");

                string[] data = cookieData.Split(',');
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
                                    TextBox superTextBox = (TextBox)shoppingCartTable.Rows[i].Cells[2].Controls[0];
                                    int numberOf = int.Parse(superTextBox.Text);
                                    numberOf++;
                                    int totalPrice = numberOf * artikelInfo.pris;
                                    superTextBox.Text = numberOf.ToString();
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

                                    TextBox numberBox = new TextBox();
                                    numberBox.Attributes.Add("type", "number");
                                    numberBox.Attributes.Add("min", "1");
                                    numberBox.Attributes.Add("runat", "server");
                                    numberBox.Attributes.Add("class", "numberBoxes");
                                    numberBox.Text = "1";
                                    numberBox.Attributes.Add("OnTextChanged", "ChangeNumberText");
                                    //numberBox.Attributes.Add("autopostback", "true");
                                    numberBox.Attributes.Add("ID", $"numberBox{shoppingCartTable.Rows.Count - 1}");

                                    newCell1.Text = artikelInfo.AID.ToString();
                                    newCell2.Text = artikelInfo.artikelnamn;
                                    newCell3.Controls.Add(numberBox);
                                    //newCell3.Text = $"<asp:TextBox ID=\"numberTextBox{}\" type=\"number\" min=\"1\" runat=\"server\">1</asp:TextBox>";
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
                sumOfAll.Text = $"{superSum.ToString()}";


            }
        }

        private void ChangeNumberText(object sender, EventArgs e)
        {
            TextBox changedBox = (TextBox)sender;
            //Letar med hjälp av textboxens autogenererade id upp artikelID det handlar om.
            string artikelID = shoppingCartTable.Rows[int.Parse(changedBox.Attributes["ID"])].Cells[0].Text;

            string[] data = Request.Cookies["shoppingCart"].Value.Split(',');
            List<string> dataList = new List<string>();
            foreach (var artikel in data)
            {
                dataList.Add(artikel);
            }
            int counter = 0;
            foreach (var artikel in dataList)
            {
                if (artikel == artikelID)
                {
                    counter++;
                }
            }
            while (counter != int.Parse(changedBox.Text))
            {
                if (counter > int.Parse(changedBox.Text))
                {
                    dataList.Remove(dataList.FirstOrDefault(x => x == artikelID));
                    counter--;
                }
                else if (counter < int.Parse(changedBox.Text))
                {
                    dataList.Add(artikelID);
                    counter++;
                }
            }
            string fullCookie = "";

            foreach (var artikel in dataList)
            {
                fullCookie += $"{artikel},";
            }
            Response.Cookies["shoppingCart"].Value = fullCookie;
            Response.Cookies["shoppingCart"].Expires = DateTime.Now.AddDays(1);

            LoadShoppingCart();
        }

        protected void buttonBuy_Click(object sender, EventArgs e)
        {

            int orderID = 1;


            string varukorg = Request.Cookies["shoppingCart"].Value;


        }
    }
}