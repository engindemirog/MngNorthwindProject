using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox3.Items.Add("Buton 1 : " + Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(2000);
                listBox1.Items.Add(i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox3.Items.Add("Buton 2 : "+Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 10; i++)
            {
                listBox2.Items.Add(i);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox3.Items.Add("Load : " +Thread.CurrentThread.ManagedThreadId);
        }
    }
}
