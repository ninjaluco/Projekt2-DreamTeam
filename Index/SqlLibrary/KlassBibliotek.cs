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
        static string connString = @"";

        SqlConnection sqlConnection = new SqlConnection(connString);

 

        //==========KUND REGISTRERING==============================================================

            //Returning an INT. While something is wrong the int will be -1.
        public int KundRegistrering(string name, string nickName, string passWord, string telefon, 
            string eMail, string Street, string City, string Zip, string SSN)
        {
            SqlCommand sqlCommand = new SqlCommand(); //Skapa alltid i varje ny metod
            sqlCommand.CommandText = "KundRegistrering";
            sqlCommand.CommandType = CommandType.StoredProcedure; //Sparat i Managment studio
            sqlCommand.Connection = sqlConnection;

            sqlCommand.Parameters.Add(CreateVarcharParameter("@name", name));          
            sqlCommand.Parameters.Add(CreateVarcharParameter("@nickName", nickName));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@passWord", passWord));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@telefon", telefon));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@Email", eMail));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@Street", Street));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@City", City));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@Zip", Zip));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@ssn", SSN));
            
            SqlParameter idParam = new SqlParameter();
            idParam.Direction = ParameterDirection.Output;
            idParam.ParameterName = "@KundID";
            idParam.SqlDbType = SqlDbType.Int;
            sqlCommand.Parameters.Add(idParam);


            int newId;

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                newId = (int)sqlCommand.Parameters["@KundID"].Value;
            }
            catch
            {
                newId = -1;

            }
            finally
            {
                sqlConnection.Close();
            }

            return newId;
        }


        //=========================================================================================

        //==========KUND AVLÄSNING=================================================================

        public List<Kunder> ReadAllContacts()
        {
            List<Kunder> kunder = new List<Kunder>();
            SqlCommand sqlCommand = new SqlCommand(); //Skapa alltid i varje ny metod
            sqlCommand.CommandText = "select * from Contact";
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


        //========CREATE VARCHARS ========================================================

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

        //================================================================================


        //public  bool DeleteContact(int id)
        //{
        //    SqlCommand sqlCommand = new SqlCommand(); //Skapa alltid i varje ny metod
        //    sqlCommand.CommandText = "DeleteContact";
        //    sqlCommand.CommandType = CommandType.StoredProcedure; //Sparat i Managment studio
        //    sqlCommand.Connection = sqlConnection;
        //    SqlParameter idParam = CreateIntParam("@id", id);
        //    sqlCommand.Parameters.Add(idParam);
        //    int rowEffected;

        //    try
        //    {
        //        sqlConnection.Open();
        //        rowEffected = sqlCommand.ExecuteNonQuery();

        //    }
        //    catch
        //    {
        //        rowEffected = -1;

        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //    }
        //    return rowEffected > 0; //true or false is returning
        //}


        //private  SqlParameter CreateIntParam(string parameterName, int value)
        //{
        //    SqlParameter Param = new SqlParameter();
        //    Param.Direction = ParameterDirection.Input;
        //    Param.ParameterName = parameterName;
        //    Param.SqlDbType = SqlDbType.Int;
        //    Param.Value = value;
        //    return Param;
        //}



        //public bool UpdateContact(int cid, string firstname, string lastname, string ssn)
        //{
        //    SqlCommand sqlCommand = new SqlCommand(); //Skapa alltid i varje ny metod
        //    sqlCommand.CommandText = "UpdateContact";
        //    sqlCommand.CommandType = CommandType.StoredProcedure; //Sparat i Managment studio
        //    sqlCommand.Connection = sqlConnection;


        //    //update Contact set Firstname = @firstname, Lastname = @lastname where ID = @id
        //    SqlParameter idParam = CreateIntParam("@id", cid);
        //    sqlCommand.Parameters.Add(idParam);

        //    SqlParameter firstnameParam = CreateVarcharParameter("@firstname", firstname, 30);
        //    sqlCommand.Parameters.Add(firstnameParam);

        //    SqlParameter lastnameParam = CreateVarcharParameter("@lastname", lastname, 30);
        //    sqlCommand.Parameters.Add(lastnameParam);

        //    SqlParameter ssnParam = CreateVarcharParameter("@ssn", ssn, 13);
        //    sqlCommand.Parameters.Add(ssnParam);

        //    int rowEffected;

        //    try
        //    {
        //        sqlConnection.Open();
        //        rowEffected = sqlCommand.ExecuteNonQuery();

        //    }
        //    catch
        //    {
        //        rowEffected = -1;

        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //    }
        //    return rowEffected > 0; //true or false is returning
        //}




    }
}
