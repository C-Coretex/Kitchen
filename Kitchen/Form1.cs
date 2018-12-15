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
        static public string pathToFile = "";
        public Form1(string saveMyIng)
        {
            InitializeComponent();
            FindRecepts.TabStop = false;
            FindRecepts.FlatStyle = FlatStyle.Flat;
            FindRecepts.FlatAppearance.BorderSize = 0;
            BrowseRecepts.TabStop = false;
            BrowseRecepts.FlatStyle = FlatStyle.Flat;
            BrowseRecepts.FlatAppearance.BorderSize = 0;
            NAMES.ScrollBars = ScrollBars.Both;
            NAMES.Text = saveMyIng;
            // string o = System.AppDomain.CurrentDomain.BaseDirectory;
            //string pathToFile = @o + "\";
            //РАБОТАЕТ ТОЛЬКО ПОСЛЕ ИНСТАЛЯТОРА(должно)
            pathToFile = @"C:\Users\valer\Desktop\Programming\Kitchen\";
        }
        


        private void FindRecepts_Click(object sender, EventArgs e)
        {
            Find find = new Find(NAMES.Text);
            find.StartPosition = FormStartPosition.Manual;
            find.Location = this.Location;
            find.ShowDialog();
        }



        private void BrowseRecepts_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.StartPosition = FormStartPosition.Manual;
            f2.Location = this.Location;
            Hide();
            Form2.saveMyIng = NAMES.Text.Trim();
            f2.ShowDialog();
            Close();//Закрывает ПЕРВУЮ форму
        }

        private void NAMES_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void NAMES_TextChanged(object sender, EventArgs e)
        {
            if (NAMES.Text.Length == 0)
            {
                label1.Visible = true;
            }
            else
            {
                label1.Visible = false;
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
