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
    public partial class Form1 : Form
    {
        bool a = false;
        bool closed = false;
        public Form1()
        {
            InitializeComponent();
            FindRecepts.TabStop = false;
            FindRecepts.FlatStyle = FlatStyle.Flat;
            FindRecepts.FlatAppearance.BorderSize = 0;
            BrowseRecepts.TabStop = false;
            BrowseRecepts.FlatStyle = FlatStyle.Flat;
            BrowseRecepts.FlatAppearance.BorderSize = 0;

        }

        private void FindRecepts_Click(object sender, EventArgs e)
        {

        }

        private void BrowseRecepts_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.StartPosition = FormStartPosition.Manual;
            f2.Location = this.Location;
            Hide();
            f2.ShowDialog();
            Close();//Закрывает ПЕРВУЮ форму
        }

        private void NAMES_KeyDown(object sender, KeyEventArgs e)
        {
            if ((a == false || NAMES.Text == "") && (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete && e.KeyCode != Keys.ShiftKey && e.KeyCode != Keys.Tab && e.KeyCode != Keys.Alt && e.KeyCode != Keys.CapsLock && e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.LWin))
            {
                SendKeys.Send("{Enter}");
                label1.Text = "";
            }
            if (e.KeyCode == Keys.Enter)
            {
                NAMES.Text = "● " + NAMES.Text;
                SendKeys.Send("{RIGHT}");
            }
            if ((a == false || NAMES.Text == "") && (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete && e.KeyCode != Keys.ShiftKey && e.KeyCode != Keys.Tab && e.KeyCode != Keys.Alt && e.KeyCode != Keys.CapsLock && e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.LWin))
            {
                SendKeys.Send("{RIGHT}" + "{RIGHT}");
                a = true;
            }
        }
        private void NAMES_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
