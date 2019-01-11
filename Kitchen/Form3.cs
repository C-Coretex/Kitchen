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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Kitchen
{
    public partial class Form3 : Form
    {
        int startLocation = 100;//Локация "генерирования" чекбокса (y)
        static public string name_ = "";
        string nname;
        string ddescription;
        string ingr = "";
        int i;//Количество CheckBox'ов
        string pathToFile = Form1.pathToFile;
        CheckBox box; //Обьявляю для того, чтобы можно было использовать чекбоксы везде
        public Form3(string Name, string Description)
        {
            InitializeComponent();
                  dataGridView1.RowHeadersWidth = 20;
            nname = Name;
            ddescription = Description;
            string[] ingridients = (File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8));
            //for (i = 0; i < ingridients.Length; i++)
            //{
            //    box = new CheckBox(); //Create new checkBox
            //    box.Tag = i;//CheckBox (Tag 0-..)
            //    box.TabIndex = 8 + i;//Последовательность "выбора" через TAB
            //    box.Text = ingridients[i];
            //    box.AutoSize = true;
            //    box.Location = new Point(2, startLocation);
            //    startLocation += 25;
            //    this.Controls.Add(box);
            //}
            ////Увеличивает окно, если чекбоксов слишком много
            //if (startLocation> 440)
            //{
            //    this.Size = new Size(596, startLocation+50);
            //}
            //-----------------------------------------------------------------------------------------------------------------------------------------
            List<string> firstLetters = new List<string>();
            foreach (string a in ingridients)
            {
                if (firstLetters.Contains(a.Substring(0, 1)))
                { }
                else
                {
                    firstLetters.Add(a.Substring(0, 1));
                    //comboBox1.Items.Add(a.Substring(0, 1));
                }
            }
            firstLetters.Sort();
            foreach (string a in firstLetters)
            {
                comboBox1.Items.Add(a);
            }
        }

        private void saveExit_Click(object sender, EventArgs e)
        {
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

            if (boxTrue == 0)
            {
                MessageBox.Show("Выберите ингридиенты");
            }
            else
            {
                //-----------------------------------------------------------------------------------------------------------------------------------------
                RecipeList.Serialization(nname, ddescription, ingr);
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

        private void Exit_Click(object sender, EventArgs e) => this.Close();

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить новый ингредиент будет НЕВОЗМОЖНО!!!\nХотите продолжить?", "ВНИМАНИЕ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                AddCheckBox aCB = new AddCheckBox();
                aCB.StartPosition = FormStartPosition.Manual;
                aCB.Location = this.Location;
                aCB.ShowDialog();

                //    box = new CheckBox(); //Create new checkBox
                //    box.Tag = i;//CheckBox (Tag 0-..)
                //    box.TabIndex = 8 + i;//Последовательность "выбора" через TAB
                //    box.Text = AddCheckBox.name;
                //    box.AutoSize = true;
                //    box.Location = new Point(2, startLocation);
                //    startLocation += 25;
                //    this.Controls.Add(box);
                //    this.box.Checked = true;

                //    this.Size = new Size(596, startLocation + 50);
            }
            //if (startLocation> 440)
            //{
            //    this.Size = new Size(596, startLocation+50);
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] ingrid = (File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8));
            startLocation = 100;
            foreach (CheckBox chbox in this.Controls.OfType<CheckBox>())
            {
                if (chbox.Checked == true)
                {
                    ingr = chbox.Text + " ";
                }
                else
                {
                    // ingr.Split(" ");
                }

                chbox.Visible = false;
                chbox.Enabled = false;
            }
            List<string> ingridients = new List<string>();
            foreach (string a in ingrid)
            {
                if (a.Substring(0, 1) == comboBox1.Text)
                {
                    ingridients.Add(a);
                }
            }
            for (i = 0; i < ingridients.Count; i++)
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
            if (startLocation > 440)
            {
                this.Size = new Size(596, startLocation + 50);
            }
        }

        private void Form3_MouseLeave(object sender, EventArgs e)
        {
            foreach (CheckBox chbox in this.Controls.OfType<CheckBox>())
            {
                if (chbox.Checked == true)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells["colIngridients"].Value = chbox.Text;
                    chbox.Checked = false;
                }
            }
        }
    }
}

