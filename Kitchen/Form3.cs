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
        int startLocation = 142;//Локация "генерирования" чекбокса (y)
        static public string name_ = "";
        int i;//Количество CheckBox'ов
        string pathToFile = Form1.pathToFile;
        CheckBox box; //Обьявляю для того, чтобы можно было использовать чекбоксы везде
        public Form3()
        {
            InitializeComponent();

            description.ScrollBars = ScrollBars.Both;
            string[] ingridients = (File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8));
            for (i = 0; i < ingridients.Length; i++)
            {
                box = new CheckBox(); //Create new checkBox
                box.Tag = i;//CheckBox (Tag 0-..)
                box.TabIndex = 8 + i;//Последовательность "выбора" через TAB
                box.Text = ingridients[i];
                box.AutoSize = true;
                box.Location = new Point(2, startLocation);
                startLocation += 25;
                this.Controls.Add(box);
            }
            //Увеличивает окно, если чекбоксов слишком много
            if (startLocation> 440)
            {
                this.Size = new Size(596, startLocation+50);
            }
        }

        private void saveExit_Click(object sender, EventArgs e)
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

            if (name.Text == "")
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
            else
            {
                //-----------------------------------------------------------------------------------------------------------------------------------------
                RecipeList.Serialization(name.Text, description.Text, ingr);
                this.Close();
                //-----------------------------------------------------------------------------------------------------------------------------------------
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

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить или изменить новый ингредиент будет НЕВОЗМОЖНО!!!\nХотите продолжить?", "ВНИМАНИЕ", MessageBoxButtons.YesNo);
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

