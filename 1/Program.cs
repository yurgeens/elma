using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sum Razn Umnozh Step Factorial");
            var calc = new Calc.Calc(new Calc.IOperation[] { new Calc.SumOperation(), new Calc.RaznOperation(), new Calc.UmnozhOperation(), new Calc.StepenOperation(), new Calc.FactorOperation()});
            var result = calc.Execute( Console.ReadLine(), new object[] { 5 , 2 });
            Console.WriteLine(string.Format("result={0}", result));
            Console.ReadKey();
        }
    }
}
