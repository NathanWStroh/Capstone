using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Farouche.Commons;
using com.Farouche.DataAccess;
using System.Data.SqlClient;

//Author: Kaleb W
//Date Created: 3/5/2014
//Last Modified: 3/5/2014
//Last Modified By: Kaleb W

/*
 *                               Changelog
 * Date         By          Ticket          Version         Description
 * Kaleb                                                    Adjusted class to handle activating/deactivating/deleting shipping terms.
*/

namespace com.Farouche.BusinessLogic
{
    public class ShippingTermManager : DatabaseConnection
    {
        //Cretates a new connection.
        private readonly SqlConnection _connection = GetInventoryDbConnection();
        //Private member used to store the list of terms.
        private List<ShippingTerm> _shippingTerms = null;
        //Private member used to store a single term.
        private ShippingTerm _shippingTerm = null;

        //Used to retrieve list of terms.
        public List<ShippingTerm> ShippingTerms
        {
            get
            {
                return _shippingTerms;
            }
            set
            {
                _shippingTerms = value;
            }
        }//End of ShippingTerms sets/gets.

        //Used to retrieve list of terms.
        public ShippingTerm ShippingTerm
        {
            get
            {
                return _shippingTerm;
            }
            set
            {
                _shippingTerm = value;
            }
        }//End of ShippingTerm sets/gets.

        public bool Insert(ShippingTerm term)
        {
            //Need to do error checking. 
            return ShippingTermDAL.AddShippingTerm(term, _connection);
        }//End of Insert(.)

        public bool Update(ShippingTerm term, ShippingTerm originalTerm)
        {
            //Need to do error checking.
            return ShippingTermDAL.UpdateShippingTerms(term, originalTerm, _connection);
        }//End of Update(..)

        public ShippingTerm GetTermById(int termId)
        {
            //Need to do error checking.
            ShippingTerm = ShippingTermDAL.GetShippingTermsById(termId, _connection);
            return ShippingTerm;
        }//End of GetTermById(.)

        public List<ShippingTerm> GetTerms()
        {
            //Need to do error checking.
            ShippingTerms = ShippingTermDAL.GetAllShippingTerms(_connection);
            return ShippingTerms;
        }//End of GetTerms()

        public List<ShippingTerm> GetShippingTermsByActive(Boolean activeState)
        {
            ShippingTerms = ShippingTermDAL.FetchTermsByActive(activeState, _connection);
            return ShippingTerms;
        }

        public Boolean ReactivateTerm(ShippingTerm shippingTerm)
        {
            if (shippingTerm == null) throw new ArgumentException("The shipping term was null, therefore it cannot be set to active.");
            return ShippingTermDAL.ReactivateTerm(shippingTerm, _connection);
        }

        public Boolean DeactivateTerm(ShippingTerm shippingTerm)
        {
            if (shippingTerm == null) throw new ArgumentException("The shipping term was null, therefore it cannot be set to inactive.");
            return ShippingTermDAL.DeactivateTerm(shippingTerm, _connection);
        }

        public Boolean DeleteTerm(ShippingTerm shippingTerm)
        {
            if (shippingTerm == null) throw new ArgumentException("The shipping term was null, therefore it cannot be deleted.");
            return ShippingTermDAL.DeleteTerm(shippingTerm, _connection);
        }
    }//End of class.
}//End of namespace.
