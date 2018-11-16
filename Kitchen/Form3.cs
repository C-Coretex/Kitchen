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
        public Form3()
        {
            InitializeComponent();
            ingridients.ScrollBars = ScrollBars.Both;
            description.ScrollBars = ScrollBars.Both;
        }

        private void saveExit_Click(object sender, EventArgs e)
        {
            if (name.Text != "" && ingridients.Text != "" && description.Text != "")
            {
                //-----------------------------------------------------------------------------------------------------------------------------------------
                RecipeList.Serialization(name.Text, ingridients.Text, description.Text);
                RecipeList qwerty = RecipeList.Deserialization();
                MessageBox.Show("Название: " + qwerty.Name + "\nИнгридиенты:\n" + qwerty.Ingridients, "\nОписание:\n" + qwerty.Description);
                // десериализация
                this.Close();
                //-----------------------------------------------------------------------------------------------------------------------------------------
            }
            else if (name.Text == "")
            {
                MessageBox.Show("Впишите название рецепта");
            }
            else if (ingridients.Text == "")
            {
                MessageBox.Show("Впишите ингридиенты");
            }
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
    }
}
