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
        int i;//Количество CheckBox'ов
        string pathToFile = Form1.pathToFile;
        CheckBox box; //Обьявляю для того, чтобы можно было использовать чекюоксы везде
        public EditByName(string Name, string Ingridients, string Descriprion)
        {
            InitializeComponent();
            description.ScrollBars = ScrollBars.Both;
            originalName = Name;// Нужно для поиска правильного обьекта
            name.Text = Name;
            description.Text = Descriprion;
            string ingrid = Ingridients;
            //Надо добавить выделение чекбоксов с ингридиентами
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
                    int boxTrue = 0;
                    foreach (CheckBox chbox in this.Controls.OfType<CheckBox>())
                    {
                        if (chbox.Checked)
                        {
                            boxTrue++;
                            MessageBox.Show("Ты выбрал " + chbox.Text);
                        }
                    }
                    if (boxTrue != 0) {
                        RecipeList RL = new RecipeList
                        {
                            Name = name.Text,
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
        private void EditByName_Load(object sender, EventArgs e)
        {
        }
    }
}
