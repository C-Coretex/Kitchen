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
    public partial class Form2 : Form
    {
        static public string pathToFile = "";
        string line1 = "";
        public Form2()
        {
            InitializeComponent();
            // string o = System.AppDomain.CurrentDomain.BaseDirectory;
            //string pathToFile = @o;
            //РАБОТАЕТ ТОЛЬКО ПОСЛЕ ИНСТАЛЯТОРА(должно)
            pathToFile = @"C:\Users\valer\Desktop\Programming\Kitchen\";
            StreamReader sr = new StreamReader(pathToFile + @"Text.txt", true);
            testBox2.Text = sr.ReadToEnd();
            sr.Close();
            testBox2.ScrollBars = ScrollBars.Both;

            dataGridView.AutoResizeColumns();

            //-----------------------------------------------------------------------------------------------------------------------------------------
            using (Stream fs = File.Open(pathToFile + "Recipe.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    testBox2.Text = "";

                    RecipeList RL = new RecipeList();
                    var objects = new List<RecipeList>();

                    int a = 0;
                    fs.Position = 0;
                    while (fs.Position < fs.Length)
                    {
                        a++;
                        objects.Add((RecipeList)formatter.Deserialize(fs));
                       // MessageBox.Show("Название: " + objects[a - 1].Name + "\nИнгридиенты:\n" + objects[a - 1].Ingridients + "\nОписание:\n" + objects[a - 1].Description);
                    }
                    // int n = dataGridView.Rows.Add();
                    // dataGridView.DataSource = objects;
                    //dataGridView.Rows[n].Cells[0].Value = "aaa";
                    // dataGridView.Columns[0].HeaderText = "Название";
                    //dataGridView.Columns[1].HeaderText = "Ингридиенты";
                    // dataGridView.Columns[2].HeaderText = "Описание";
                    foreach (RecipeList r in objects)
                    {
                        int n = dataGridView.Rows.Add();
                        dataGridView.Rows[n].Cells[0].Value = r.Name;
                        testBox2.Text += ("Название: " + r.Name + "\n");
                        dataGridView.Rows[n].Cells[1].Value = r.Ingridients;
                        testBox2.Text += ("\nИнгридиенты:\n" + r.Ingridients);
                        dataGridView.Rows[n].Cells[2].Value = r.Description;
                        testBox2.Text += ("\nОписание:\n" + r.Description);
                    }
                }
                catch
                {
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void Back_Click(object sender, EventArgs e)
        {
          //  StreamWriter sw = new StreamWriter(pathToFile + @"Text.txt", false);
          //  line1 = testBox2.Text;
            //line1 = line1.Replace(" \t ", "");
           // line1 = line1.Replace(" \n ", "");
            //line1 = line1.Trim();
            //sw.WriteLine(line1);
           // sw.Close();

            Form1 f1 = new Form1();
            f1.StartPosition = FormStartPosition.Manual;
            f1.Location = this.Location;
            Hide();
            f1.ShowDialog();
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (findText == null)
            {
                label1.Text = "Найти по названию:";
            }
        }

        private void testBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void Find_Click(object sender, EventArgs e)
        {
            if (label1.Text != null)
            {
                if (testBox2.Text.Contains(findText.Text) && (findText.Text != "" && findText.Text != " "))
                {
                    int start = 0;
                    int len = findText.Text.Length;
                    string txt = findText.Text;
                    this.Cursor = Cursors.WaitCursor;
                    for (int i = 0; i < testBox2.Text.Length; i += 1)
                    {
                        testBox2.Select(i, len);
                        if (testBox2.SelectedText == txt)
                        {
                            start = testBox2.SelectionStart;
                        }
                    }
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Ваш запрос: '" + findText.Text + "' найден");
                    testBox2.Select(start, len);
                    SendKeys.Send("{Tab}");
                    testBox2.ScrollToCaret();
                }
                else if (findText.Text != " ")
                {
                    MessageBox.Show("Слово: '" + findText.Text + " НЕ найдено!");
                }
            }
        }

        private void findText_Click(object sender, EventArgs e)
        {
            if (label1 != null)
            {
                label1.Text = null;
            }
        }

        private void findText_TextChanged(object sender, EventArgs e)
        {
            if (label1 != null)
            {
                label1.Text = null;
            }
            if (findText.Text == "")
            {
                label1.Text = "Найти по названию";
            }
        }

        private void testBox2_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void findText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Find.PerformClick();
                SendKeys.Send("{Tab}");
            }
        }

        private void AddRecept_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.StartPosition = FormStartPosition.Manual;
            f3.Location = this.Location;
            f3.ShowDialog();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
