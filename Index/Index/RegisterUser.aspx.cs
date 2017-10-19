﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SqlLibrary;

namespace Index
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
protected void ButtonReg_Click(object sender, EventArgs e)
        {
             KlassBibliotek klassBibliotek = new KlassBibliotek();

            string nick = NickName.Text;
            string pass = Password.Text;
            string name = Name.Text;
            string street = Street.Text;
            string zip = Zip.Text;
            string city = City.Text;
            string ssn = SSN.Text;
            string phone = Telefon.Text;
            string mail = Epost.Text;
            bool reg = klassBibliotek.KundRegistrering(name, nick, pass, phone, mail, street, city, zip, ssn);
            if (reg)
            {
                Response.Redirect("/Index_1.aspx");
            }
            

        }
    }
}