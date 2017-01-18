using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
        public interface IOperation
        {
            string Name { get; }
            object Execute(object[] args);
        }
        
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
}
