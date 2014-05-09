using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.Farouche.Commons
{
    public class Employee : Entity
    {
        private int _roleID;
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;

        public Employee(int id)
        {
            this.Id = id;
        }

        public int RoleID
        {
            get { return _roleID; }
            set { _roleID = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get{ return _lastName; }
            set{ _lastName = value; }
        }

        public string PhoneNumber
        {
            get{ return _phoneNumber; }
            set{ _phoneNumber = value; }
        }
        public override Type GetType()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override string ToXml()
        {
            throw new NotImplementedException();
        }
    }
}
