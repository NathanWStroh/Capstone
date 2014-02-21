using System;
using System.Collections.Generic;
using System.Text;

//Author: Steven Schuette
//Date Created: 1/28/2014
//Last Modified: 1/30/2014
//Last Modified By: Steven Schuette

namespace com.Farouche.Commmons
{
    public class AccessToken
    {
        private int _UserID;
        private int _RoleID;
        private string _FirstName;
        private string _LastName;
        private string _Title;

        public int RoleID
        {
            get { return _RoleID; }
        }

        public int UserID
        {
            get { return _UserID; }
        }

        public string FirstName
        {
            get { return _FirstName; }
        }

        public string LastName
        {
            get { return _LastName; }
        }

        public string Title
        {
            get { return _Title; }
        }

        public AccessToken(int myUserID, int myRoleID, string myFirstName, string myLastName, string myTitle)
        {
            _UserID = myUserID;
            _RoleID = myRoleID;
            _FirstName = myFirstName;
            _LastName = myLastName;
            _Title = myTitle;
            
        }
    }
}
