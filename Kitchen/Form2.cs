using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitchen
{
    public partial class Form2 : Form
    {
        bool ingr = false;
        string line1 = "";
        public Form2()
        {
            InitializeComponent();
            // string o = System.AppDomain.CurrentDomain.BaseDirectory;
            //string pathToFile = @o + @"\Text.txt";
            //StreamWriter sw = new StreamWriter(pathToFile, true); РАБОТАЕТ ТОЛЬКО ПОСЛЕ ИНСТАЛЯТОРА
            //РАБОТАЕТ ТОЛЬКО ПОСЛЕ ИНСТАЛЯТОРА(должно)
            string pathToFile = @"C:\Users\valer\Desktop\Programming\Kitchen\" + @"Text.txt";
            StreamReader sr = new StreamReader(pathToFile, true);
            testBox2.Text = sr.ReadToEnd();
            sr.Close();
            testBox2.ScrollBars = ScrollBars.Both;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }
        
        private void Back_Click(object sender, EventArgs e)
        {
                string pathToFile = @"C:\Users\valer\Desktop\Programming\Kitchen\" + @"Text.txt";
                StreamWriter sw = new StreamWriter(pathToFile, false);
                    line1 = testBox2.Text;
                    line1 = line1.Replace(" \t ", "");
                    line1 = line1.Replace(" \n ", "");
                    line1 = line1.Trim();
                sw.WriteLine(line1);
                sw.Close();

            Form1 f1 = new Form1();
            f1.StartPosition = FormStartPosition.Manual;
            f1.Location = this.Location;
            Hide();
            f1.ShowDialog();
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (findText == null)
            {
                label1.Text = "Найти по названию";
            }
        }

        private void testBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void Find_Click(object sender, EventArgs e)
        {
            if(label1.Text != null)
            {
                if(testBox2.Text.Contains(findText.Text) && (findText.Text != "" && findText.Text !=" "))
                {
                    int start = 0;
                    int len = findText.Text.Length;
                    string txt = findText.Text;
                    for (int i = 0; i<testBox2.Text.Length; i += 1)
                    {
                        testBox2.Select(i, len);
                        if (testBox2.SelectedText == txt)
                        {
                            start = testBox2.SelectionStart;
                        }
                    }
                    MessageBox.Show("Ваш запрос: '" + findText.Text + "' найден");
                    testBox2.Select(start, len);
                    SendKeys.Send("{Tab}");
                    testBox2.ScrollToCaret();
                }
                else if (findText.Text != " ")
                {
                    MessageBox.Show("Слово: '" + findText.Text + " НЕ найдено!");
                }
            }
        }

        private void findText_Click(object sender, EventArgs e)
        {
            if (label1 != null)
            {
                label1.Text = null;
            }
        }

        private void findText_TextChanged(object sender, EventArgs e)
        {
            if (label1 != null)
            {
                label1.Text = null;
            }
            if (findText.Text == "")
            {
                label1.Text = "Найти по названию";
            }
        }

        private void testBox2_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void findText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Find.PerformClick();
                SendKeys.Send("{Tab}");
            }
        }
    }
}
