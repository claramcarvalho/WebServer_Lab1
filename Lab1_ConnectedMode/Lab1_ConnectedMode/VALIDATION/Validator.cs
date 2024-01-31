using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

//Example : EmployeeID (4-digit number)
// Pattern: "^\d{4}$"

namespace Lab1_ConnectedMode.VALIDATION
{
    public static class Validator
    {
        //a method to check if the input data is 4-digit number
        public static bool IsValidID (string input)
        {
            if (!Regex.IsMatch(input, @"^\d{4}$"))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidID(string input, int size)
        {
            if (!Regex.IsMatch(input, @"^\d{"+ size +"}$"))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidName (string input)
        {
            if (input.Length == 0)
            {
                return false ;
            }

            for ( int i = 0 ; i < input.Length ; i++)
            {
                if (!(Char.IsLetter(input[i])) && !(Char.IsWhiteSpace(input[i])) )
                {
                    return false;
                }
            }

            return true;
        }
    }
}