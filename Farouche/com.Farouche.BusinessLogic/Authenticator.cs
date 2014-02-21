using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Diagnostics;
using com.Farouche.Commmons;
using com.Farouche.DataAccess;

//Author: Steven Schuette
//Date Created: 1/31/2014
//Last Modified: 1/31/2014
//Last Modified By: Steven Schuette

namespace com.Farouche.BusinessLogic
{
    public class Authenticator
    {
        
        public static AccessToken authenticate(int userID, string password)
        {
            
            string query = "SELECT UserID, FirstName, LastName, [Roles].[RoleID], Title " +
                            "FROM Users, Roles " +
                            "WHERE [Users].[RoleID] = [Roles].[RoleID] " +
                            "AND [Users].[UserID] = " + userID + " " +
                            "AND [Users].[Password] = '" + password + "' " +
                            "AND [Users].[Active] = 1";
            
            Flexlist myFlexlist = default(Flexlist);
            AccessToken myAccessToken;
            string _UserID;
            string _RoleID;

            string _FirstName;
            string _LastName;
            string _Title;
            try
            {
                myFlexlist = new Flexlist(ref query);

                myFlexlist.rows[0].TryGetValue("UserID", out _UserID);
                myFlexlist.rows[0].TryGetValue("RoleID", out _RoleID);
                myFlexlist.rows[0].TryGetValue("FirstName", out _FirstName);
                myFlexlist.rows[0].TryGetValue("LastName", out _LastName);
                myFlexlist.rows[0].TryGetValue("Title", out _Title);
               
                myAccessToken = new AccessToken(int.Parse(_UserID), int.Parse(_RoleID), _FirstName, _LastName, _Title);
                if (myFlexlist.rows.Count == 0)
                {
                    ApplicationException up = new ApplicationException("User not found");
                    throw up;
                }
            }
            catch (Exception ex)
            {
                ApplicationException up = new ApplicationException("User has been marked inactive" + ex.ToString());
                throw up;
            }
            return myAccessToken;
        }
    }
}
