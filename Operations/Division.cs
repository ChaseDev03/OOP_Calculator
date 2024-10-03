using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Calculator.Operations
{
    public class Division : IOperation
    {
        #region Operations

        public byte PerformOperation(double a, double b, out double result)
        {
            result = 0;

            //ERROR CODE 1 - Division by 0 is impossible, the program doesn't crash when it's not handled, but returns '?' to the user (infinity?)
            if (b == 0)
            {
                Program.ShowMessage("It is impossible to divide by 0 in common mathematics.", ConsoleColor.Red);
                return 1;
            }

            result =  a / b;

            return 0;
        }

        #endregion

        #region Getter Methods

        public string GetOperationExample()
        {
            return "Operator '/' for division: a / b";
        }

        #endregion
    }
}
