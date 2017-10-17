using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;



namespace SqlLibrary
{
    //============================================================================
    //      Lär dig 3 sa! ----  1. SqlCommand - utför något.                    ||
    //                          2. SqlConnection - Connection mot databasen.    ||
    //                          3. SqlDataReader - Läs data från databasen.     ||
    //============================================================================

    public class KlassBibliotek
    {
        // INSERT THE CONNECTION STRING FROM THE DATABASE!
        static string connString = @"";

        SqlConnection sqlConnection = new SqlConnection(connString);

        //=========================================================================================
        //=========================================================================================
        //====================      KUND REGISTRERING      ========================================
        //=========================================================================================
        //=========================================================================================
        #region

        //Returning an INT. While something is wrong the int will be -1.
        public bool KundRegistrering(string name, string nickName, string passWord, string telefon,
            string eMail, string Street, string City, string Zip, string SSN)
        {
            SqlCommand sqlCommand = new SqlCommand(); //Skapa alltid i varje ny metod
            sqlCommand.CommandText = "RegisterUser";
            sqlCommand.CommandType = CommandType.StoredProcedure; //Sparat i Managment studio
            sqlCommand.Connection = sqlConnection;

            sqlCommand.Parameters.Add(CreateVarcharParameter("@name", name));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@nick", nickName));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@pass", passWord));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@tel", telefon));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@epost", eMail));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@street", Street));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@city", City));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@zip", Zip));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@ssn", SSN));
            
            int rowEffected;

            try
            {
                sqlConnection.Open();
                rowEffected = sqlCommand.ExecuteNonQuery();

            }
            catch
            {
                rowEffected = -1;

            }
            finally
            {
                sqlConnection.Close();
            }
            return rowEffected > 0; //true or false is returning


           
        }
        //=========================================================================================
        //==========KUND AVLÄSNING=================================================================

        public List<Kunder> ReadAllContacts()
        {
            List<Kunder> kunder = new List<Kunder>();
            SqlCommand sqlCommand = new SqlCommand(); //Skapa alltid i varje ny metod
            sqlCommand.CommandText = "select * from kundRegister";
            sqlCommand.CommandType = CommandType.Text; //Sparat i Managment studio
            sqlCommand.Connection = sqlConnection;



            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Kunder kund = new Kunder();
                    kund.kundID = (int)reader["KID"]; //(int) Called a Casting
                    kund.name = (string)reader["name"];
                    kund.nickName = (string)reader["nickname"];
                    kund.passWord = (string)reader["Password"];
                    kund.telefon = (string)reader["telefon"];
                    kund.eMail = (string)reader["Email"];
                    kund.Street = (string)reader["Street"];
                    kund.City = (string)reader["City"];
                    kund.Zip = (string)reader["Zip"];
                    kund.SSN = (string)reader["SSN"];

                    kunder.Add(kund);
                }


            }
            catch
            {
                kunder = null;
            }
            finally
            {
                sqlConnection.Close();
            }
            return kunder; //true or false is returning
        }
        //=========================================================================================
        //==========KUND UPPDATERING===============================================================        

        public bool UpdateContact(int kundID, string name, string nickName, string passWord, string telefon,
            string eMail, string Street, string City, string Zip, string SSN)
        {
            SqlCommand sqlCommand = new SqlCommand(); //Skapa alltid i varje ny metod
            sqlCommand.CommandText = "UpdateContact";
            sqlCommand.CommandType = CommandType.StoredProcedure; //Sparat i Managment studio
            sqlCommand.Connection = sqlConnection;


            //update Contact            
            sqlCommand.Parameters.Add(CreateIntParam("@KID", kundID));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@name", name));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@nick", nickName));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@pass", passWord));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@tel", telefon));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@epost", eMail));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@street", Street));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@city", City));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@zip", Zip));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@ssn", SSN));

            int rowEffected;

            try
            {
                sqlConnection.Open();
                rowEffected = sqlCommand.ExecuteNonQuery();

            }
            catch
            {
                rowEffected = -1;

            }
            finally
            {
                sqlConnection.Close();
            }
            return rowEffected > 0; //true or false is returning
        }
        //=========================================================================================
        //==========KUND BORTTAGNING===============================================================

        public bool TaBortKundRegister(int kundID)
        {
            SqlCommand deleteKund = new SqlCommand(); //Skapa alltid i varje ny metod
            deleteKund.CommandText = "DeleteContact";
            deleteKund.CommandType = CommandType.StoredProcedure; //Sparat i Managment studio
            deleteKund.Connection = sqlConnection;
            SqlParameter idParam = CreateIntParam("@KID", kundID);
            deleteKund.Parameters.Add(idParam);
            int rowEffected;

            try
            {
                sqlConnection.Open();
                rowEffected = sqlCommand.ExecuteNonQuery();

            }
            catch
            {
                rowEffected = -1;

            }
            finally
            {
                sqlConnection.Close();
            }
            return rowEffected > 0; //true or false is returning
        }
        //=========================================================================================

        #endregion


        //=========================================================================================
        //=========================================================================================
        //====================      REGISTRERING AV VAROR      ====================================
        //=========================================================================================
        //=========================================================================================  
        //artikelnamn pris kategori ArtikelID

        //=========================================================================================
        //==========ARTIKEL REGISTRERING===========================================================
        public bool ArtikelRegistrering(int AID, string artikelnamn, string pris, string kategori)
        {
            SqlCommand sqlCommand = new SqlCommand(); //Skapa alltid i varje ny metod
            sqlCommand.CommandText = "RegisterArtikel";
            sqlCommand.CommandType = CommandType.StoredProcedure; //Sparat i Managment studio
            sqlCommand.Connection = sqlConnection;

            sqlCommand.Parameters.Add(CreateIntParam("@ArtikelID", AID));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@artikelnamn", artikelnamn));
            sqlCommand.Parameters.Add(CreateIntParam("@pris", pris));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@kategori", kategori));
           

            int rowEffected;

            try
            {
                sqlConnection.Open();
                rowEffected = sqlCommand.ExecuteNonQuery();

            }
            catch
            {
                rowEffected = -1;

            }
            finally
            {
                sqlConnection.Close();
            }
            return rowEffected > 0; //true or false is returning

            
        }

        //=========================================================================================
        //==========ARTIKEL AVLÄSNING==============================================================

        public List<Artiklar> ReadAllArtiklar()
        {
            List<Artiklar> artiklar = new List<Artiklar>();
            SqlCommand sqlCommandArt = new SqlCommand(); //Skapa alltid i varje ny metod
            sqlCommandArt.CommandText = "select * from RegisterArtikel";
            sqlCommandArt.CommandType = CommandType.Text; //Sparat i Managment studio
            sqlCommandArt.Connection = sqlConnection;

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommandArt.ExecuteReader();

                while (reader.Read())
                {
                    Artiklar artikel = new Artiklar();
                    artikel.artikelnamn = (string)reader["artikelnamn"]; 
                    artikel.pris = (int)reader["pris"];
                    artikel.kategori = (string)reader["kategori"];                    

                    artiklar.Add(artikel);
                }

            }
            catch
            {
                artiklar = null;
            }
            finally
            {
                sqlConnection.Close();
            }
            return artiklar;
        }
        //=========================================================================================
        //==========ARTIKEL UPPDATERING============================================================

        public bool UpdateArtikel(int AID, string artikelnamn, string pris, string kategori)
        {
            SqlCommand sqlCommand = new SqlCommand(); //Skapa alltid i varje ny metod
            sqlCommand.CommandText = "UpdateArtikel";
            sqlCommand.CommandType = CommandType.StoredProcedure; //Sparat i Managment studio
            sqlCommand.Connection = sqlConnection;

           
            sqlCommand.Parameters.Add(CreateIntParam("@AID", AID));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@artikelnamn", artikelnamn));
            sqlCommand.Parameters.Add(CreateIntParam("@pris", pris));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@kategori", kategori));
           

            int rowEffected;

            try
            {
                sqlConnection.Open();
                rowEffected = sqlCommand.ExecuteNonQuery();

            }
            catch
            {
                rowEffected = -1;

            }
            finally
            {
                sqlConnection.Close();
            }
            return rowEffected > 0; //true or false is returning
        }
        //=========================================================================================
        //==========ARTIKEL RADERING===============================================================

        //=========================================================================================
        //=========================================================================================
        //====================      HELPING METHODS      ==========================================
        //=========================================================================================
        //=========================================================================================
        #region
        //========CREATE VARCHARS =================================================================

        private SqlParameter CreateVarcharParameter(string parameterName, string value, int size)
        {
            SqlParameter Param = new SqlParameter();
            Param.Direction = ParameterDirection.Input;
            Param.ParameterName = parameterName;
            Param.SqlDbType = SqlDbType.VarChar;
            Param.Size = size;
            Param.Value = value;
            return Param;
        }
        //=========================================================================================
        //========CREATE INT ======================================================================

        private SqlParameter CreateIntParam(string parameterName, int value)
        {
            SqlParameter Param = new SqlParameter();
            Param.Direction = ParameterDirection.Input;
            Param.ParameterName = parameterName;
            Param.SqlDbType = SqlDbType.Int;
            Param.Value = value;
            return Param;
        }
        #endregion




    }
}
