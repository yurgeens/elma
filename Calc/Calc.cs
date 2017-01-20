using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class Calc
    {
        private IEnumerable<IOperation> operations { get; set; }
        public object Execute(string name, object[] args)
        {

            var opers = operations.Where(o => o.Name == name.ToLower());//Выбирается нужный оператор с преобразованием регистра в нижний
            if (!opers.Any())
            { return $"Operation\" {name}\"not found"; }
            //Из всех операций выделяем только операции с заданным количеством аргументов
            var opersWithCount = opers.OfType<IOperationCount>();
            IOperation oper = opersWithCount.FirstOrDefault(o => o.Count == args.Count()) ?? opers.FirstOrDefault();
            if (oper==null)
            {
                oper = opers.FirstOrDefault();
            }
            if (oper == null)
            {
                return $"Operation\" {name}\"not found";
            }
                return oper.Execute(args);
        }
        public Calc(IOperation[] opers)
        {
            operations = opers;
        }
        public Calc(IEnumerable<IOperation> opers)
        {
            operations = opers;
        }
        /// <summary>
        /// Возвращает имена операций
        /// </summary>
        /// <returns></returns>
        public IEnumerable<String> GetOperationNames()
        {
            return operations.Select(o => o.Name);
        }
    }
    /// <summary>
    /// интерфейс для классов-операций
    /// </summary>
    public interface IOperation
    {
        string Name { get; }
        object Execute(object[] args);
    }
    public interface IOperationCount: IOperation
    {
        //Количество аргументов в операции
        int Count { get; }
    }
    public class SumOperation : IOperation
    {
        public string Name { get { return "summ"; } }
        public object Execute(object[] args)
        {
            int sum = 0;
            for (int i = 0; i < args.Count(); i++)
            {
                sum = sum + Convert.ToInt32(args[i]);
            }
            return sum;
        }
    }
    public class RaznOperation : IOperation
    {
        public string Name { get { return "razn"; } }
        public object Execute(object[] args)
        {
            int raz = Convert.ToInt32(args[0]);

            for (int i = 1; i < args.Count(); i++)
            {
                raz -= Convert.ToInt32(args[i]);
            }
            return raz;
        }
    }

    public class StepenOperation : IOperation
    {
        public string Name { get { return "step"; } }
        public object Execute(object[] args)
        {
            return Math.Pow((int)args[0], (int)args[1]);
        }
    }
    public class FactorOperation : IOperation
    {
        public string Name { get { return "fact"; } }
        public object Execute(object[] args)
        {
            int fac = 1;
            for (int i = (int)args[0]; i != 0; i--)
            {
                fac *= i;
            }
            return fac;
        }
    }
    public class DivOperation: IOperationCount
    {
        public int Count { get { return 1; } }
        public string Name { get { return "summ"; } }
        public object Execute(object[] args)
        {
            int sum = 0;
            for (int i = 0; i < args.Count(); i++)
            {
                sum = sum + Convert.ToInt32(args[i]);
            }
            return sum;
        }
    }
}
