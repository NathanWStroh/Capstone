using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Farouche.Commons;
using com.Farouche.DataAccess;

namespace com.Farouche.BusinessLogic
{
    public class ReorderManager
    {
        private List<Reorder> _reorders = new List<Reorder>();
        private VendorOrderManager _voMangaer = new VendorOrderManager();
        public List<Reorder> Reorders
        {
            get { return _reorders; }
        } 

        public List<Reorder> GetReordersForVendor(int vendorId, int reorderActive)
        {
            if (vendorId == null)
            {
                throw new ArgumentNullException("VendorID cannot be empty");
            }
            return ReportDAL.GetReorderReportData(vendorId, reorderActive);
        }

        public ReorderManager(List<Reorder> reorders)
        {
            _reorders = reorders;
        }

        public Boolean RemoveFromOrder(Reorder reorder)
        {
            return UpdateOrderList(reorder, true);
        }

        public Boolean AddNewLineItem(Product product, VendorSourceItem vendorSrcItem, int caseAmt)
        {
            if (product == null) throw new ArgumentNullException("Product is null");
            if (vendorSrcItem == null) throw new ArgumentNullException("VendorSourceItem is null");
            Reorder addOrder = new Reorder();
            addOrder.Product = product;
            addOrder.VendorSourceItem = vendorSrcItem;
            addOrder.ShouldReorder = true;
            addOrder.CasesToOrder = caseAmt;
            addOrder.ReorderTotal = GetReorderRowTotal(addOrder);
            return true;
            //throw new NotImplementedException();
        }
        public Boolean AddToOrder(Reorder reorder)
        {
            _reorders.Add(reorder);
            return UpdateOrderList(reorder, false);
        }
        private Boolean UpdateOrderList(Reorder reorder, Boolean remove)
        {
            reorder.ShouldReorder = !remove;
            return UpdateOrderInCollection(reorder);
        } //end UpdateOrderList(..)

        public Reorder GetProductToReorder(string productName)
        {
            if (productName == null)
            {
                throw new ArgumentNullException("Must Select a Product");
            }
            return ReportDAL.GetProductToReorder(productName);
        }
        public Double UpdateReorderAmount(Reorder reorder, int amt)
        {
            reorder.CasesToOrder = amt;
            if (UpdateOrderInCollection(reorder))
            {
                return GetReorderRowTotal(reorder);
            }
            else 
            {
                throw new ApplicationException("Never should happen, Houston We Have A Problem");
            } 
        } //end UpdateReorderAmount(..)

        public Double GetReportTotal()
        {
            double totalReorderCost = 0;
            foreach (var reorderI in _reorders)
            {
                if (reorderI.ShouldReorder)
                {
                    totalReorderCost = totalReorderCost + GetReorderRowTotal(reorderI);
                }
            }
            return totalReorderCost;
        } // end GetReportTotal()

        public Boolean OrderReorders()
        {
            VendorOrder order = new VendorOrder(_reorders[0].VendorSourceItem.VendorID);
            foreach (var reorder in _reorders)
            {
                if (reorder.ShouldReorder == true && reorder.CasesToOrder > 0)
                {
                    order.AddLineItem(new VendorOrderLineItem(reorder.Product.Id, (reorder.CasesToOrder * reorder.VendorSourceItem.ItemsPerCase), 0, 0));
                }
            }
            return _voMangaer.AddVendorOrder(order);
        } // end OrderReorders()

        private Boolean UpdateOrderInCollection(Reorder reorder)
        {
            if (reorder == null)
            {
                throw new ArgumentNullException("Reorder item cannot be null");
            }
            if (_reorders.Count == 0) 
            { 
                throw new ApplicationException("There are no reorder objects in the collection"); 
            }
            //if (!_reorders.Contains(reorder))
            //{
            //    throw new ApplicationException("No reorder found in reorders collection");
            //}
            foreach (var reorderI in _reorders)
	            {
		            if (reorderI == reorder)
                    {
                        reorderI.CasesToOrder = reorder.CasesToOrder;
                        reorderI.ShouldReorder = reorder.ShouldReorder;
                        //reorderI.Product = reorder.Product;
                        reorderI.VendorSourceItem = reorder.VendorSourceItem;
                      
                        return true;
                    }   
                }
            return false;
        } //end UpdateOrderInCollection(.)

        private Double GetReorderRowTotal(Reorder reorder)
        {
            try
            {
                return (Double)(reorder.CasesToOrder * reorder.VendorSourceItem.UnitCost * reorder.VendorSourceItem.ItemsPerCase);
            }
            catch(Exception ex)
            {
                throw new ArithmeticException("Calculating row total threw an exception." + ex.Message);
            }
        } //end GetReorderRowTotal(.)
    }
}
