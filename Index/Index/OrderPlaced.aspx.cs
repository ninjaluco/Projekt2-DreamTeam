using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SqlLibrary;

namespace Index
{
    public partial class OrderPlaced : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["orderID"] != null)
                {
                    KlassBibliotek klassBibliotek = new KlassBibliotek();

                    List<Kunder> customerList = klassBibliotek.ReadAllContacts();
                    string inloggad;
                    if (Request.Cookies["loggedInUser"] != null)
                    {
                        inloggad = Request.Cookies["loggedInUser"].Value;
                        Kunder loggedInCustomer = customerList.FirstOrDefault(x => x.kundID.ToString() == inloggad);
                        string orderId = Request["orderID"].ToString();

                        orderLabel.Text = $"Order {orderId} har skickats till {loggedInCustomer.Street}, {loggedInCustomer.Zip} {loggedInCustomer.City}";
                    }
                    

                   

                    
                }
            }
        }
    }
}