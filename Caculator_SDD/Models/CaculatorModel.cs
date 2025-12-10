using System;

namespace Caculator_SDD.Models
{
    // 簡單的 domain model，實務可依 Spec 擴充
    public class CaculatorModel
    {
        public double Add(double a, double b) => a + b;
        public double Subtract(double a, double b) => a - b;
        public double Multiply(double a, double b) => a * b;
        public double Divide(double a, double b) => b == 0 ? throw new DivideByZeroException() : a / b;
    }
}
