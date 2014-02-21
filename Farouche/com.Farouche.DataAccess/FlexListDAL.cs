using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

//Author: Steven Schuette
//Date Created: 1/31/2014
//Last Modified: 1/31/2014
//Last Modified By: Steven Schuette

namespace com.Farouche.DataAccess
{

    public class Flexlist : DatabaseConnection
    {
        public readonly List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();
        public readonly string[] fields;

         public Flexlist(ref string myQuery)
        {
           
            SqlConnection myConnection = GetInventoryDbConnection();
            Dictionary<string, string> row = null;

            try
            {
                myConnection.Open();
                SqlCommand mySqlCommand = new SqlCommand(myQuery, myConnection);
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                //check to see if any rows were returned, if so, process them
          
                if (mySqlDataReader.HasRows)
                {
                    //get fieldcount for the result of this query
                    dynamic fieldCount = mySqlDataReader.FieldCount;
                    fields = new string[fieldCount];
                    mySqlDataReader.Read();
                    for (int i = 0; i <= fieldCount - 1; i++)
                    {
                        //add the current field name and value of current row
                        fields[i] = mySqlDataReader.GetName(i);
                       
                    }
                    do
                    {
                        row = new Dictionary<string, string>();
                        for (int i = 0; i <= fieldCount - 1; i++)
                        {
                            //add the current field name and value to the current row
                            row.Add(fields[i], (mySqlDataReader.IsDBNull(i) ? "NULL" : mySqlDataReader.GetValue(i).ToString()));
                           
                        }
                        rows.Add(row);
                        
                        row = null;
                    } while (mySqlDataReader.Read());
                }
                mySqlDataReader.Close();
            }
            catch (SqlException ex)
            {
               
                MessageBox.Show("Database server or Connection error. Please conntact your system administrator" + ex.ToString());
            }
            catch (DataException ex)
            {
                MessageBox.Show("There was an error returning data. Please report this error to the department head." + ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unknown exception occured. Try again and report the error if it persists" + ex.ToString());
            }
            finally
            {
                myConnection.Close();
            }


        }//end Public FlexList
    }//end Class
}
