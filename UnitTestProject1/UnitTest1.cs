using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calc;
namespace UnitTestProject1
{
    
    /// <summary>
    /// Тестирование Calc
    /// </summary>
    [TestClass]
    public class CalcUnitTest
    {
        [TestMethod]
        public void SumTest()
        {
            var calc = new Calc.Calc();
            var result = calc.Sum(1, 2);
            Assert.AreEqual(result, 3);
        }
    }
}
