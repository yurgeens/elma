using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calc;
namespace UnitTestProject1
{
    [TestClass]
    public class CalcUnitTest
    {
        [TestMethod]
        public void SumTest()
        {
            var calc = new Calc.Calc(new Calc.IOperation[] {new Calc.SumOperation() });
            var result = calc.Execute("Sum", new object[] { 5, 2 });
            Assert.AreEqual(result, 7);
        }
        [TestMethod]
        public void RazTest()
        {
            var calc = new Calc.Calc(new Calc.IOperation[] { new Calc.RaznOperation() });
            var result = calc.Execute("Razn", new object[] { 5, 2 });
            Assert.AreEqual(result, 3);
        }
        [TestMethod]
        public void UmnTest()
        {
            var calc = new Calc.Calc(new Calc.IOperation[] { new Calc.UmnozhOperation() });
            var result = calc.Execute("Umnozh", new object[] { 5, 2 });
            Assert.AreEqual(result, 10);
        }
        [TestMethod]
        public void StepTest()
        {
            var calc = new Calc.Calc(new Calc.IOperation[] { new Calc.StepenOperation() });
            var result = calc.Execute("Step", new object[] { 5, 2 });
            Assert.AreEqual(result, 25.0);
        }
        [TestMethod]
        public void Factor()
        {
            var calc = new Calc.Calc(new Calc.IOperation[] { new Calc.FactorOperation() });
            var result = calc.Execute("Factorial", new object[] { 5, 2 });
            Assert.AreEqual(result, 120);
        }
    }
}
