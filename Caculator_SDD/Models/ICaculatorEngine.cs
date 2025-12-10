using System;

namespace Caculator_SDD.Models
{
    public interface ICaculatorEngine
    {
        /// <summary>
        /// 執行二元運算 (如 +, -, *, /)
        /// </summary>
        double Caculate(double num1, double num2, string operation);

        /// <summary>
        /// 執行一元科學運算 (如 sin, cos, sqrt)
        /// </summary>
        double CaculateScientific(double num, string operation);
    }
}