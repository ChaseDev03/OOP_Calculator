using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Calculator.Operations
{
    public interface IOperation
    {
        #region Operations

        byte PerformOperation(double a, double b, out double result);

        #endregion

        #region Getter Methods

        string GetOperationExample();

        #endregion
    }
}
