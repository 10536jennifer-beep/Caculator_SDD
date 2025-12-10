using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caculator_SDD.Models; // 確保引用正確的命名空間

namespace Caculator.Tests
{
    [TestClass]
    public class StandardTests
    {
        [TestMethod]
        public void Add_ReturnsSum()
        {
            // Arrange
            ICaculatorEngine engine = new CaculatorEngine();

            // Act
            double result = engine.Caculate(1.5, 2.25, "+");

            // Assert (MSTest 使用 AreEqual)
            Assert.AreEqual(3.75, result, 1e-8);
        }

        [TestMethod]
        public void Subtract_ReturnsDifference()
        {
            ICaculatorEngine engine = new CaculatorEngine();
            double result = engine.Caculate(5.0, 2.0, "-");
            Assert.AreEqual(3.0, result, 1e-8);
        }

        [TestMethod]
        public void Multiply_ReturnsProduct()
        {
            ICaculatorEngine engine = new CaculatorEngine();
            double result = engine.Caculate(2.5, 4.0, "*");
            Assert.AreEqual(10.0, result, 1e-8);
        }

        [TestMethod]
        public void Divide_ReturnsQuotient()
        {
            ICaculatorEngine engine = new CaculatorEngine();
            double result = engine.Caculate(7.5, 2.5, "/");
            Assert.AreEqual(3.0, result, 1e-8);
        }
    }
}