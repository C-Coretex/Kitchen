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
        string sname;
        string singridients;
        string sdescription;

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
                sname = name.Text;
                singridients = ingridients.Text;
                sdescription = description.Text;
                RecipeList RL = new RecipeList
                {
                    Name = sname,
                    Ingridients = singridients,
                    Description = sdescription
                };
                // создаем объект BinaryFormatter
                BinaryFormatter formatter = new BinaryFormatter();
                // получаем поток, куда будем записывать сериализованный объект
                using (FileStream fs = new FileStream(Form2.pathToFile + "Recipe.dat", FileMode.Append))
                {
                    MessageBox.Show("Объект сериализован");
                    formatter.Serialize(fs, RL);
                }
                // десериализация
                using (FileStream fs = new FileStream(Form2.pathToFile + "Recipe.dat", FileMode.Open))
                {
                    RecipeList newRL = (RecipeList)formatter.Deserialize(fs);
                    MessageBox.Show("Объект десериализован");
                    MessageBox.Show("Название: " +  RL.Name + "\nИнгридиенты:\n" + RL.Ingridients + "\nОписание:\n" + RL.Description);
                }
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
    }
}
