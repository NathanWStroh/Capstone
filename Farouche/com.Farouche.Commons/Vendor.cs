using System;

//Author: Andrew Willhoit
//Date Created: 1/31/2014
//Last Modified: 1/31/2014
//Last Modified By: Andrew


/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 02/07/2014  Andrew                       0.0.1b        Updated Vendor to use properties
* 1/31/2014   Adam                          0.0.1b        Updated Vendor to inherit Entity
*/
namespace com.Farouche.Commons
{
    public class Vendor : Entity
    {

        private string _address;
        private string _city;
        private string _state;
        private string _country;
        private string _zip;
        private string _phone;
        private string _contact;
        private string _contactEmail;

        public Vendor(string name, string address, string city, string state, string country, string zip, string phone, string contact, string contactEmail)
        {
            Name = name;
            _address = address;
            _city = city;
            _state = state;
            _country = country;
            _zip = zip;
            _phone = phone;
            _contact = contact;
            _contactEmail = contactEmail;
            Active = true;
        }

        public Vendor()
        {

        }

        public Vendor(int Id)
        {
            this.Id = Id;
        }

        public override string ToString()
        {
            return Id + " " + Name + " " + _address + " " + _city + " " + _state + " " + _country + " " + _zip + " " + _phone + " " + _contact + _contactEmail + " " + Active + " ";
        }

        public override string ToXml()
        {
            throw new NotImplementedException();
        }

        public override Type GetType()
        {
            throw new NotImplementedException();
        }


        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }

        public string ContactEmail
        {
            get { return _contactEmail; }
            set { _contactEmail = value; }
        }


    }
}
