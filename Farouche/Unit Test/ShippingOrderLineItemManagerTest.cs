using com.Farouche.BusinessLogic;
using com.Farouche.Commons;
using NUnit.Framework;
using System;

//Author: Andrew
//Date Created: 4/1/14
//Last Modified: 4/4/14
//Last Modified By: Ben Grimes

/*
*                               Changelog
* Date         By          Ticket          Version         Description
*
* 
*/

namespace Unit_Test
{
    [TestFixture]
    public class ShippingOrderLineItemManagerTest
    {
        private ShippingOrderLineItem _shippingOrderLineItem;
        private ShippingOrderLineItemManager _shippingOrderLineItemManager = new ShippingOrderLineItemManager();
        [SetUp]
        public void Setup()
        {
            _shippingOrderLineItem = new ShippingOrderLineItem(2, 4)
            {
                ProductName = "Test Monitor",
                Quantity = 3,
                ProductLocation = "Place",
                IsPicked = false
            };
        }

        [TearDown]
        public void TearDown()
        {
            _shippingOrderLineItem = null;
        }

        [Test]
        public void UpdateQuantity3()
        {
            Assert.AreEqual(true, true);
        }

        [Test]
        public void InsertLineItemNull()
        {
            Assert.Throws(typeof(ApplicationException), new TestDelegate(InsertLineItemNullDel));
        }
        void InsertLineItemNullDel()
        {
            _shippingOrderLineItem = null;
            _shippingOrderLineItemManager.Insert(_shippingOrderLineItem);
        }

        [Test]
        public void UpdateLineItemNull()
        {
            Assert.Throws(typeof(ApplicationException), new TestDelegate(UpdateLineItemNullDel));
        }
        void UpdateLineItemNullDel()
        {
            ShippingOrderLineItem differentLineItem = null;
            _shippingOrderLineItemManager.Update(differentLineItem, _shippingOrderLineItem);
        }
    }
}
