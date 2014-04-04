using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Farouche.Commons;

namespace com.Farouche.BusinessLogic
{
    public class ReorderManager
    {
        private List<Reorder> _reorders = new List<Reorder>();
        public List<Reorder> Reorders
        {
            get { return _reorders; }
        }

        public ReorderManager(List<Reorder> reorders)
        {
            _reorders = reorders;
        }

        public Boolean removeFromOrder(Reorder reorder)
        {
            return true;
        }
        // removeFromOrder(Reorder reorder)
            //Return boolean update list item

        public Boolean addToOrder(Reorder reorder)
        {
            return true;
        }
        // addToOrder(Reorder reorder)
            // return boolean update list item

        public Double updateReorderAmount(Reorder reorder, int amt)
        {
            return 25.5;
        }
        // updateReorderAmount(Reorder reorder, int amt)
            // return double total row

        public Double getReportTotal()
        {
            return 99.9;
        }
        // getReportTotal()
           // return total of all reorders

        public Boolean orderReorders()
        {
            return true;
        }
        // orderReorders()
            //return boolean

    }
}
