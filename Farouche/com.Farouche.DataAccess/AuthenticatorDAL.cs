using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Farouche.Commons;
using System.Data.SqlClient;
using System.Data;

namespace com.Farouche.DataAccess
{
    public class AuthenticatorDAL : DatabaseConnection
    {

        public static AccessToken Authenticate(int userID, string password)
        {
            SqlConnection conn = GetInventoryDbConnection();
            AccessToken _token = null;
            try
            {
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand("proc_Authenticate", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    
                    if(reader.Read())
                    {
                        _token = new AccessToken((int)reader["UserID"]){
                            Role = new Role((int)reader["RoleID"]){Name = (String)reader["Title"], Description = (String)reader["Description"]},
                            FirstName = (String) reader["FirstName"],
                            LastName = (String) reader["LastName"]
                        };
                    }
                    reader.NextResult();
                    var controls = new List<RoleControl>();
                    while(reader.Read())
                    {
                        var control = new RoleControl()
                            {
                                RoleID = (int)reader["RoleID"],
                                FormName = (String)reader["Form"],
                                Name = (String)reader["Control"],
                                Visible = (Boolean)reader["Visible"],
                                Disabled = (Boolean)reader["Disabled"]
                            };
                        controls.Add(control);
                    }
                    _token.Role.Controls = controls;
                    return _token;
                }
                reader.Close();
            }
            catch (DataException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("DatabaseException"), ex);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("SqlException"), ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("Exception"), ex);
            }
            finally
            {
                conn.Close();
            }
            return _token;
        }
    }
}
