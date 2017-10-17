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
        static string connString = @"Data Source=.;Initial Catalog=Yoda;Integrated Security=True";

        public  int AddContact(string firstname, string lastname, string ssn)
        {
            SqlCommand sqlCommand = new SqlCommand(); //Skapa alltid i varje ny metod
            sqlCommand.CommandText = "AddContact";
            sqlCommand.CommandType = CommandType.StoredProcedure; //Sparat i Managment studio
            sqlCommand.Connection = sqlConnection;

            SqlParameter firstNameParam = CreateVarcharParameter("@firstname", firstname, 32);
            sqlCommand.Parameters.Add(firstNameParam);
            //På samma sätt kan vi göra detta med färre rader och mindre kod 
            sqlCommand.Parameters.Add(CreateVarcharParameter("@lastname", lastname, 32));
            sqlCommand.Parameters.Add(CreateVarcharParameter("@ssn", ssn, 13));

            SqlParameter idParam = new SqlParameter();
            idParam.Direction = ParameterDirection.Output;
            idParam.ParameterName = "@id";
            idParam.SqlDbType = SqlDbType.Int;
            sqlCommand.Parameters.Add(idParam);


            int newId;
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                newId = (int)sqlCommand.Parameters["@id"].Value;
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

        private  SqlParameter CreateVarcharParameter(string parameterName, string value, int size)
        {
            SqlParameter Param = new SqlParameter();
            Param.Direction = ParameterDirection.Input;
            Param.ParameterName = parameterName;
            Param.SqlDbType = SqlDbType.VarChar;
            Param.Size = size;
            Param.Value = value;
            return Param;
        }


         SqlConnection sqlConnection = new SqlConnection(connString);


        public  List<Contact> ReadAllContacts()
        {
            List<Contact> contacts = new List<Contact>();
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
                    Contact contact = new Contact();
                    contact.ID = (int)reader["ID"]; //(int) Called a Casting
                    contact.Firstname = (string)reader["Firstname"];
                    contact.Lastname = (string)reader["Lastname"];
                    contact.SSN = (string)reader["SSN"];

                    contacts.Add(contact);
                }


            }
            catch
            {
                contacts = null;
            }
            finally
            {
                sqlConnection.Close();
            }
            return contacts; //true or false is returning
        }

        public  bool DeleteContact(int id)
        {
            SqlCommand sqlCommand = new SqlCommand(); //Skapa alltid i varje ny metod
            sqlCommand.CommandText = "DeleteContact";
            sqlCommand.CommandType = CommandType.StoredProcedure; //Sparat i Managment studio
            sqlCommand.Connection = sqlConnection;
            SqlParameter idParam = CreateIntParam("@id", id);
            sqlCommand.Parameters.Add(idParam);
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


        private  SqlParameter CreateIntParam(string parameterName, int value)
        {
            SqlParameter Param = new SqlParameter();
            Param.Direction = ParameterDirection.Input;
            Param.ParameterName = parameterName;
            Param.SqlDbType = SqlDbType.Int;
            Param.Value = value;
            return Param;
        }



        public bool UpdateContact(int cid, string firstname, string lastname, string ssn)
        {
            SqlCommand sqlCommand = new SqlCommand(); //Skapa alltid i varje ny metod
            sqlCommand.CommandText = "UpdateContact";
            sqlCommand.CommandType = CommandType.StoredProcedure; //Sparat i Managment studio
            sqlCommand.Connection = sqlConnection;
           

            //update Contact set Firstname = @firstname, Lastname = @lastname where ID = @id
            SqlParameter idParam = CreateIntParam("@id", cid);
            sqlCommand.Parameters.Add(idParam);

            SqlParameter firstnameParam = CreateVarcharParameter("@firstname", firstname, 30);
            sqlCommand.Parameters.Add(firstnameParam);

            SqlParameter lastnameParam = CreateVarcharParameter("@lastname", lastname, 30);
            sqlCommand.Parameters.Add(lastnameParam);

            SqlParameter ssnParam = CreateVarcharParameter("@ssn", ssn, 13);
            sqlCommand.Parameters.Add(ssnParam);

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

       


    }
}
