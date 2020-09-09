using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DP22StrategyWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.listBox1.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory =@"E:\NET软件工程师1001\12DP\Code\DP22StrategyDLL\bin\Debug" ;//Application.StartupPath;
            if (this.openFileDialog1.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(this.openFileDialog1.FileName);

                foreach (Type item in assembly.GetTypes())
                {
                    if (item.IsSubclassOf(typeof(DP22StrategyV2.Strategy)))
                    {
                       object  instanceOfStrategy = assembly.CreateInstance(item.FullName);
                       this.listBox1.Items.Add(instanceOfStrategy);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DP22StrategyV2.Order order = new DP22StrategyV2.Order(double.Parse(this.textBox1.Text));

            foreach (var item in this.listBox1.SelectedItems)
            {
                order.AddStrategy(item as DP22StrategyV2.Strategy);
            }

            var result = order.UsePromot();
            MessageBox.Show(result);
        }
    }
}
