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
        //bool a = false;
        // string o = System.AppDomain.CurrentDomain.BaseDirectory;
        //string pathToFile = @o;
        //РАБОТАЕТ ТОЛЬКО ПОСЛЕ ИНСТАЛЯТОРА(должно)
        // StreamReader sr = new StreamReader(pathToFile + @"Text.txt", true);
        //testBox2.Text = sr.ReadToEnd();
        // sr.Close();
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
            pathToFile = @"C:\Users\valer\Desktop\Programming\Kitchen\";
            // System.Threading.Thread.Sleep(1000);
            //  firstButton.PerformClick();
            //NAMES.Text = NAMES.Text = "● ";
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
            //  if ((a == false || NAMES.Text == "") && (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete && e.KeyCode != Keys.ShiftKey && e.KeyCode != Keys.Tab && e.KeyCode != Keys.Alt && e.KeyCode != Keys.CapsLock && e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.LWin))
            //  {
            //      SendKeys.Send("{Enter}");
            //      label1.Text = "";
            //  }
            // if(NAMES.Text == "")
            // {
            //    NAMES.Text = NAMES.Text = "● ";
            //  SendKeys.Send("{RIGHT}");
            // }
            

            //if(NAMES.TextLength == 0)
            //{
            //    firstButton.PerformClick();
            //}
            //string o = "";
            //if (NAMES.Text != "")
            //{
            //    o = NAMES.Text.Substring(NAMES.TextLength-1, 1);
            //}
            //bool a = false;
            //if ((e.KeyCode == Keys.Enter)&&(o != "●") && (o != "") && (o != " "))
            //{
            //    MessageBox.Show(" " + o);
            //    SendKeys.Send("{BackSpace}");
            //    NAMES.Text += Environment.NewLine + "● ";
            //    NAMES.Select(NAMES.TextLength, 0);
            //    SendKeys.Send("{Left}");
            //    a = true;
            //}
            //else if ((o != "●") && (o != "") && (o != " ")&& (a==true))
            //    {
            //    SendKeys.Send("{BackSpace}");
            //}


               // SendKeys.Send("{RIGHT}");
          //  if ((a == false || NAMES.Text == "") && (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete && e.KeyCode != Keys.ShiftKey && e.KeyCode != Keys.Tab && e.KeyCode != Keys.Alt && e.KeyCode != Keys.CapsLock && e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.LWin))
          //  {
          //      SendKeys.Send("{RIGHT}" + "{RIGHT}");
           //     a = true;
           // }
        }
        private void NAMES_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
