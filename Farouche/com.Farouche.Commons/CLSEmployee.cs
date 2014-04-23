using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.Farouche.Commons
{
    public class CLSEmployee : Entity
    {
        private int _roleID;
        private string _title;
        private string _firstName;
        private string _lastName;

        public CLSEmployee(int userID, int roleID, string title, string firstName, string lastName)
        {
            Id = userID;
            _roleID = roleID;
            _title = title;
            _firstName = firstName;
            _lastName = lastName;
        }

        public CLSEmployee()
        {
            Id = 0;
            _roleID = 0;
            _title = "";
            _firstName = "";
            _lastName = "";
        }

        public CLSEmployee(int userID)
        {
            Id = userID;
        }

        public int roleID
        {
            get
            {
                return _roleID;
            }
            set
            {
                _roleID = value;
            }
        }

        public string title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        public string firstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        public string lastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("UserId: {0}, RoleId: {1}, Title: {2}, FirstName: {3}, LastName: {4}", Id, roleID, title, firstName, lastName);
        }
        public override Type GetType()
        {
            throw new NotImplementedException();
        }
        public override string ToXml()
        {
            throw new NotImplementedException();
        }
    }
}
