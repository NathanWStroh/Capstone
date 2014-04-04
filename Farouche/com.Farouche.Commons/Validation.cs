using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

//Author: Maggie - then Andrew
//Date Created: 3/28/14
//Last Modified: 3/31/14 
//Last Modified By: Andrew Willhoit

/*
*                               Changelog
* Date         By          Ticket          Version         Description
*
* 
*/


namespace com.Farouche.Commons
{

    public class Validation
    {

        public Boolean IsNullOrEmpty(String test)
        {
            return String.IsNullOrEmpty(test);
        }

        // trims spaces before empty check
        public Boolean IsBlank(String test)
        {
            return test.Trim().Equals(String.Empty);
        }

        public Boolean IsInt(String test)
        {
            int number;
            return int.TryParse(test, out number);
        }

        public Boolean IsDouble(String test)
        {
            double number;
            return double.TryParse(test, out number);
        }

        public Boolean IsIntRange(int min, int max, int test)
        {
            if (min >= max)
            {
                throw new ArgumentOutOfRangeException("max", "'max' argument must be greater than 'min'.") ; 
            }
            return (test >= min && test <= max);
        }

        public Boolean IsDoubleRange(double min, double max, double test)
        {
            if (min >= max)
            {
                throw new ArgumentOutOfRangeException("max", "'max' argument must be greater than 'min'.");
            }
            return (test >= min && test <= max);
        }

        public Boolean IsPhone(String phone)
        {
            return Regex.IsMatch(phone, @"^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$", RegexOptions.IgnoreCase);
        }

        public Boolean IsEmail(String email)
        {
            return Regex.IsMatch(email,
              @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
              @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
              RegexOptions.IgnoreCase);
        }

        public Boolean ValidateState(String state)
        {
            throw new NotImplementedException();
        }

        public Boolean ValidateZip(String zip)
        {
            return (IsInt(zip) && zip.Length == 5);
        }


    
    } // end Validation class




}
