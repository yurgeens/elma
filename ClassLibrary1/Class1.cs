
using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class UmnozhOperation : IOperation
    {
        public string Name { get { return "umno"; } }
        public object Execute(object[] args)
        {
            int umn = 1;

            for (int i = 0; i < args.Count(); i++)
            {
                umn *= Convert.ToInt32(args[i]);
            }
            return umn;
        }
    }
}
