using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace thread_test
{
    public partial class Form1 : Form
    {
        private Thread watek;

        public Form1()
        {
            InitializeComponent();
        }

        public void start()
        {
            watek = new Thread(funkcja);
            watek.Start();
            //watek.Start();
        }

        private void funkcja()
        {
            ulong zmienna = 0;

            for (ulong i = 0; i < 1000; i++)
            {
                for (ulong j = 0; j < 1000000; j++)
                {
                    zmienna += j;
                }
            }
            textBox1.Invoke(new Action(delegate ()
            {
                textBox1.Text = zmienna.ToString();
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            start();
            MessageBox.Show("Liczę w tle");           
        }
    }
}
