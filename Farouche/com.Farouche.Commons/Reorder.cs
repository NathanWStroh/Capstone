using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Author: 
//Date Created: 3/28/14
//Last Modified: 3/28/14
//Last Modified By: 

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 
* 
*                                                         
*/


namespace com.Farouche.Commons
{
    public class Reorder
    {
        private Product _product;
        private VendorSourceItem _vendorSourceItem;

        public Product Product
        {
            get { return Product; }
            set { Product = value; }
        }

        public VendorSourceItem VendorSourceItem 
        {
            get { return VendorSourceItem; }
            set {VendorSourceItem = value; }
        }
        
    }
}
