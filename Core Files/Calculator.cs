using OOP_Calculator.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Calculator
{
    public class Calculator
    {
        #region Initializations

        //Creates the strategies for 4 main mathematical operations
        private void InitializeOperations()
        {
            operations.Add('+', new Addition());
            operations.Add('-', new Substraction());
            operations.Add('*', new Multiplication());
            operations.Add('/', new Division());
        }

        #endregion

        #region Declarations

        private Dictionary<char, IOperation> operations = new Dictionary<char, IOperation>();

        #endregion

        #region Class Methods

        public Calculator()
        {
            InitializeOperations();
        }

        #endregion

        #region Calculations Methods

        //Performs operator's (strategy) calculation method
        public byte Calculate(double a, double b, char operation, out double result)
        {
            return operations[operation].PerformOperation(a, b, out result);
        }

        public byte GetSupportedOperationFromString(string s, out char result)
        {
            result = ' ';

            //ERROR CODE 1 - Each operation is inputted with a single character only
            if (s.Length > 1) return 1;
            //ERROR CODE 2 - Operation has to be supported and initialized
            else if (!IsOperationSupported(s[0])) return 2;

            //Returns first character of user's input
            result = s[0];
            return 0;
        }

        public bool IsOperationSupported(char op)
        {
            return operations.ContainsKey(op);
        }

        #endregion

        #region Getter Methods

        //Gets examples/info about each operation
        public string[] GetSupportedOperationsInfo()
        {
            int i = 0;
            string[] result = new string[operations.Count];

            foreach (KeyValuePair<char, IOperation> oper in operations)
            {
                result[i] = oper.Value.GetOperationExample();
                i++;
            }

            return result;
        }

        #endregion
    }
}
