using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Farouche.Commons;
using System.Data.SqlClient;
using System.Data;

namespace com.Farouche.DataAccess
{
    public class EmployeeDAL : DatabaseConnection
    {


        public static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            SqlConnection conn = GetInventoryDbConnection();
            try
            {
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand("proc_GetEmployees", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        var employee = new Employee(reader.GetInt32(reader.GetOrdinal("UserID")))
                        {
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                            RoleID = reader.GetInt32(reader.GetOrdinal("RoleID")),
                            Active = reader.GetBoolean(reader.GetOrdinal("Active"))
                        };
                        employees.Add(employee);
                    }
                }
                reader.Close();
            }
            #region Exceptions
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
            return employees;
            #endregion
        }
        
        public static Boolean Add(Employee employee,String password)
        {
            var connection = GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_InsertIntoUsers", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@RoleID", employee.RoleID);
                mySqlCommand.Parameters.AddWithValue("@FirstName", employee.FirstName);
                mySqlCommand.Parameters.AddWithValue("@LastName", employee.LastName);
                mySqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                mySqlCommand.Parameters.AddWithValue("@Password", password);
                mySqlCommand.Parameters.AddWithValue("@Active", employee.Active ? 1 : 0);

                connection.Open();
                if (mySqlCommand.ExecuteNonQuery() == 1)
                {
                    return true;
                }
            }
            #region Exceptions
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
                connection.Close();
            } 
            #endregion
            return false;
    
        }
        public static Boolean Update(Employee old, Employee edited)
        {
            var connection = GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_UpdateUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@RoleID", edited.RoleID);
                mySqlCommand.Parameters.AddWithValue("@FirstName", edited.FirstName);
                mySqlCommand.Parameters.AddWithValue("@LastName", edited.LastName);
                mySqlCommand.Parameters.AddWithValue("@PhoneNumber", edited.PhoneNumber);
                mySqlCommand.Parameters.AddWithValue("@Active", edited.Active ? 1 : 0);
                mySqlCommand.Parameters.AddWithValue("@Orig_RoleID", old.RoleID);
                mySqlCommand.Parameters.AddWithValue("@Orig_FirstName", old.FirstName);
                mySqlCommand.Parameters.AddWithValue("@Orig_LastName", old.LastName);
                mySqlCommand.Parameters.AddWithValue("@Orig_PhoneNumber", old.PhoneNumber);
                mySqlCommand.Parameters.AddWithValue("@Orig_Active", old.Active ? 1 : 0);

                connection.Open();
                if (mySqlCommand.ExecuteNonQuery() == 1)
                {
                    return true;
                }
            }
            #region Exceptions
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
                connection.Close();
            }
            #endregion
            return false;
        }

        public static List<Employee> GetEmployeesByActive(Boolean active)
        {
            List<Employee> employees = new List<Employee>();
            SqlConnection conn = GetInventoryDbConnection();
            try
            {
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand("proc_GetEmployeesByActive", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Active", active ? 1 : 0);
                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        var employee = new Employee(reader.GetInt32(reader.GetOrdinal("UserID")))
                        {

                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                            RoleID = reader.GetInt32(reader.GetOrdinal("RoleID")),
                            Active = reader.GetBoolean(reader.GetOrdinal("Active"))
                        };
                        employees.Add(employee);
                    }
                }
                reader.Close();
            }
            #region Exceptions
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
            #endregion
            return employees;
        }

        public static Boolean SetActive(bool active, Employee employee)
        {
            var connection = GetInventoryDbConnection();

            try
            {
                var mySqlCommand = new SqlCommand("proc_UpdateActiveEmployee", connection)
               {
                   CommandType = CommandType.StoredProcedure
               };
                mySqlCommand.Parameters.AddWithValue("@UserID", employee.Id);
                mySqlCommand.Parameters.AddWithValue("@Active", active ? 1 : 0);


                connection.Open();
                if (mySqlCommand.ExecuteNonQuery() == 1)
                {
                    return true;
                }
            }
            #region Exceptions
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
                connection.Close();
            }
            #endregion
            return false;
        }
    }
}
