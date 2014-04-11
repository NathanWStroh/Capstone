using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


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

        public static Boolean ValidateZip(String zip)
        {
            return (IsInt(zip) && zip.Length == 5);
        }




    } // end Validation class










}
