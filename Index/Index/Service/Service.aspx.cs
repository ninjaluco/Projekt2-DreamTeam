using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SqlLibrary;
using Newtonsoft.Json;


namespace Index
{
    public partial class Service : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["all"] != null)
            {
                KlassBibliotek sqlStuff = new KlassBibliotek();

                jsonLiteral.Text = JsonConvert.SerializeObject(sqlStuff.ReadAllArtiklar(), Formatting.Indented);
            }
        }
    }
}