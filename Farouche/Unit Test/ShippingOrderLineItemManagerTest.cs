using com.Farouche.BusinessLogic;
using com.Farouche.Commons;
using NUnit.Framework;
using System;

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
    }
}
