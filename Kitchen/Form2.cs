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
        int rowIndex = 0;
        int rowNumber = 0;
        static public string saveMyIng;
        string pathToFile = Form1.pathToFile;
        public Form2()
        {
            InitializeComponent();
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Cursor = Cursors.WaitCursor;
            dataGridView.RowHeadersWidth = 20;
            dataGridView.AutoResizeColumns();
            //-----------------------------------------------------------------------------------------------------------------------------------------
            NewTable();
            for (int n = 0; n < 5; n++)
            {
                SendKeys.Send("{TAB}");
            }
            this.Cursor = Cursors.Default;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void Back_Click(object sender, EventArgs e)
        {
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

                            private void NewTable()
                            {
                                using (Stream fs = File.Open(Form1.pathToFile + "Recipe.dat", FileMode.OpenOrCreate))
                                {
                                   // try
                                    {
                                        BinaryFormatter formatter = new BinaryFormatter();

                                        RecipeList RL = new RecipeList();
                                        var objects = new List<RecipeList>();

                                        fs.Position = 0;
                                        string[] allIngridients = File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8);
                                        while (fs.Position < fs.Length)
                                        {
                                            objects.Add((RecipeList)formatter.Deserialize(fs));
                                        }
                                        foreach (RecipeList r in objects)
                                        {
                                            int n = dataGridView.Rows.Add();
                                            dataGridView.Rows[n].Cells[1].Value = r.Name;
                                                string[] subStr = r.Ingridients.Split(' ');
                                                for (uint i = 0; i < subStr.Length - 1; i++)
                                                {
                                                    string together = dataGridView.Rows[n].Cells["colIngridients"].Value + "\r " + allIngridients[Convert.ToInt16(subStr[i]) - 1];
                                                    dataGridView.Rows[n].Cells["colIngridients"].Value = together;
                                                }
                                            dataGridView.Rows[n].Cells[0].Value = n + 1;
                                        }
                                    }
                                  //  catch
                                    {
                                    }
                                }
                            }

        private void Find_Click(object sender, EventArgs e)
        {
            if (findText.Text != "")
            {
                bool contains = false;
                this.Cursor = Cursors.WaitCursor;

                    if (dataGridView.CurrentRow.Index == dataGridView.RowCount - 1)
                    {
                        dataGridView.Rows[0].Cells[1].Selected = true;
                    }
                for (int i = dataGridView.CurrentRow.Index + 1; i < dataGridView.RowCount; i++)
                {
                    string name = dataGridView.Rows[i].Cells[1].Value.ToString();
                    int cursor;
                    for (cursor = 0; cursor+findText.Text.Length <= name.Length; cursor++)
                    {
                        if (name.Substring(cursor, findText.Text.Length).Equals(findText.Text, StringComparison.InvariantCultureIgnoreCase))
                        {
                            contains = true;
                            SendKeys.Send("{TAB}");
                            SendKeys.Send("{TAB}");
                            SendKeys.Send("{TAB}");
                            dataGridView.Rows[0].Cells[1].Selected = true;
                            for (int n = 0; n < i;n++)
                            {
                                SendKeys.Send("{Enter}");
                            }
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

        private void FindText_Click(object sender, EventArgs e)
        {
        }

        private void FindText_TextChanged(object sender, EventArgs e)
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

        private void FindText_KeyDown(object sender, KeyEventArgs e)
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
           // try
            {
                rowIndex = dataGridView.CurrentCell.RowIndex;
                rowNumber = Convert.ToInt16(dataGridView.Rows[rowIndex].Cells[0].Value.ToString());
                Edit ed = new Edit(rowIndex, rowNumber);
                ed.StartPosition = FormStartPosition.Manual;
                ed.Location = this.Location;
                ed.ShowDialog();

                dataGridView.Rows.Clear();
                NewTable();
            }
          //  catch
            {
            }
        }

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rowIndex = e.RowIndex;
                ContextMenuStrip delMenu = new System.Windows.Forms.ContextMenuStrip();
                int pos = dataGridView.HitTest(e.X, e.Y).RowIndex;
                delMenu.Items.Add("Delete").Text = "Удалить";
                delMenu.Show(dataGridView, new Point(e.X+20, e.Y+30));

                //event menu click
                delMenu.ItemClicked += new ToolStripItemClickedEventHandler(delMenu_ItemClicked);
                
            }
        }

        private void delMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
                int rowNumber = Convert.ToInt16(dataGridView.Rows[rowIndex].Cells[0].Value.ToString());
                RecipeList RL = new RecipeList
                {
                    //Name = name,
                    // Ingridients = ingridients.Text,
                    //Description = description
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
                            objects.Remove(objects[a-1]);
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
            dataGridView.Rows.Clear();
            NewTable();
        }
    }
}
