using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Farouche.Commons;
using com.Farouche.DataAccess;
using System.Data.SqlClient;

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

namespace com.Farouche.BusinessLogic
{
    public class RoleManager
    {
        public static List<Role> GetAllRoles()
        {
            return RoleDAL.GetRoles();
        }

        public static List<Role> GetRolesByActive(bool active)
        {
            return RoleDAL.GetRolesByActive(active);
        }

        public static bool AddRole(Role role)
        {
            return RoleDAL.Add(role);
        }

        public static bool DeactivateRole(Role role)
        {
            role.Active = false;
            return RoleDAL.UpdateActive(role);
        }

        public static bool ActivateRole(Role role)
        {
            role.Active = true;
            return RoleDAL.UpdateActive(role);
        }

        public static bool UpdateRole(Role updatedRole, Role originalRole)
        {
            if (originalRole.Id != null)
            {
                return RoleDAL.UpdateRole(updatedRole, originalRole);
            }
            else 
            {
                return false;
            }
        }

        public static List<RoleControl> GetControlsByRole(int roleID)
        {
            return RoleDAL.GetControlsForRole(roleID);
        }

        public static bool ProcessControls(List<RoleControl> _editingRoleControls)
        {
            bool success = true;
            foreach (RoleControl control in _editingRoleControls)
            {
                if (control.status == "NEW")
                {
                    if(!RoleDAL.AddControlToRole(control, control.RoleID)){ success = false; };
                }
                else if(control.status == "UPDATE")
                {
                    if (!RoleDAL.UpdateControl(control, control.RoleID)) { success = false; };
                }
            }
            return success;
        }
    }
}
