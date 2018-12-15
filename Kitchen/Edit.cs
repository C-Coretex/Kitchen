using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitchen
{
    public partial class Edit : Form
    {
        int rowNumber;
        int rowIndex;
        string pathToFile = Form1.pathToFile;
        public Edit(int RowIndex, int RowNumber)
        {
            rowNumber = RowNumber - 1;
            rowIndex = RowIndex;
            BinaryFormatter formatter = new BinaryFormatter();
            RecipeList RL = new RecipeList();
            var objects = new List<RecipeList>();
            InitializeComponent();
            ingridients.ScrollBars = ScrollBars.Both;
            description.ScrollBars = ScrollBars.Both;
            using (Stream fs = File.Open(pathToFile + "Recipe.dat", FileMode.OpenOrCreate))
            {
                int a = 0;
                fs.Position = 0;
                while (fs.Position < fs.Length)
                {
                    a++;
                    objects.Add((RecipeList)formatter.Deserialize(fs));
                }
                name.Text = objects[rowNumber].Name;
                description.Text = objects[rowNumber].Description;
            }
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
                        if (a == rowNumber)
                        {
                            objects.Add(RL);
                            objects.Add((RecipeList)formatter.Deserialize(fs));
                            a++;
                            objects.Remove(objects[a]);
                        }
                        else
                        {
                            objects.Add((RecipeList)formatter.Deserialize(fs));
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
        private void Edit_Load(object sender, EventArgs e)
        {
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            RecipeList RL = new RecipeList
            {
                Name = name.Text,
                // Ingridients = ingridients.Text,
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
                    if (a == rowNumber)
                    {
                        objects.Add((RecipeList)formatter.Deserialize(fs));
                        objects.Remove(objects[a]);
                    }
                    else
                    {
                        objects.Add((RecipeList)formatter.Deserialize(fs));
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

        private void ingridients_TextChanged(object sender, EventArgs e)
        {
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
        }

        private void description_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
