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
    public partial class Edit : Form
    {
        int boxTrue = 0;
        int rowNumber;
        int rowIndex;
        string pathToFile = Form1.pathToFile;
        int i;//Количество CheckBox'ов
        CheckBox box; //Обьявляю для того, чтобы можно было использовать чекюоксы везде
        public Edit(int RowIndex, int RowNumber)
        {
            rowNumber = RowNumber - 1;
            rowIndex = RowIndex;
            BinaryFormatter formatter = new BinaryFormatter();
            RecipeList RL = new RecipeList();
            var objects = new List<RecipeList>();
            InitializeComponent();
            description.ScrollBars = ScrollBars.Both;

            string ingrid;
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
                ingrid = objects[rowNumber].Ingridients;
            }

            string[] ingridients = (File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8));
            int startLocation = 142;//Локация "генерирования" чекбокса (y)
            int chboxTrueCount = 0;
            for (i = 0; i < ingridients.Length; i++)
            {
                try
                {
                    if (i == Convert.ToInt16(ingrid.Substring(chboxTrueCount, 1)))
                    {
                        this.box.Checked = true;
                        chboxTrueCount++;
                    }
                }
                catch
                {
                }
                box = new CheckBox(); //Create new checkBox
                box.Tag = i;//CheckBox (Tag 0-..)
                box.TabIndex = 8 + i;//Последовательность "выбора" через TAB
                box.Text = ingridients[i];
                box.AutoSize = true;
                box.Location = new Point(2, startLocation);
                startLocation += 25;
                this.Controls.Add(box);
            }
            try
            {
                if (i == Convert.ToInt16(ingrid.Substring(chboxTrueCount, 1)))
                {
                    this.box.Checked = true;
                    chboxTrueCount++;
                }
            }
            catch
            {
            }
        }
        private void saveDelete_Click(object sender, EventArgs e)
        {
            if (name.Text != "" && description.Text != "")
            {
                string ingr = "";
                int boxTrue = 0;
                int n = 0;
                foreach (CheckBox chbox in this.Controls.OfType<CheckBox>())
                {
                    n++;
                    if (chbox.Checked)
                    {
                        boxTrue++;
                        MessageBox.Show("Ты выбрал " + chbox.Text);
                        ingr += n;
                    }
                }
                if (boxTrue != 0)
                {
                    RecipeList RL = new RecipeList
                    {
                        Name = name.Text,
                        Ingridients = ingr,
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
            }
            else if (name.Text == "")
            {
                MessageBox.Show("Впишите название рецепта");
            }
            else if (boxTrue == 0)
            {
                MessageBox.Show("Выберите ингридиенты");
            }
            else if (description.Text == "")
            {
                MessageBox.Show("Впишите описание рецепта");
            }
        }
        private void Edit_Load(object sender, EventArgs e)
        {
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            RecipeList RL = new RecipeList
            {
                Name = name.Text,
                // Ingridients = ingridients.Text,
                Description = description.Text
            };
            List<RecipeList> objects = new List<RecipeList>();
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
            File.WriteAllText(pathToFile + "Recipe.dat", string.Empty);
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
