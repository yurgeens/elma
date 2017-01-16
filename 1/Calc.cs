using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class Calc
    {
        /// <summary>
        /// Сумма
        /// </summary>
        /// <param name="x">Слагаемое 1</param>
        /// <param name="y">Слагаемое 2</param>
        /// <returns></returns>
       /* public int Sum(int x, int y)
        {
            return (int)Execute("Sum", new object[] { x, y });
        }
        public int Raznost(int x, int y)
        {
            return (int)Execute("Razn", new object[] { x, y });
        }*/
        private IOperation[] operations { get; set; }
        public object Execute(string name, object[] args)
        {
            var oper = operations.FirstOrDefault(o => o.Name == name);
            return oper.Execute(args);
        }
        public Calc(IOperation[] opers)
        {
            operations = opers;
        }
    }

    public interface IOperation
    {
        string Name { get; }
        object Execute(object[] args);
    }
    public class SumOperation : IOperation
    {
        public string Name { get { return "Sum"; } }
        public object Execute(object[] args)
        {
            return (int)args[0] + (int)args[1];
        }
    }
    public class RaznOperation: IOperation
    {
        public string Name { get { return "Razn"; } }
        public object Execute(object[] args)
        {
            return (int)args[0] - (int)args[1];
        }
    }
    public class UmnozhOperation : IOperation
    {
        public string Name { get { return "Umnozh"; } }
        public object Execute(object[] args)
        {
            return (int)args[0] * (int)args[1];
        }
    }
    public class StepenOperation : IOperation
    {
        public string Name { get { return "Step"; } }
        public object Execute(object[] args)
        {
            return Math.Pow((int)args[0] ,(int)args[1]);
        }
    }
    public class FactorOperation : IOperation
    {
        public string Name { get { return "Factorial"; } }
        public object Execute(object[] args)
        {
            int fac=1;
            for(int i = (int)args[0]; i!=0; i--)
            {
                fac *= i;
            }
            return fac;
        }
    }
}
