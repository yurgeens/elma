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

            var oper = operations.FirstOrDefault(o => o.Name == name.ToLower());//Выбирается нужный оператор с преобразованием регистра в нижний
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
}
