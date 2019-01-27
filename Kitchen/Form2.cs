using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace Kitchen
{
    public partial class Form2 : Form
    {
        int rowIndex = 0;
        int rowNumber = 0;
        static public string saveMyIng;
        string pathToFile = Form1.pathToFile;
        static public string OriginalName = "";
        static public string OriginalDescription = "";
        static public bool deleted = false;
        public Form2()
        {
            InitializeComponent();
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Cursor = Cursors.WaitCursor;
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


                dataGridView.Rows.Clear();
                NewTable();
            backgroundWorker1.RunWorkerAsync();
        }

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rowIndex = e.RowIndex;
                ContextMenuStrip delMenu = new System.Windows.Forms.ContextMenuStrip();
                int pos = dataGridView.HitTest(e.X, e.Y).RowIndex;
                delMenu.Items.Add("Delete").Text = "Удалить";
                try
                {
                    dataGridView.Rows[e.RowIndex].Selected = true;
                }
                catch
                {
                }
                delMenu.Show(dataGridView, new Point(e.Y, e.X));

                //event menu click
                delMenu.ItemClicked += new ToolStripItemClickedEventHandler(delMenu_ItemClicked);

            }
        }

        private void delMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int rowNumber = Convert.ToInt16(dataGridView.Rows[rowIndex].Cells[0].Value.ToString());
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
                        objects.Remove(objects[a - 1]);
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
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                rowIndex = dataGridView.CurrentCell.RowIndex;
                rowNumber = Convert.ToInt16(dataGridView.Rows[rowIndex].Cells[0].Value.ToString());
                Edit ed = new Edit(rowIndex, rowNumber);
                ed.StartPosition = FormStartPosition.Manual;
                ed.Location = this.Location;
                ed.ShowDialog();

                dataGridView.Rows.Clear();
                NewTable();
                try
                {
                    backgroundWorker2.RunWorkerAsync(); //TODO: Сохранение в директорию "C:\Program Files"
                }
                catch
                {
                   backgroundWorker2.RunWorkerAsync();
                }
            }
            catch
            {
            }
        }

        #region Чё-то, что происходит при СОЗДАНИИ рецепта
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
                BinaryFormatter formatter = new BinaryFormatter();
                var objects = new List<RecipeList>();
                using (Stream fs = File.Open(pathToFile + "Recipe.dat", FileMode.OpenOrCreate))
                {
                    fs.Position = 0;
                    while (fs.Position < fs.Length)
                    {
                        objects.Add((RecipeList)formatter.Deserialize(fs));
                    }
                }
                var objectsBackup = new List<RecipeList>();
                bool exists = System.IO.Directory.Exists(@"C:\asd\");
                if (!exists)
                {
                    Directory.CreateDirectory(@"C:\RecipeBackup");

                }
                using (Stream fs = File.Open(@"C:\RecipeBackup\" + "RecipeBackup.dat", FileMode.OpenOrCreate))
                {
                    fs.Position = 0;
                    while (fs.Position < fs.Length)
                    {
                        objectsBackup.Add((RecipeList)formatter.Deserialize(fs));
                    }
                }

                for (int i = 0; i < objects.Count; i++)
                {
                    bool equals = false;
                    foreach (var obB in objectsBackup)
                    {
                        if (objects[i].Description == obB.Description && objects[i].Name == obB.Name)
                        {
                            equals = true;
                            break;
                        }
                    }
                    if (equals == false)
                    {
                        RecipeList.Serialization2(objects[i].Name, objects[i].Description, objects[i].Ingridients, objects[i].Count, objects[i].Type, "");
                    }
                }
        }
        #endregion

        #region Чё-то, что происходит при ИЗМЕНЕНИИ рецепта
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            //Нужен OriginalDescription && OriginalName
            if (deleted == false)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                var objects = new List<RecipeList>();
                using (Stream fs = File.Open(pathToFile + "Recipe.dat", FileMode.OpenOrCreate))
                {
                    fs.Position = 0;
                    while (fs.Position < fs.Length)
                    {
                        objects.Add((RecipeList)formatter.Deserialize(fs));
                    }
                }

                var objectsBackup = new List<RecipeList>();
                bool exists = System.IO.Directory.Exists(@"C:\asd\");
                if (!exists)
                {
                    Directory.CreateDirectory(@"C:\RecipeBackup");

                }
                // int editedRecepieNumber = 0;
                using (Stream fs = File.Open(@"C:\RecipeBackup\" + "RecipeBackup.dat", FileMode.OpenOrCreate))
                {
                    int a = 0;
                    fs.Position = 0;
                    while (fs.Position < fs.Length)
                    {
                        a++;
                        objectsBackup.Add((RecipeList)formatter.Deserialize(fs));
                        if (objectsBackup[a-1].Name == OriginalName && objectsBackup[a-1].Description == OriginalDescription)
                        {
                            objectsBackup.RemoveAt(a);
                            //editedRecepieNumber = a;
                        }
                    }
                }

                for (int i = 0; i < objects.Count; i++)
                {
                    bool equals = false;
                    foreach (var obB in objectsBackup)
                    {
                        if (objects[i].Description == obB.Description && objects[i].Name == obB.Name)
                        {
                            equals = true;
                            break;
                        }
                    }
                    if (equals == false)
                    {
                        RecipeList.Serialization2(objects[i].Name, objects[i].Description, objects[i].Ingridients, objects[i].Count, objects[i].Type, "");
                    }
                }
            }
            deleted = false;
            OriginalDescription = "";
            OriginalName = "";
        }
        #endregion
    }
}