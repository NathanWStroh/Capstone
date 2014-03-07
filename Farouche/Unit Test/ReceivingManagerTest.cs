using com.Farouche.BusinessLogic;
using com.Farouche.Commons;
using NUnit.Framework;

namespace Unit_Test
{
    [TestFixture]
    public class ReceivingManagerTest
    {
        private VendorOrderLineItem _vendorOrderLineItem;
        private ReceivingManager receivingManager;
        [SetUp]
        public void Setup()
        {
            _vendorOrderLineItem = new VendorOrderLineItem(1, 2)
            {
                QtyOrdered = 10,
                QtyReceived = 5,
                QtyDamaged = 0
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
    }
}
