using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SqlLibrary;


namespace Index
{
	public partial class UserProfile : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                LoadOrders();
            }
		}

        protected void KundDelete_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["loggedInUser"] != null)
            {
                int kundID = int.Parse(Request.Cookies["loggedInUser"].Value);

                KlassBibliotek klass = new KlassBibliotek();

                klass.TaBortKundRegister(kundID);

                Response.Cookies["loggedInUser"].Value = "";
                Response.Cookies["loggedInUser"].Expires = DateTime.Now.AddDays(-1d);

                Response.Redirect("/Index_1.aspx");
            }
            
        }

        protected void historikText_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (historikText.SelectedIndex >= 0)
            //{
            //    KlassBibliotek ordrar = new KlassBibliotek();

            //    List<Order> allaOrdrar = ordrar.
            //}
        }

        void LoadOrders()
        {
            if (Request.Cookies["loggedInUser"] != null)
            {
                int kundID = int.Parse(Request.Cookies["loggedInUser"].Value);

                KlassBibliotek klass = new KlassBibliotek();

                List<Order> allaOrdrar = klass.ReadAllOrders();
                if (allaOrdrar != null)
                {
                    var ordrarFrånKundID = allaOrdrar.Where(x => x.KID == kundID);

                    if (ordrarFrånKundID != null)
                    {
                        foreach (var order in ordrarFrånKundID)
                        {
                            historikText.Items.Add($"{order.OID}");
                        }
                    }
                }
                
                
                

            }
        }
    }
}