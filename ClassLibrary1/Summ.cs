using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calc;

namespace ClassLibrary1
{
    public class SummOperation: IOperation
    {
        public string Name { get { return "summ"; } }
        public object Execute(object [] args)
        {
            int sum = 0;
            for(int i = 0;i<args.Count();i++)
            {
                sum += Convert.ToInt32( args[i]);
            }
            return sum;
        }
    }
}
