using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Calc;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            //найти файлы dll и exe в текущей директории
            // загрузить их
            // создать экземпляр класса
            // все эти экземпляры передаем в calc
            if (!args.Any())
            {
                Console.WriteLine("используй нужный формат");
                Console.ReadKey();
                return;
            }
            var operations = new List<IOperation>();
            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.dll");
            foreach(var file in files)
            {
                
                var assembly = Assembly.GetAssembly(typeof(IOperation));
                var types = assembly.GetTypes();//.Where(t => t.GetInterface());
                foreach (var type in types)
                {

                    var interfaces = type.GetInterfaces();
                    // найти реализацию интерфейса Ioperation
                    if (interfaces.Contains(typeof(IOperation)))
                    {
                        Console.WriteLine(type.Name);
                        // Создаем экземпляр класса и приводим к нужному интерфейсу
                        var oper = Activator.CreateInstance(type) as IOperation;
                        if (oper != null)
                        {
                            operations.Add(oper);
                        }
                    }
                }
                Console.WriteLine(file);
            }
            var activoper = args[0];
            var parametrs = args.Skip(1).ToArray();
                   
            var calc = new Calc.Calc(operations);
            var result = calc.Execute(activoper, parametrs);
            Console.WriteLine(string.Format("result={0}", result));
            Console.ReadKey();
        }
    }
}
