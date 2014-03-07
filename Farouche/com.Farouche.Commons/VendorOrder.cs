using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.Farouche.Commons
{
    public class VendorOrder : Entity
    {
        public VendorOrder(int vendorId, int productId)
        {
            this.ProductID = productId;
            this.VendorID = vendorId;
        }
        public int ProductID;
        public int VendorID;

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override string ToXml()
        {
            throw new NotImplementedException();
        }

        public override Type GetType()
        {
            throw new NotImplementedException();
        }
    }
}
