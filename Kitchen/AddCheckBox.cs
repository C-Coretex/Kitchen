﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitchen
{
    public partial class AddCheckBox : Form
    {
        static public string name = "";
        public AddCheckBox()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool equals = false;
            if (textBox1.Text != "" && textBox1.Text != " " && textBox1.Text != "  " && textBox1.Text != "   " && textBox1.Text != "    ")
            {
                string[] ingridients = (File.ReadAllLines(Form1.pathToFile + @"Ingridients.txt", Encoding.UTF8));
                foreach (string s  in ingridients) {
                    if (s == textBox1.Text)
                        equals = true;
                }
                if (equals == false)
                {
                    File.AppendAllText(path: Form1.pathToFile + "Ingridients.txt", contents: Environment.NewLine + textBox1.Text);
                    Form3.name_ = textBox1.Text;
                    this.Close();
                }
                else
                    MessageBox.Show("Этот ингредиент уже записан");
            }
        }

        private void AddCheckBox_Load(object sender, EventArgs e)
        {
        }
    }
}