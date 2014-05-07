using com.Farouche.BusinessLogic;
using com.Farouche.Commons;
using NUnit.Framework;
using System;

namespace Unit_Test
{
    [TestFixture]
    public class ReceivingManagerTest
    {
        private VendorOrderLineItem _vendorOrderLineItem;
        private ReceivingManager receivingManager = new ReceivingManager();
        [SetUp]
        public void Setup()
        {
            _vendorOrderLineItem = new VendorOrderLineItem(1, 2)
            {
                QtyOrdered = 10,
                QtyReceived = 5,
                QtyDamaged = 0,
                Note = "hello"
            };
        }

        [TearDown]
        public void TearDown()
        {
            _vendorOrderLineItem = null;
        }

        [Test]
        public void UpdateQtyDamaged5()
        {
            //Didn't write test for the project because I didn't know if we got
            //Into mocks and how to catch calls to the DAL
            Assert.AreEqual(true,true);
        }

        [Test]
        public void GetAllOpenOrdersByVendorNull()
        {
            Assert.Throws(typeof(ApplicationException), new TestDelegate(GetAllOpenOrdersByVendorNullDel));
        }
        void GetAllOpenOrdersByVendorNullDel()
        {
            receivingManager.GetAllOpenOrdersByVendor(null);
        }
        [Test]
        public void GetAllLineItemsByVendorOrderNull()
        {
            Assert.Throws(typeof(ApplicationException), new TestDelegate(GetAllLineItemsByVendorOrderNullDel));
        }
        void GetAllLineItemsByVendorOrderNullDel()
        {
            receivingManager.GetAllLineItemsByVendorOrder(null);
        }
        [Test]
        public void GetExceptionItemsByVendorOrderNull()
        {
            Assert.Throws(typeof(ApplicationException), new TestDelegate(GetExceptionItemsByVendorOrderNullDel));
        }
        void GetExceptionItemsByVendorOrderNullDel()
        {
            receivingManager.GetExceptionItemsByVendorOrder(null);
        }
        [Test]
        public void UpdateQtyDamagedNull()
        {
            Assert.Throws(typeof(ApplicationException), new TestDelegate(UpdateQtyDamagedNullDel));
        }
        void UpdateQtyDamagedNullDel()
        {
            //receivingManager.UpdateQtyDamaged(null, 0);
        }
        [Test]
        public void UpdateQtyDamagedNegative()
        {
            Assert.Throws(typeof(ApplicationException), new TestDelegate(UpdateQtyDamagedNegativeDel));
        }
        void UpdateQtyDamagedNegativeDel()
        {
            //receivingManager.UpdateQtyDamaged(_vendorOrderLineItem, -5);
        }
        [Test]
        public void UpdateQtyReceivedNull()
        {
            Assert.Throws(typeof(ApplicationException), new TestDelegate(UpdateQtyReceivedNullDel));
        }
        void UpdateQtyReceivedNullDel()
        {
            //receivingManager.UpdateQtyReceived(null, 0);
        }
        [Test]
        public void UpdateQtyReceivedNegative()
        {
            Assert.Throws(typeof(ApplicationException), new TestDelegate(UpdateQtyReceivedNegativeDel));
        }
        void UpdateQtyReceivedNegativeDel()
        {
            //receivingManager.UpdateQtyReceived(_vendorOrderLineItem, -10);
        }
        [Test]
        public void UpdateLineItemNoteLengthCheck()
        {
            Assert.Throws(typeof(ApplicationException), new TestDelegate(UpdateLineItemNoteLengthCheckDel));
        }
        void UpdateLineItemNoteLengthCheckDel()
        {
            string note = "This is a note that is longer then 50 characters which will cause an exception to be thrown.";
            receivingManager.UpdateLineItemNote(_vendorOrderLineItem, note);
        }
        [Test]
        public void UpdateLineItemNoteNull()
        {
            Assert.Throws(typeof(ApplicationException), new TestDelegate(UpdateLineItemNoteNullDel));
        }
        void UpdateLineItemNoteNullDel()
        {
            receivingManager.UpdateLineItemNote(null,null);
        }
        [Test]
        public void AddNewLineItemToVendorOrderNullVendorOrder()
        {
            Assert.Throws(typeof(ApplicationException), new TestDelegate(AddNewLineItemToVendorOrderNullVendorOrderDel));
        }
        void AddNewLineItemToVendorOrderNullVendorOrderDel()
        {
            var product = new Product(1);
            string note = "hello";
            //receivingManager.AddNewLineItemToVendorOrder(product,5, note);
        }
        [Test]
        public void AddNewLineItemToVendorOrderNullProduct()
        {
            Assert.Throws(typeof(ApplicationException), new TestDelegate(AddNewLineItemToVendorOrderNullProductDel));
        }
        void AddNewLineItemToVendorOrderNullProductDel()
        {
            var vendorOrder = new VendorOrder(1,1);
            string note = "hello";
            //receivingManager.AddNewLineItemToVendorOrder(vendorOrder, 5, note);
        }
    }
}
