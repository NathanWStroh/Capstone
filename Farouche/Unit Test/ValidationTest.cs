using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
//using com.Farouche.Commons;
using com.Farouche.BusinessLogic;
using System.Text;


//Author: Andrew
//Date Created: 3/30/14
//Last Modified: 4/10/14
//Last Modified By: Andrew Willhoit

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 4/10/14      Andrew       Golden                          Changed to accommodate Validation.cs move to BLL and transition to static methods
* 
*/


namespace Unit_Test
{

    [TestFixture]
    public class ValidationTest
    {


        [SetUp]
        public void Setup()
        {

        }

       

        //IsNullOrEmpty(String test)
        [Test]
        public void IsNullOrEmptySendStringTest()
        {
            Assert.IsFalse(Validation.IsNullOrEmpty("howdy"));
        }
        [Test]
        public void IsNullOrEmptySendOpenSpaceTest()
        {
            Assert.IsFalse(Validation.IsNullOrEmpty(" "));
        }
        [Test]
        public void IsNullOrEmptySendEmptyTest()
        {
            Assert.IsTrue(Validation.IsNullOrEmpty(""));
        }
        [Test]
        public void IsNullOrEmptySendNullTest()
        {
            Assert.IsTrue(Validation.IsNullOrEmpty(null));
        }

        //IsBlank(String test)
        [Test]
        public void IsBlankSendEmptyTest()
        {
            Assert.IsTrue(Validation.IsBlank(""));
        }
        [Test]
        public void IsBlankSendBlankTest()
        {
            Assert.IsTrue(Validation.IsBlank("     "));
        }
        [Test]
        public void IsBlankSendNullTest()
        {
            Assert.Throws(typeof(NullReferenceException), new TestDelegate(IsBlankSendNullTestDel));
        }
        void IsBlankSendNullTestDel()
        {
            Validation.IsBlank(null);
        }


        //IsInt(String test)
        [Test]
        public void IsIntSendDoubleTest()
        {
            Assert.IsFalse(Validation.IsInt("45.0"));
        }
        [Test]
        public void IsIntSendCharsTest()
        {
            Assert.IsFalse(Validation.IsInt("howdy"));
        }
        [Test]
        public void IsIntSendIntTest()
        {
            Assert.IsTrue(Validation.IsInt("12"));
        }

        //IsDouble(String test)
        [Test]
        public void IsDoubleSendIntTest()
        {
            Assert.IsTrue(Validation.IsDouble("12"));
        }
        [Test]
        public void IsDoubleSendCharsTest()
        {
            Assert.IsFalse(Validation.IsDouble("howdy"));
        }
        [Test]
        public void IsDoubleSendDoubleTest()
        {
            Assert.IsTrue(Validation.IsDouble("25.8"));
        }

        //IsIntRange(int min,int max, int test)
        [Test]
        public void IsIntRangeSendWithinRangeTest()
        {
            Assert.IsTrue(Validation.IsIntRange(1,10,3));
        }
        [Test]
        public void IsIntRangeSendOutOfRangeTest()
        {
            Assert.IsFalse(Validation.IsIntRange(1, 10, 11));
        }
        [Test]
        public void IsIntRangeSendBackwardsArgumentsTest()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), new TestDelegate(IsIntRangeSendBackwardsArgumentsTestDel));
        }
        void IsIntRangeSendBackwardsArgumentsTestDel()
        {
            Validation.IsIntRange(10,1,3);
        }

        //IsDoubleRange(double min, double max, double test)
        [Test]
        public void IsDoubleRangeSendWithinRangeTest()
        {
            Assert.IsTrue(Validation.IsDoubleRange(1.5, 10.6, 3.2));
        }
        [Test]
        public void IsDoubleRangeSendOutOfRangeTest()
        {
            Assert.IsFalse(Validation.IsDoubleRange(1.5, 10.6, 11.0));
        }
        [Test]
        public void IsDoubleRangeSendBackwardsArgumentsTest()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), new TestDelegate(IsDoubleRangeSendBackwardsArgumentsTestDel));
        }
        void IsDoubleRangeSendBackwardsArgumentsTestDel()
        {
            Validation.IsDoubleRange(10.6, 1.2, 3.5);
        }

        //IsPhone(String phone)
        [Test]
        public void IsPhoneSendHyphenatedTest()
        {
            Assert.IsTrue(Validation.IsPhone("319-398-5411"));
        }
        [Test]
        public void IsPhoneSendParenthesizedHyphenatedTest()
        {
            Assert.IsTrue(Validation.IsPhone("(319)-398-5411"));
        }
        [Test]
        public void IsPhoneSendParenthesizedOneHyphenTest()
        {
            Assert.IsTrue(Validation.IsPhone("(319) 398-5411"));
        }
        [Test]
        public void IsPhoneSendParenthesizedOneHyphenNoSpaceTest()
        {
            Assert.IsTrue(Validation.IsPhone("(319) 3985411"));
        }
        [Test]
        public void IsPhoneSendParenthesizedNoHyphenTest()
        {
            Assert.IsTrue(Validation.IsPhone("(319) 398 5411"));
        }
        [Test]
        public void IsPhoneSendTenNumbersTest()
        {
            Assert.IsTrue(Validation.IsPhone("3193985411"));
        }
        [Test]
        public void IsPhoneSendTenNumbersWithSpacesTest()
        {
            Assert.IsTrue(Validation.IsPhone("319 398 5411"));
        }
        [Test]
        public void IsPhoneSendTenNumbersWithOneSpaceTest()
        {
            Assert.IsTrue(Validation.IsPhone("319 3985411"));
        }
        [Test]
        public void IsPhoneSendTenNumbersWithOneSpaceOneHyphenTest()
        {
            Assert.IsTrue(Validation.IsPhone("319 398-5411"));
        }

        //fails IsPhone
        [Test]
        public void IsPhoneSendNineNumbersWithOneSpaceOneHyphenTest()
        {
            Assert.IsFalse(Validation.IsPhone("319 398-541"));
        }
        [Test]
        public void IsPhoneSendNineNumbersTest()
        {
            Assert.IsFalse(Validation.IsPhone("193985411"));
        }
        [Test]
        public void IsPhoneSendElevenNumbersTest()
        {
            Assert.IsFalse(Validation.IsPhone("31939854112"));
        }
        [Test]
        public void IsPhoneSendStringTest()
        {
            Assert.IsFalse(Validation.IsPhone("howdy"));
        }

        //IsEmail(String email)

        [Test]
        public void IsEmailSendValidEmailTest()
        {
            Assert.IsTrue(Validation.IsEmail("billgates@vb.net"));
        }
        [Test]
        public void IsEmailSendValidEmailMultipleDotTest()
        {
            Assert.IsTrue(Validation.IsEmail("bill.m.gates@vb.net"));
        }

        //fails IsEmail
        [Test]
        public void IsEmailSendNoAtSignTest()
        {
            Assert.IsFalse(Validation.IsEmail("billgatesvb.net"));
        }
        [Test]
        public void IsEmailSendNoDomainTest()
        {
            Assert.IsFalse(Validation.IsEmail("billgates@vbnet"));
        }
        [Test]
        public void IsEmailSendStringTest()
        {
            Assert.IsFalse(Validation.IsEmail("billgatesvbnet"));
        }

        //ValidateZip(String zip) 
        [Test]
        public void ValidateZipSendValidFiveNumberZip()
        {
            Assert.IsTrue(Validation.ValidateZip("52404"));
        }
      
        //fails ValidateZip
        [Test]
        public void ValidateZipSendInvalidFourNumberZip()
        {
            Assert.IsFalse(Validation.ValidateZip("5240"));
        }
        [Test]
        public void ValidateZipSendInvalidSixNumberZip()
        {
            Assert.IsFalse(Validation.ValidateZip("524045"));
        }
        [Test]
        public void ValidateZipSendInvalidStringZip()
        {
            Assert.IsFalse(Validation.ValidateZip("howdy"));
        }
        [Test]
        public void ValidateZipSendInvalidDoubleZip()
        {
            Assert.IsFalse(Validation.ValidateZip("5240.5"));
        }
            
        
    } // end ValidationTest class

 
}
