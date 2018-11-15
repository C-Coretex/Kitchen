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
        static public int rowIndex = 0;
        static public int rowNumber = 0;
        static public string pathToFile = "";
        public Form2()
        {
            InitializeComponent();
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Cursor = Cursors.WaitCursor;
            // string o = System.AppDomain.CurrentDomain.BaseDirectory;
            //string pathToFile = @o;
            //РАБОТАЕТ ТОЛЬКО ПОСЛЕ ИНСТАЛЯТОРА(должно)
            pathToFile = @"C:\Users\valer\Desktop\Programming\Kitchen\";
            // StreamReader sr = new StreamReader(pathToFile + @"Text.txt", true);
            //testBox2.Text = sr.ReadToEnd();
            // sr.Close();
            // testBox2.ScrollBars = ScrollBars.Both;
            dataGridView.RowHeadersWidth = 20;
            dataGridView.AutoResizeColumns();
            //-----------------------------------------------------------------------------------------------------------------------------------------
            using (Stream fs = File.Open(pathToFile + "Recipe.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    RecipeList RL = new RecipeList();
                    var objects = new List<RecipeList>();

                    // int a = 0;
                    fs.Position = 0;
                    while (fs.Position < fs.Length)
                    {
                        //a++;
                        objects.Add((RecipeList)formatter.Deserialize(fs));
                        // MessageBox.Show("Название: " + objects[a - 1].Name + "\nИнгридиенты:\n" + objects[a - 1].Ingridients + "\nОписание:\n" + objects[a - 1].Description);
                    }
                    // dataGridView.DataSource = objects;
                    //dataGridView.Rows[n].Cells[0].Value = "aaa";
                    // dataGridView.Columns[0].HeaderText = "Название";
                    foreach (RecipeList r in objects)
                    {
                        int n = dataGridView.Rows.Add();
                        dataGridView.Rows[n].Cells[1].Value = r.Name;
                        dataGridView.Rows[n].Cells[2].Value = r.Ingridients;
                        dataGridView.Rows[n].Cells[0].Value = n + 1;
                    }
                }
                catch
                {
                }
            }
            this.Cursor = Cursors.Default;
            for (int n = 0; n < 5; n++)
            {
                SendKeys.Send("{TAB}");
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

        private void Find_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("" + dataGridView.CurrentRow.Index);
            if (findText.Text != "")
            {
                bool contains = false;
                this.Cursor = Cursors.WaitCursor;

                    if (dataGridView.CurrentRow.Index == dataGridView.RowCount - 1)
                    {
                       // dataGridView.ClearSelection();
                       // dataGridView.CurrentCell = null;
                        dataGridView.Rows[0].Cells[1].Selected = true;
                    }
                    
                for (int i = dataGridView.CurrentRow.Index+1; i < dataGridView.RowCount;i++)
                {
                    string name = dataGridView.Rows[i].Cells[1].Value.ToString();
                    int cursor;
                    for (cursor = 0; cursor+findText.Text.Length <= name.Length; cursor++)
                    {
                        if (name.Substring(cursor, findText.Text.Length) == findText.Text)
                        {
                           // MessageBox.Show("Ваш запрос: '" + findText.Text + "' найден");
                            //dataGridView.Rows[i].Selected = true;
                            contains = true;
                            SendKeys.Send("{TAB}");
                            SendKeys.Send("{TAB}");
                            SendKeys.Send("{TAB}");
                            for (int n = 0; n < i;n++)
                            {
                                SendKeys.Send("{Enter}");
                            }
                                //SendKeys.Send("{Enter}");
                            //for (int a = dataGridView.RowCount*3-)
                            break;
                        }
                    }
                    if (contains == true)
                    {
                        break;
                    }
                    }
                if (contains == false)
                {
                    MessageBox.Show("Слово: '" + findText.Text + "' НЕ найдено!");
                    dataGridView.Rows[0].Cells[1].Selected = true;
                }
                this.Cursor = Cursors.Default;
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
            }
        }

        private void AddRecept_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.StartPosition = FormStartPosition.Manual;
            f3.Location = this.Location;
            f3.ShowDialog();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                rowIndex = dataGridView.CurrentCell.RowIndex;
                rowNumber = Convert.ToInt16(dataGridView.Rows[rowIndex].Cells[0].Value.ToString());
                Edit ed = new Edit();
                ed.StartPosition = FormStartPosition.Manual;
                ed.Location = this.Location;
                ed.ShowDialog();
            }
            catch
            {
            }
        }
    }
}
