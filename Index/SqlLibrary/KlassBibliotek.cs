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
       public static string connString = @"Data Source=.;Initial Catalog=JoakimVonAnka;Integrated Security=True";

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

            SqlDataReader readerNick, readerSSN;
            NameAndSsnChecker(nickName, SSN, out readerNick, out readerSSN);

            bool rowEffected;

            if (readerNick.HasRows || readerSSN.HasRows || nickName.ToLower() == "admin")
            {


                return rowEffected = false;
            }
            else
            {

                try
                {
                    sqlConnection.Open();
                    rowEffected = (sqlCommand.ExecuteNonQuery() > 0);
                }
                catch
                {
                    rowEffected = false;
                }
                finally
                {
                    sqlConnection.Close();
                }
                return rowEffected; //true or false is returning

            }
            
        }
        

        //=========================================================================================
        //==========KUND AVLÄSNING=================================================================

        public List<Kunder> ReadAllContacts()
        {
            List<Kunder> kunder = new List<Kunder>();
            SqlCommand sqlCommand = new SqlCommand(); //Skapa alltid i varje ny metod
            sqlCommand.CommandText = "select * from Kunder";
            sqlCommand.CommandType = CommandType.Text; //Sparat i Managment studio
            sqlCommand.Connection = sqlConnection;


            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Kunder kund = new Kunder();
                    kund.kundID = (int)reader["KundID"]; //(int) Called a Casting
                    kund.name = (string)reader["Name"];
                    kund.nickName = (string)reader["NickName"];
                    kund.passWord = (string)reader["Password"];
                    kund.telefon = (string)reader["Telefon"];
                    kund.eMail = (string)reader["Epost"];
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
            sqlCommand.CommandText = "UpdateUser";
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
            deleteKund.CommandText = "DeleteUser";
            deleteKund.CommandType = CommandType.StoredProcedure; //Sparat i Managment studio
            deleteKund.Connection = sqlConnection;
            SqlParameter idParam = CreateIntParam("@KID", kundID);
            deleteKund.Parameters.Add(idParam);
            int rowEffected;

            try
            {
                sqlConnection.Open();
                rowEffected = deleteKund.ExecuteNonQuery();

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
        //====================      REGISTRERING AV Artiklar      =================================
        //=========================================================================================
        //=========================================================================================  
        #region

        //=========================================================================================
        //==========ARTIKEL REGISTRERING===========================================================
        public bool ArtikelRegistrering(/*int AID,*/ string artikelnamn, int pris, string kategori)
        {
            SqlCommand sqlCommand = new SqlCommand(); //Skapa alltid i varje ny metod
            sqlCommand.CommandText = "RegisterArtikel";
            sqlCommand.CommandType = CommandType.StoredProcedure; //Sparat i Managment studio
            sqlCommand.Connection = sqlConnection;

            //sqlCommand.Parameters.Add(CreateIntParam("@AID", AID));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@artikelNamn", artikelnamn));
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
            sqlCommandArt.CommandText = "select * from Artiklar";
            sqlCommandArt.CommandType = CommandType.Text; //Sparat i Managment studio
            sqlCommandArt.Connection = sqlConnection;

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommandArt.ExecuteReader();

                while (reader.Read())
                {
                    Artiklar artikel = new Artiklar();
                    artikel.AID = (int)reader["ArtikelId"];
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

        public bool UpdateArtikel(int AID, string artikelnamn, int pris, string kategori)
        {
            SqlCommand sqlCommand = new SqlCommand(); //Skapa alltid i varje ny metod
            sqlCommand.CommandText = "UpdateArtikel";
            sqlCommand.CommandType = CommandType.StoredProcedure; //Sparat i Managment studio
            sqlCommand.Connection = sqlConnection;


            sqlCommand.Parameters.Add(CreateIntParam("@AID", AID));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@artikelNamn", artikelnamn));
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

        public bool TaBortArtiklar(int AID)
        {
            SqlCommand deleteArtikel = new SqlCommand(); //Skapa alltid i varje ny metod
            deleteArtikel.CommandText = "DeleteArtikel";
            deleteArtikel.CommandType = CommandType.StoredProcedure; //Sparat i Managment studio
            deleteArtikel.Connection = sqlConnection;
            SqlParameter idParam = CreateIntParam("@AID", AID);
            deleteArtikel.Parameters.Add(idParam);
            int rowEffected;

            try
            {
                sqlConnection.Open();
                rowEffected = deleteArtikel.ExecuteNonQuery();

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
        //====================      REGISTRERING AV ORDRAR      ===================================
        //=========================================================================================
        //========================================================================================= 
        //NEEDS TO BE MORE MODIFIED!!!!
        #region

        //=========================================================================================
        //==========ORDER AVLÄSNING================================================================

        public bool OrderRegistrering(int OID, int KID, int VID)
        {
            SqlCommand sqlCommand = new SqlCommand(); //Skapa alltid i varje ny metod
            sqlCommand.CommandText = "Order";
            sqlCommand.CommandType = CommandType.StoredProcedure; //Sparat i Managment studio
            sqlCommand.Connection = sqlConnection;


            sqlCommand.Parameters.Add(CreateIntParam("@OrderID", OID));
            sqlCommand.Parameters.Add(CreateIntParam("@KundID", KID));
            sqlCommand.Parameters.Add(CreateIntParam("@VarukorgID", VID));


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

        public List<Order> ReadAllOrders()
        {
            List<Order> Ordrar = new List<Order>();
            SqlCommand sqlCommandArt = new SqlCommand(); //Skapa alltid i varje ny metod
            sqlCommandArt.CommandText = "select * from Artiklar";
            sqlCommandArt.CommandType = CommandType.Text; //Sparat i Managment studio
            sqlCommandArt.Connection = sqlConnection;

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommandArt.ExecuteReader();

                while (reader.Read())
                {
                    Order order = new Order();
                    order.OID = (int)reader["OrderID"];
                    order.KID = (int)reader["KundID"];
                    order.VID = (int)reader["VarukorgID"];

                    Ordrar.Add(order);
                }

            }
            catch
            {
                Ordrar = null;
            }
            finally
            {
                sqlConnection.Close();
            }
            return Ordrar;
        }

        //=========================================================================================
        //==========ARTIKEL RADERING===============================================================

        public bool TaBortOrder(int OID)
        {
            SqlCommand Ordrar = new SqlCommand(); //Skapa alltid i varje ny metod
            Ordrar.CommandText = "OrderDelete";
            Ordrar.CommandType = CommandType.StoredProcedure; //Sparat i Managment studio
            Ordrar.Connection = sqlConnection;
            SqlParameter idParam = CreateIntParam("@OID", OID);
            Ordrar.Parameters.Add(idParam);
            int rowEffected;

            try
            {
                sqlConnection.Open();
                rowEffected = Ordrar.ExecuteNonQuery();

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



        #endregion
        //=========================================================================================
        //=========================================================================================
        //====================      HELPING METHODS      ==========================================
        //=========================================================================================
        //=========================================================================================
        #region
        //========CREATE VARCHARS =================================================================

        private SqlParameter CreateVarcharParameter(string parameterName, string value /*, int value*/)
        {
            SqlParameter Param = new SqlParameter();
            Param.Direction = ParameterDirection.Input;
            Param.ParameterName = parameterName;
            Param.SqlDbType = SqlDbType.VarChar;
            //Param.Size = size;
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
            //Param.Value = value;
            return Param;
        }

        //=========================================================================================
        //========CHECK USERNAME AND SSN ==========================================================

        private void NameAndSsnChecker(string nickName, string SSN, out SqlDataReader readerNick, out SqlDataReader readerSSN)
        {
            SqlCommand checkNameValidation = new SqlCommand("SELECT * FROM Kunder WHERE ([NickName] = @nick)", sqlConnection);
            checkNameValidation.Parameters.AddWithValue("@nick", nickName);
            readerNick = checkNameValidation.ExecuteReader();
            SqlCommand checkSSNValidation = new SqlCommand("SELECT * FROM Kunder WHERE ([SSN] = @ssn)", sqlConnection);
            checkSSNValidation.Parameters.AddWithValue("@ssn", SSN);
            readerSSN = checkSSNValidation.ExecuteReader();
        }

        #endregion




    }
}
