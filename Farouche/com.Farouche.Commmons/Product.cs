using System;

/*Author: Caleb
*Date Created: 1/31/2014
*Last Modified: 02/07/2014 
*Last Modified By: Adam Chandler
*/


/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 02/07/2014   Adam                          0.0.1b        Updated Product to inherit Entity
*/
namespace com.Farouche.Commmons
{
    public class Product : Entity
    {
        //Private data members used for the product data structure.
        private int _reserved;
        private int _available;
        private string _description;
        private string _location;
        private Decimal _unitPrice;
        public double _shippingWeight  { get; set; }
        public string _shippingDemensions { get; set; }
        public int _reorderThreshold { get; set; }
        public int _reorderAmount { get; set; }
        //private string _shortDescription;

        //Constructor used to set the values of the private data members when the values are passed.
        public Product(int reserved, int available, string description, string location, decimal unitPrice, string shortDescription, Boolean active)
        {
            _reserved = reserved;
            _available = available;
            _description = description;
            _location = location;
            _unitPrice = unitPrice;
            //_shortDescription = shortDescription;
            Name = shortDescription;
            //_active = active;
            Active = active;
        }

        //Default constructor used to set the private data members to defaults.
        public Product()
        {
            _reserved = 0;
            _available = 0;
            _description = "";
            _location = "None";
            _unitPrice = 0;
            //_shortDescription = "";
            Name = "";
            //_active = false;
            Active = false;
        }

        public Product(int id)
        {
            
            Id = id;
        }
        public int reserved
        {
            get
            {
                return _reserved;
            }
            set
            {
                _reserved = value;
            }
        }
        public int available
        {
            get
            {
                return _available;
            }
            set
            {
                _available = value;
            }
        }
        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public string location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
        public Decimal unitPrice
        {
            get
            {
                return _unitPrice;
            }
            set
            {
                _unitPrice = value;
            }
        }
        public string ShortDescription
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }
        public override string ToString()
        {
            return string.Format("Product ID: {0} , \nOn Hand: {1}\nAvailable: {2}\nDescription{3}\nLocation ID: {4}\nUnit Price: {5}\nShort Description: {6}\nActive: {7}", Id, reserved, available, description, location, unitPrice, Name, Active);
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
