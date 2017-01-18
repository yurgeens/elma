using Calc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Калькулятор
        /// </summary>
        private Calc.Calc Calc { get; set; }
        private IEnumerable<string> OperationsName { get; set; }
        List<string> parametrs = new List<string>();
        private void Form1_Load(object sender, EventArgs e)
        {
            var operations = new List<IOperation>();
            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.dll");
            foreach (var file in files)
            {
                var assembly = Assembly.GetAssembly(typeof(IOperation));
                var types = assembly.GetTypes();//.Where(t => t.GetInterface());
                foreach (var type in types)
                {
                    var interfaces = type.GetInterfaces();
                    // найти реализацию интерфейса Ioperation
                    if (interfaces.Contains(typeof(IOperation)))
                    {
                        // Создаем экземпляр класса и приводим к нужному интерфейсу
                        var oper = Activator.CreateInstance(type) as IOperation;
                        if (oper != null )
                        {
                             operations.Add(oper);
                        }
                    }
                }
            }
            Calc = new Calc.Calc(operations);
            OperationsName = Calc.GetOperationNames();
            FillCombobox();
            //заполнить комбобокс
        }
        private void FillCombobox()
        {
            this.comboBox1.Items.AddRange(OperationsName.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parametrs.Clear();
            if (textBox1.Text != "")
            {
                parametrs.Add(textBox1.Text);
            }
            if (textBox2.Text != "")
            {
                parametrs.Add(textBox2.Text);
            }
            if (textBox3.Text != "")
            {
                parametrs.Add(textBox3.Text);
            }
            if (textBox4.Text != "")
            {
                parametrs.Add(textBox4.Text);
            }
            var result = Calc.Execute(comboBox1.Text, parametrs.ToArray());
            lblresult.Text =""+ result;
        }
    }
}
