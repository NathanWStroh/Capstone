using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using com.Farouche.Commons;
using System.Text;


//Author: Andrew
//Date Created: 3/30/14
//Last Modified: 3/31/14 
//Last Modified By: Andrew Willhoit

/*
*                               Changelog
* Date         By          Ticket          Version         Description
*
* 
*/


namespace Unit_Test
{

    [TestFixture]
    public class ValidationTest
    {
        private Validation validation = new Validation();

        [SetUp]
        public void Setup()
        {

        }

        [TearDown]

        //IsNullOrEmpty(String test)
        [Test]
        public void IsNullOrEmptySendStringTest()
        {
            Assert.IsFalse(validation.IsNullOrEmpty("howdy"));
        }
        [Test]
        public void IsNullOrEmptySendOpenSpaceTest()
        {
            Assert.IsFalse(validation.IsNullOrEmpty(" "));
        }
        [Test]
        public void IsNullOrEmptySendEmptyTest()
        {
            Assert.IsTrue(validation.IsNullOrEmpty(""));
        }
        [Test]
        public void IsNullOrEmptySendNullTest()
        {
            Assert.IsTrue(validation.IsNullOrEmpty(null));
        }

        //IsBlank(String test)
        [Test]
        public void IsBlankSendEmptyTest()
        {
            Assert.IsTrue(validation.IsBlank(""));
        }
        [Test]
        public void IsBlankSendBlankTest()
        {
            Assert.IsTrue(validation.IsBlank("     "));
        }
        [Test]
        public void IsBlankSendNullTest()
        {
            Assert.Throws(typeof(NullReferenceException), new TestDelegate(IsBlankSendNullTestDel));
        }
        void IsBlankSendNullTestDel()
        {
            validation.IsBlank(null);
        }


        //IsInt(String test)
        [Test]
        public void IsIntSendDoubleTest()
        {
            Assert.IsFalse(validation.IsInt("45.0"));
        }
        [Test]
        public void IsIntSendCharsTest()
        {
            Assert.IsFalse(validation.IsInt("howdy"));
        }
        [Test]
        public void IsIntSendIntTest()
        {
            Assert.IsTrue(validation.IsInt("12"));
        }

        //IsDouble(String test)
        [Test]
        public void IsDoubleSendIntTest()
        {
            Assert.IsTrue(validation.IsDouble("12"));
        }
        [Test]
        public void IsDoubleSendCharsTest()
        {
            Assert.IsFalse(validation.IsDouble("howdy"));
        }
        [Test]
        public void IsDoubleSendDoubleTest()
        {
            Assert.IsTrue(validation.IsDouble("25.8"));
        }

        //IsIntRange(int min,int max, int test)
        [Test]
        public void IsIntRangeSendWithinRangeTest()
        {
            Assert.IsTrue(validation.IsIntRange(1,10,3));
        }
        [Test]
        public void IsIntRangeSendOutOfRangeTest()
        {
            Assert.IsFalse(validation.IsIntRange(1, 10, 11));
        }
        [Test]
        public void IsIntRangeSendBackwardsArgumentsTest()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), new TestDelegate(IsIntRangeSendBackwardsArgumentsTestDel));
        }
        void IsIntRangeSendBackwardsArgumentsTestDel()
        {
            validation.IsIntRange(10,1,3);
        }

        //IsDoubleRange(double min, double max, double test)
        [Test]
        public void IsDoubleRangeSendWithinRangeTest()
        {
            Assert.IsTrue(validation.IsDoubleRange(1.5, 10.6, 3.2));
        }
        [Test]
        public void IsDoubleRangeSendOutOfRangeTest()
        {
            Assert.IsFalse(validation.IsDoubleRange(1.5, 10.6, 11.0));
        }
        [Test]
        public void IsDoubleRangeSendBackwardsArgumentsTest()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), new TestDelegate(IsDoubleRangeSendBackwardsArgumentsTestDel));
        }
        void IsDoubleRangeSendBackwardsArgumentsTestDel()
        {
            validation.IsDoubleRange(10.6, 1.2, 3.5);
        }

        //IsPhone(String phone)
        [Test]
        public void IsPhoneSendHyphenatedTest()
        {
            Assert.IsTrue(validation.IsPhone("319-398-5411"));
        }
        [Test]
        public void IsPhoneSendParenthesizedHyphenatedTest()
        {
            Assert.IsTrue(validation.IsPhone("(319)-398-5411"));
        }
        [Test]
        public void IsPhoneSendParenthesizedOneHyphenTest()
        {
            Assert.IsTrue(validation.IsPhone("(319) 398-5411"));
        }
        [Test]
        public void IsPhoneSendParenthesizedOneHyphenNoSpaceTest()
        {
            Assert.IsTrue(validation.IsPhone("(319) 3985411"));
        }
        [Test]
        public void IsPhoneSendParenthesizedNoHyphenTest()
        {
            Assert.IsTrue(validation.IsPhone("(319) 398 5411"));
        }
        [Test]
        public void IsPhoneSendTenNumbersTest()
        {
            Assert.IsTrue(validation.IsPhone("3193985411"));
        }
        [Test]
        public void IsPhoneSendTenNumbersWithSpacesTest()
        {
            Assert.IsTrue(validation.IsPhone("319 398 5411"));
        }
        [Test]
        public void IsPhoneSendTenNumbersWithOneSpaceTest()
        {
            Assert.IsTrue(validation.IsPhone("319 3985411"));
        }
        [Test]
        public void IsPhoneSendTenNumbersWithOneSpaceOneHyphenTest()
        {
            Assert.IsTrue(validation.IsPhone("319 398-5411"));
        }

        //fails IsPhone
        [Test]
        public void IsPhoneSendNineNumbersWithOneSpaceOneHyphenTest()
        {
            Assert.IsFalse(validation.IsPhone("319 398-541"));
        }
        [Test]
        public void IsPhoneSendNineNumbersTest()
        {
            Assert.IsFalse(validation.IsPhone("193985411"));
        }
        [Test]
        public void IsPhoneSendElevenNumbersTest()
        {
            Assert.IsFalse(validation.IsPhone("31939854112"));
        }
        [Test]
        public void IsPhoneSendStringTest()
        {
            Assert.IsFalse(validation.IsPhone("howdy"));
        }

        //IsEmail(String email)

        [Test]
        public void IsEmailSendValidEmailTest()
        {
            Assert.IsTrue(validation.IsEmail("billgates@vb.net"));
        }
        [Test]
        public void IsEmailSendValidEmailMultipleDotTest()
        {
            Assert.IsTrue(validation.IsEmail("bill.m.gates@vb.net"));
        }

        //fails IsEmail
        [Test]
        public void IsEmailSendNoAtSignTest()
        {
            Assert.IsFalse(validation.IsEmail("billgatesvb.net"));
        }
        [Test]
        public void IsEmailSendNoDomainTest()
        {
            Assert.IsFalse(validation.IsEmail("billgates@vbnet"));
        }
        [Test]
        public void IsEmailSendStringTest()
        {
            Assert.IsFalse(validation.IsEmail("billgatesvbnet"));
        }

        //ValidateZip(String zip) 
        [Test]
        public void ValidateZipSendValidFiveNumberZip()
        {
            Assert.IsTrue(validation.ValidateZip("52404"));
        }
      
        //fails ValidateZip
        [Test]
        public void ValidateZipSendInvalidFourNumberZip()
        {
            Assert.IsFalse(validation.ValidateZip("5240"));
        }
        [Test]
        public void ValidateZipSendInvalidSixNumberZip()
        {
            Assert.IsFalse(validation.ValidateZip("524045"));
        }
        [Test]
        public void ValidateZipSendInvalidStringZip()
        {
            Assert.IsFalse(validation.ValidateZip("howdy"));
        }
        [Test]
        public void ValidateZipSendInvalidDoubleZip()
        {
            Assert.IsFalse(validation.ValidateZip("5240.5"));
        }
            
        
    } // end ValidationTest class

 
}
