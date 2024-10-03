using OOP_Calculator.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Calculator
{
	static class Program
	{
		#region Initializations

		//Creates the Calculator object
		public static void InitializeCalculator()
		{
			calculator = new Calculator();
        }

        #endregion

        #region Declarations

        private static Calculator calculator;

        #endregion

        #region Loop

        public static void StartLoop()
		{
			//Main loop
			bool cont = true;
			while (cont)
			{
				double[] inputNums = GetNumbers(2);
				char oper = GetOperator();
				double result;
                byte resultCode = calculator.Calculate(inputNums[0], inputNums[1], oper, out result);

				if (resultCode == 0) ShowMessage($"The result is {inputNums[0]} {oper} {inputNums[1]} = {result}", ConsoleColor.Green);
				cont = AskToContinue();

            }
		}

        #endregion

        #region Dialogue Methods

		//Writes message on the console in a certain color
        public static void ShowMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

		//Asks whether user wants to continue and returns their input
		private static bool AskToContinue()
		{
			Console.WriteLine("Do you want to solve another mathematical problem? (y)");

			if (Console.ReadLine().ToLower() == "y") return true;
			return false;
		}

			#region Numbers

		//Gets 'howMany' number of numbers from the user
        private static double[] GetNumbers(int howMany)
		{
			double[] numbers = new double[howMany];
			for (int i = 0; i < howMany; i++)
			{
				//Makes sure the user actually puts in a number, if there's a problem, they have to try again until their input is a number
				double num = 0;
				while (!AskForNumber("Enter " + (i + 1) + ". number", out num));
				numbers[i] = num;
            }

			return numbers;
        }

		private static bool AskForNumber(string message, out double result)
		{
			//Tell the user what they should put in
			ShowMessage(message, ConsoleColor.White);
			string input = Console.ReadLine();

			//Convert user's input into number
			byte returnCode = StringManipulator.ConvertStringToDouble(input, out result);

			//This handles telling the user what went wrong, if anything did
			if (returnCode == 1)
			{
				ShowMessage("Input contains unrecognizable characters.", ConsoleColor.Red);
				return false;
			}
			else if (returnCode == 2)
			{
                ShowMessage("An error has happened mid-conversion of your input to a number. Try again.", ConsoleColor.Red);
				return false;
			}

			return true;
		}

		#endregion

			#region Operators

		private static char GetOperator()
		{
			ShowSupportedOperators();

			//Again, until they put in an actual operation, it won't go further
            char oper;
			while (!AskForOperator("Choose operation: ", out oper));

			return oper;
		}

		private static void ShowSupportedOperators()
		{
			foreach (string info in calculator.GetSupportedOperationsInfo())
			{
				ShowMessage(info, ConsoleColor.Cyan);
			}
		}

		//Same as AskForNumber(), but for operator
		private static bool AskForOperator(string message, out char result)
		{
			ShowMessage(message, ConsoleColor.White);
			string input = Console.ReadLine();

			result = ' ';
			//This tries to get supported operations from user's input
			byte returnCode = calculator.GetSupportedOperationFromString(input, out result);

			if (returnCode == 1)
			{
				ShowMessage("Operation characters contain a single character only.", ConsoleColor.Red);
				return false;
			}
			else if (returnCode == 2)
			{
                ShowMessage("This operation is not supported.", ConsoleColor.Red);
				return false;
            }

			return true;
        }

		#endregion

		#endregion
	}
}