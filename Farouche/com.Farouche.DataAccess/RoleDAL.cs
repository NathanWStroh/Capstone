using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Farouche.Commons;
using System.Data.SqlClient;
using System.Data;

//Author: Adam Chandler
//Date Created: 04/25/14
//Last Modified: 05/1/14
//Last Modified By: Adam Chandler

/*
 *                               Changelog
 * Date         By          Ticket          Version         Description
 * 04/25/14    Adam                                         Created class
 * 
 *
*/

namespace com.Farouche.DataAccess
{
    public class RoleDAL : DatabaseConnection
    {
        public static List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>();
            SqlConnection conn = GetInventoryDbConnection();
            try
            {
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand("proc_GetRoles", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        var role = new Role(reader.GetInt32(0))
                        {
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Active = reader.GetBoolean(reader.GetOrdinal("Active")),
                        };
                        roles.Add(role);
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
            return roles; 
            #endregion
        }  // end GetRoles()

        public static List<Role> GetRolesByActive(Boolean active)
        {
            List<Role> roles = new List<Role>();
            SqlConnection conn = GetInventoryDbConnection();
            try
            {
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand("proc_GetRolesByActive", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Active", active ? 1 : 0);
                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        var role = new Role(reader.GetInt32(0))
                        {
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Active = reader.GetBoolean(reader.GetOrdinal("Active")),
                        };
                        roles.Add(role);
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
            return roles;
        }
       
        public static bool Add(Role role)
        {
            var connection = GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_InsertIntoRoles", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@Title", role.Name);
                mySqlCommand.Parameters.AddWithValue("@Description", role.Description);
                mySqlCommand.Parameters.AddWithValue("@Active", role.Active ? 1 : 0);

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

        public static bool UpdateActive(Role role)
        {
            var connection = GetInventoryDbConnection();

            try
            {
                 var mySqlCommand = new SqlCommand("proc_UpdateActiveRole", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@RoleID", role.Id);
                mySqlCommand.Parameters.AddWithValue("@Active", role.Active ? 1 : 0);


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

        public static bool UpdateRole(Role updatedRole, Role originalRole)
        {
            var connection = GetInventoryDbConnection();

            try
            {
                var mySqlCommand = new SqlCommand("proc_UpdateRole", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@RoleID", originalRole.Id);
                mySqlCommand.Parameters.AddWithValue("@Title", updatedRole.Name);
                mySqlCommand.Parameters.AddWithValue("@Description", updatedRole.Description);
                mySqlCommand.Parameters.AddWithValue("@Active", updatedRole.Active ? 1 : 0);
                mySqlCommand.Parameters.AddWithValue("@OriginalTitle", originalRole.Name);
                mySqlCommand.Parameters.AddWithValue("@OriginalDescription", originalRole.Description);
                mySqlCommand.Parameters.AddWithValue("@OriginalActive", originalRole.Active ? 1 : 0);


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

        public static bool AssignRole(CLSEmployee employee, Role role)
        {
            //TODO
            return false;
        }

        public static bool AddControlToRole(RoleControl control, int roleID)
        {
            var connection = GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_InsertControlForRole", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@RoleID", roleID);
                mySqlCommand.Parameters.AddWithValue("@Form", control.FormName);
                mySqlCommand.Parameters.AddWithValue("@Control", control.Name);
                mySqlCommand.Parameters.AddWithValue("@Visible", control.Visible ? 1 : 0);
                mySqlCommand.Parameters.AddWithValue("@Disabled", control.Disabled ? 1 : 0);
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

        public static List<RoleControl> GetControlsForRole(int roleID)
        {
            List<RoleControl> roleControls = new List<RoleControl>();
            SqlConnection conn = GetInventoryDbConnection();
            try
            {
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand("proc_GetControlsForRole", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@RoleID", roleID);
                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        var roleControl = new RoleControl()
                        {
                            RoleID = reader.GetInt32(reader.GetOrdinal("RoleID")),
                            FormName = reader.GetString(reader.GetOrdinal("Form")),
                            Name = reader.GetString(reader.GetOrdinal("Control")),
                            Visible = reader.GetBoolean(reader.GetOrdinal("Visible")),
                            Disabled= reader.GetBoolean(reader.GetOrdinal("Disabled")),
                        };
                        roleControls.Add(roleControl);
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
            return roleControls;
        }

        public static bool UpdateControl(RoleControl control, int roleID)
        {
            var connection = GetInventoryDbConnection();

            try
            {
                var mySqlCommand = new SqlCommand("proc_UpdateControlForRole", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@RoleID", roleID);
                mySqlCommand.Parameters.AddWithValue("@Form", control.FormName);
                mySqlCommand.Parameters.AddWithValue("@Control", control.Name);
                mySqlCommand.Parameters.AddWithValue("@Visible", control.Visible ? 1 : 0);
                mySqlCommand.Parameters.AddWithValue("@Disabled", control.Disabled ? 1 : 0);
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
