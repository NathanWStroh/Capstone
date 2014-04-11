using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using com.Farouche.Commons;


//Author: Maggie - then Andrew
//Date Created: 3/28/14
//Last Modified: 4/10/14 
//Last Modified By: Andrew Willhoit

/*
*                               Changelog
* Date         By          Ticket          Version         Description
*4/10/14      Andrew        Golden                       Moved Validation.cs from Commons to com.Farouche.BusinessLogic
* 
*/

namespace com.Farouche.BusinessLogic
{
    public class Validation
    {

        public static Boolean IsNullOrEmpty(String test)
        {
            return String.IsNullOrEmpty(test);
        }

        // trims spaces before empty check
        public static Boolean IsBlank(String test)
        {
            return test.Trim().Equals(String.Empty);
        }

        public static Boolean IsInt(String test)
        {
            int number;
            return int.TryParse(test, out number);
        }

        public static Boolean IsDouble(String test)
        {
            double number;
            return double.TryParse(test, out number);
        }

        public static Boolean IsIntRange(int min, int max, int test)
        {
            if (min >= max)
            {
                throw new ArgumentOutOfRangeException("max", "'max' argument must be greater than 'min'.");
            }
            return (test >= min && test <= max);
        }

        public static Boolean IsDoubleRange(double min, double max, double test)
        {
            if (min >= max)
            {
                throw new ArgumentOutOfRangeException("max", "'max' argument must be greater than 'min'.");
            }
            return (test >= min && test <= max);
        }

        public static Boolean IsPhone(String phone)
        {
            return Regex.IsMatch(phone, @"^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$", RegexOptions.IgnoreCase);
        }

        public static Boolean IsEmail(String email)
        {
            return Regex.IsMatch(email,
              @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
              @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
              RegexOptions.IgnoreCase);
        }

        public static Boolean ValidateState(String state)
        {
            throw new NotImplementedException();
        }

        public static Boolean ValidateZip(String zip, String sCode)
        {
            int intZip;
            int firstZip = 0;
            int lastZip = 0;

            if (!IsInt(zip))
            {
                throw new ArgumentException("Zip is not a valid zip code");
            }


            intZip = Convert.ToInt32(zip);

            var appVariables = ApplicationVariables.Instance;



            for (int i = 1; i <= appVariables.States.Count; i++)
            {

                if (appVariables.States[i].StateCode.Equals(sCode))
                {
                    firstZip = appVariables.States[i].FirstZipCode;
                    lastZip = appVariables.States[i].LastZipCode;
                }

            }



            if (intZip >= firstZip && intZip <= lastZip)
            {
                return true;
            }


            return false;





        }




    } // end Validation class










}
