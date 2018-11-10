using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitchen
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.StartPosition = FormStartPosition.Manual;
            f1.Location = this.Location;
            Hide();
            f1.ShowDialog();
            Close();
        }

            private void label1_Click(object sender, EventArgs e)
        {
            if (textBox1 == null)
            {
                label1.Text = "Найти по названию:";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (label1 != null)
            {
                label1.Text = null;
            }
           if (textBox1.Text == "")
            {
                label1.Text = "Найти по названию";
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (label1 != null)
            {
                label1.Text = null;
            }
        }
    }
}
