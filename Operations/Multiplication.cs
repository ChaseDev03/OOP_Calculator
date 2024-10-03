using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Calculator.Operations
{
    public class Multiplication : IOperation
    {
        #region Operations

        public byte PerformOperation(double a, double b, out double result)
        {
            result = a * b;
            return 0;
        }

        #endregion

        #region Getter Methods

        public string GetOperationExample()
        {
            return "Operator '*' for multiplication: a * b";
        }

        #endregion
    }
}
