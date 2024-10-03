using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Calculator.Extensions
{
    public static class StringManipulator
    {
        #region Conversion Methods

        public static byte ConvertStringToDouble(string s, out double result)
        {
            result = 0;

            //ERROR CODE 1 - Input has to be an ASCII character (mostly letters, numbers and operation symbols) and cannot include any letters
            if (HasNonASCIICharacters(s) || s.Any(x => char.IsLetter(x))) return 1;
            //ERROR CODE 2 - Parsing issue - I try to avoid try/catch if there is a way to
            else if (!double.TryParse(s.Replace('.', ','), out result)) return 2;

            return 0;
        }

        #endregion

        #region Information Checks

        //Checks whether the byte count of a string is the same as its character length (1B = 1 ASCII character)
        public static bool HasNonASCIICharacters(string str)
        {
            return (Encoding.UTF8.GetByteCount(str) != str.Length);
        }

        #endregion
    }
}
