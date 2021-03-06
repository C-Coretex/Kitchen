﻿using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Kitchen
{
    public partial class AddCategory: Form
    {
        static public string categoryName = "";
        public AddCategory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool equals = false;
            if (textBox1.Text.Trim() != "")
            {
                textBox1.Text = textBox1.Text.Substring(0, 1).ToUpper() + textBox1.Text.Substring(1, textBox1.Text.Length - 1);
                string[] ingridients = (File.ReadAllLines(Form1.pathToFile + @"Cccategory.txt", Encoding.UTF8));
                foreach (string s in ingridients)
                {
                    if (s == textBox1.Text.Trim())
                        equals = true;
                }
                if (equals == false)
                {
                    File.AppendAllText(path: Form1.pathToFile + "Cccategory.txt", contents: Environment.NewLine + textBox1.Text.Trim());
                    categoryName = textBox1.Text.Trim();
                    this.Close();
                }
                else
                    MessageBox.Show("Эта категория уже записан");
            }
        }
    }
}
