using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitchen
{
    public partial class EditByName : Form
    {
        string originalName;
        string pathToFile = Form1.pathToFile;
        public EditByName(string Name, string Ingridients, string Descriprion)
        {
            InitializeComponent();
            ingridients.ScrollBars = ScrollBars.Both;
            description.ScrollBars = ScrollBars.Both;
            originalName = Name;// Нужно для поиска правильного обьекта
            name.Text = Name;
            ingridients.Text = Ingridients;
            description.Text = Descriprion;
        }

        private void saveDelete_Click(object sender, EventArgs e)
        {
            if (name.Text != "" && ingridients.Text != "" && description.Text != "")
            {
                RecipeList RL = new RecipeList
                {
                    Name = name.Text,
                    //Ingridients = ingridients.Text,
                    Description = description.Text
                };
                var objects = new List<RecipeList>();
                int a = 0;
                using (FileStream fs = new FileStream(pathToFile + "Recipe.dat", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    fs.Position = 0;

                    while (fs.Position < fs.Length)
                    {
                        objects.Add((RecipeList)formatter.Deserialize(fs));
                        if (objects[a].Name == originalName)
                        {
                            objects.Remove(objects[a]);
                            objects.Add(RL);
                            a++;
                        }
                        else
                        {
                            a++;
                        }
                    }
                }
                System.IO.File.WriteAllText(pathToFile + "Recipe.dat", string.Empty);
                using (FileStream fs = new FileStream(pathToFile + "Recipe.dat", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    for (int i = 0; i < a; i++)
                    {
                        formatter.Serialize(fs, objects[i]);
                    }
                }
                this.Close();
            }
        }

            private void delete_Click(object sender, EventArgs e)
        {
            RecipeList RL = new RecipeList
            {
                Name = name.Text,
                //Ingridients = ingridients.Text,
                Description = description.Text
            };
            var objects = new List<RecipeList>();
            int a = 0;
            using (FileStream fs = new FileStream(pathToFile + "Recipe.dat", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                fs.Position = 0;
                while (fs.Position < fs.Length)
                {
                    objects.Add((RecipeList)formatter.Deserialize(fs));
                    if (objects[a].Name == name.Text)
                    {
                        objects.Remove(objects[a]);
                    }
                    a++;
                }
            }
            System.IO.File.WriteAllText(pathToFile + "Recipe.dat", string.Empty);
            using (FileStream fs = new FileStream(pathToFile + "Recipe.dat", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                for (int i = 0; i < a - 1; i++)
                {
                    formatter.Serialize(fs, objects[i]);
                }
            }
            this.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
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
