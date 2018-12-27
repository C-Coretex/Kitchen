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
        int startLocation = 142;//Локация "генерирования" чекбокса (y)
        static public string name_ = "";
        int boxTrue = 0;
        int rowNumber;
        int rowIndex;
        string pathToFile = Form1.pathToFile;
        int i;//Количество CheckBox'ов
        CheckBox box; //Обьявляю для того, чтобы можно было использовать чекюоксы везде
        public Edit(int RowIndex, int RowNumber)
        {
            InitializeComponent();

            rowNumber = RowNumber - 1;
            rowIndex = RowIndex;
            BinaryFormatter formatter = new BinaryFormatter();
            RecipeList RL = new RecipeList();
            var objects = new List<RecipeList>();
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
            string[] ingridients = File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8);
            int chboxTrueCount = 0;
            string[] subStr = ingrid.Split(' ');
            int n = 0;
            for (i = 1; i <= ingridients.Length + 1; i++)
            {
                 try
                {
                    if (i - 1 == Convert.ToInt16(subStr[n]))
                    {
                        n++;
                        this.box.Checked = true;
                        chboxTrueCount++;
                    }
                }
                 catch
                {
                }
                if (i - 1 < ingridients.Length)
                { 
                    box = new CheckBox(); //Create new checkBox
                    box.Tag = i;//CheckBox (Tag 0-..)
                    box.TabIndex = 8 + i;//Последовательность "выбора" через TAB
                    box.Text = ingridients[i - 1];
                    box.AutoSize = true;
                    box.Location = new Point(2, startLocation);
                    startLocation += 25;
                    this.Controls.Add(box);
                }
            }

            if (startLocation > 440)
            {
                this.Size = new Size(596, startLocation + 50);
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
                            ingr += n + " ";
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
                    }
                  this.Close();
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



        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить новый ингредиент будет НЕВОЗМОЖНО!!!\nХотите продолжить?", "ВНИМАНИЕ",  MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                AddCheckBox aCB = new AddCheckBox();
                aCB.StartPosition = FormStartPosition.Manual;
                aCB.Location = this.Location;
                aCB.ShowDialog();

                box = new CheckBox(); //Create new checkBox
                box.Tag = i;//CheckBox (Tag 0-..)
                box.TabIndex = 8 + i;//Последовательность "выбора" через TAB
                box.Text = name_;
                box.AutoSize = true;
                box.Location = new Point(2, startLocation);
                startLocation += 25;
                this.Controls.Add(box);
                this.box.Checked = true;
            }
        }
    }
}
