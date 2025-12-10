using System;

namespace Caculator_SDD.Models
{
    public class CaculatorEngine : ICaculatorEngine
    {
        public double Caculate(double num1, double num2, string operation)
        {
            switch (operation)
            {
                case "+": return num1 + num2;
                case "-": return num1 - num2;
                case "*": return num1 * num2;
                case "/":
                    if (num2 == 0) throw new DivideByZeroException("Cannot divide by zero.");
                    return num1 / num2;
                default:
                    throw new ArgumentException($"Unknown operation: {operation}");
            }
        }

        public double CaculateScientific(double num, string operation)
        {
            // Task 2.3 先讓它拋出例外
            throw new NotImplementedException();
        }
    }
}