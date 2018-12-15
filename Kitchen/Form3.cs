using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Kitchen
{
    public partial class Form3 : Form
    {
        string pathToFile = Form1.pathToFile;
        // checkBox3.Text = ingridients[2];
        CheckBox box; //Обьявляю для того, чтобы можно было использовать чекюоксы везде
        public Form3()
        {
            InitializeComponent();
            description.ScrollBars = ScrollBars.Both;
            string[] ingridients = (File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8));
            // checkBox1.Text = ingridients[0];
            // checkBox2.Text = ingridients[1];
            // checkBox3.Text = ingridients[2];
            for (int i = 0; i < ingridients.Length; i++)
            { 
                box = new CheckBox();
                box.Tag = i;
                box.TabIndex = 8 + i;
                box.Text = ingridients[i];
                box.AutoSize = true;
                box.Location = new Point(2, 142+i*10); //vertical
                //box.Location = new Point(i * 50, 10); //horizontal
                this.Controls.Add(box);
        }
        }

        private void saveExit_Click(object sender, EventArgs e)
        {
            if (name.Text != "" && description.Text != "")
            {
                //-----------------------------------------------------------------------------------------------------------------------------------------
                RecipeList.Serialization(name.Text, description.Text);
                this.Close();
                //-----------------------------------------------------------------------------------------------------------------------------------------
            }
            else if (name.Text == "")
            {
                MessageBox.Show("Впишите название рецепта");
            }
           // else if (ingridients.Text == "")
          //  {
           //     MessageBox.Show("Впишите ингридиенты");
          //  }
            else if (description.Text == "")
            {
                MessageBox.Show("Впишите описание рецепта");
            }
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
        }
        private void ingridients_TextChanged(object sender, EventArgs e)
        {
        }
        private void description_TextChanged(object sender, EventArgs e)
        {
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
