using System;

//Author: Andrew
//Date Created: 3/1/2014
//Last Modified: 2/2/2014 
//Last Modified By: Andrew Willhoit

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 
* 
*/

namespace com.Farouche.Commons
{
    class ShippingVendor : Entity
    {

        private string _address;
        private string _city;
        private string _country;
        private string _state;
        private string _zip;
        private string _phone;
        private string _contact;
        private string _contactEmail;

        public string Address
        {
            get 
            {
                return _address; 
            }
            set
            {
                _address = value; 
            }
        }
        public string City
        {
            get 
            { 
                return _city; 
            }
            set 
            {
                _city = value;
            }
        }
       public string  Country
        {
            get
            { 
                return _country; 
            }
            set
            { 
                _country = value;
            }
        }
        public string State
        {
            get 
            { 
                return _state;
            }
            set 
            {
                _state = value; 
            }
        }
        public string Zip
        {
            get 
            { 
                return _zip;
            }
            set
            {
                _zip = value; 
            }
        }
        public string Phone
        {
            get 
            {
                return _phone; 
            }
            set
            { 
                _phone = value;
            }
        }
      public string Contact
        {
            get 
            { 
                return _contact;
            }
            set 
            { 
                _contact = value; 
            }
        }
        public string ContactEmail
        {
            get 
            { 
                return _contactEmail;
            }
            set 
            {
                _contactEmail = value;
            }
        }
        public override string ToString()
        {
            return string.Format("ID: {0}, Name: {1}, Address, {2}, City: {3}, Country: {4}, State: {5}, Zip: {6}, Phone: {7}, Contact: {8}, ContactEmail: {9}", Id, Name, Address, City, Country, State, Zip, Phone, Contact, ContactEmail);
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
