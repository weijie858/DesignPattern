using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DP02AbstractFactory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private System.Reflection.Assembly assembly = null;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "exe文件|*.exe|dll文件|*.dll";
            of.InitialDirectory = Application.StartupPath;
            if (of.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                this.assembly = System.Reflection.Assembly.LoadFile(of.FileName);

                this.comboBox1.Items.Clear();

                foreach (var item in this.assembly.GetTypes())
                {
                    if (item.IsSubclassOf(typeof(SportsShop)))
                    {
                        this.comboBox1.Items.Add(item);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Shoes s = null;
            Hat h = null;

            SportsShop shop = null;          

            string TypeName = ((Type)this.comboBox1.SelectedItem).FullName;
        //    shop = (SportsShop)this.assembly.CreateInstance(TypeName);
            shop = Factory.CreateShop(this.assembly, TypeName);
           

            s = shop.SellShoes();
            h = shop.SellHat();

            MessageBox.Show(string.Format("鞋子:{0},帽子:{1}", s, h));
        }




    }



    public static class Factory
    {
        public static SportsShop CreateShop(System.Reflection.Assembly assembly, string TypeName)
        {
             return (SportsShop)assembly.CreateInstance(TypeName);
            //switch (TypeName)
            //{
            //    case "Lining":
            //        return new LiningShop();
            //        break;
            //    case "Nike":
            //        return new NikeShop();
            //        break;
            //    default:
            //        return null;
            //        break;
            //}


        }
    }
}
