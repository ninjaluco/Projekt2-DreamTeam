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
                KlassBibliotek sqlStuff = new KlassBibliotek();
           string kategori = "";
            if (Request["pennor"] != null)
            {
                 kategori = "Pennor";
                jsonLiteral.Text = JsonConvert.SerializeObject(sqlStuff.ReadAllArtiklar(kategori), Formatting.Indented);
            }
            if (Request["papper"] != null)
            {
                kategori = "Papper";

                jsonLiteral.Text = JsonConvert.SerializeObject(sqlStuff.ReadAllArtiklar(kategori), Formatting.Indented);
            }
            if (Request["haftapparater"] != null)
            {
                kategori = "häftapparater";

                jsonLiteral.Text = JsonConvert.SerializeObject(sqlStuff.ReadAllArtiklar(kategori), Formatting.Indented);
            }
            if (Request["gem"] != null)
            {
                kategori = "Gem";

                jsonLiteral.Text = JsonConvert.SerializeObject(sqlStuff.ReadAllArtiklar(kategori), Formatting.Indented);
            }


            //KlassBibliotek sqlStuff = new KlassBibliotek();
            //    jsonLiteral.Text = JsonConvert.SerializeObject(sqlStuff.ReadAllArtiklar(kategori), Formatting.Indented);
        }
    }
}