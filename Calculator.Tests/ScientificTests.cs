using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
// 👇 關鍵：這裡要跟您的主專案名稱一模一樣
using Caculator_SDD.Models;

namespace Caculator.Tests
{
    [TestClass]
    public class ScientificTests
    {
        [TestMethod]
        public void Sin_ReturnsExpectedValue_ForDegrees()
        {
            // Arrange
            ICaculatorEngine engine = new CaculatorEngine();

            // Act
            // 這裡呼叫 CalculateScientific，因為還沒實作，預期會拋出例外或錯誤
            double result = engine.CaculateScientific(30.0, "sin");

            // Assert
            Assert.AreEqual(0.5, result, 1e-8);
        }

        [TestMethod]
        public void Cos_ReturnsExpectedValue_ForDegrees()
        {
            ICaculatorEngine engine = new CaculatorEngine();
            double result = engine.CaculateScientific(60.0, "cos");
            Assert.AreEqual(0.5, result, 1e-8);
        }

        [TestMethod]
        public void Sqrt_ReturnsExpectedValue()
        {
            ICaculatorEngine engine = new CaculatorEngine();
            double result = engine.CaculateScientific(9.0, "sqrt");
            Assert.AreEqual(3.0, result, 1e-8);
        }

        [TestMethod]
        public void Sqrt_Negative_ThrowsArgumentOutOfRangeException()
        {
            ICaculatorEngine engine = new CaculatorEngine();

            // Act & Assert
            // 這裡使用 Lambda 表達式來驗證是否拋出例外
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                engine.CaculateScientific(-1.0, "sqrt");
            });
        }
    }
}