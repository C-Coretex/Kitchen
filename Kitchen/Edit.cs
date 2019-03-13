using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace Kitchen
{
    public partial class Edit : Form
    {
        string ingr = "";
        int startLocation = 115;//Локация "генерирования" чекбокса (y)
        int rowNumber;
        int rowIndex;
        string name = "";
        string description = "";
        string imageDirection = "";
        string category = "";
        string pathToFile = Form1.pathToFile;
        int i;//Количество CheckBox'ов
        CheckBox box; //Обьявляю для того, чтобы можно было использовать чекюоксы везде

        public Edit(int RowIndex, int RowNumber)
        {
            InitializeComponent();
            this.Cursor = Cursors.WaitCursor;
            rowNumber = RowNumber - 1;
            rowIndex = RowIndex;
            BinaryFormatter formatter = new BinaryFormatter();
            RecipeList RL = new RecipeList();
            var objects = new List<RecipeList>();

            string[] ingridients = (File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8));
            try
            {
                if (ingridients[0] == "" || ingridients[0] == " " || ingridients[0] == null)
                    ingridients = ingridients.Skip(1).ToArray();
            }
            catch { }
            List<string> firstLetters = new List<string>();
            List<string> allIngridients = new List<string>();
            foreach (string a in ingridients)
            {
                try
                {
                    if (a != "" && a != null && a != " ")
                    {
                        allIngridients.Add(a.ToString());
                        if (!firstLetters.Contains(a.Substring(0, 1)))
                        {
                            firstLetters.Add(a.Substring(0, 1));
                        }
                    }
                }
                catch { }
            }
            firstLetters.Sort();
            allIngridients.Sort();
            foreach (string a in firstLetters)
            {
                comboBox1.Items.Add(a);
            }
            foreach (string a in allIngridients)
            {
                comboBoxSearch.Items.Add(a);
            }

            string[] categoryArray = (File.ReadAllLines(pathToFile + @"Cccategory.txt", Encoding.UTF8));
            foreach (string a in categoryArray)
            {
                comboBox2.Items.Add(a);
            }
            comboBox2.Sorted = true;

            string ingrid;
            string count;
            string type;
            string category;
            using (Stream fs = File.Open(pathToFile + "Recipe.dat", FileMode.OpenOrCreate))
            {
                fs.Position = 0;
                while (fs.Position < fs.Length)
                {
                    objects.Add((RecipeList)formatter.Deserialize(fs));
                }
                name = objects[rowNumber].Name;
                description = objects[rowNumber].Description;
                imageDirection = objects[rowNumber].ImageDirection;
                ingrid = objects[rowNumber].Ingridients;
                count = objects[rowNumber].Count;
                type = objects[rowNumber].Type;
                category = objects[rowNumber].Category;
            }

            string[] subStr = ingrid.Split(' ');
            string[] subCount = count.Split(' ');
            string[] subType = type.Split('|');
            for (int i = 0; i < subStr.Length - 1; i++)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[1].Value = ingridients[Convert.ToInt16(subStr[i])-1];
                dataGridView1.Rows[n].Cells[2].Value = subCount[i];
                dataGridView1.Rows[n].Cells[3].Value = subType[i];
                comboBoxSearch.Items.Remove(ingridients[Convert.ToInt16(subStr[i]) - 1]);
                comboBox2.SelectedItem = category;
            }
            this.Text = name + " - редактирование";

            this.Cursor = Cursors.Default;
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
                try
                {
                    backgroundWorker1.RunWorkerAsync(); //TODO: Сохранение в директорию "C:\Program Files"
                }
                catch
                {
                    backgroundWorker1.RunWorkerAsync();
                }
                comboBoxSearch.Items.Add(AddCheckBox.name);
                comboBoxSearch.Sorted = true;
            }
        }

        private void comboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells["colIngridients"].Value = comboBoxSearch.SelectedItem.ToString();
            comboBoxSearch.Items.Remove(comboBoxSearch.SelectedItem);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] ingrid = (File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8));
            try
            {
                if (ingrid[0] == "" || ingrid[0] == " " || ingrid[0] == null)
                    ingrid = ingrid.Skip(1).ToArray();
            }
            catch { }

            startLocation = 115;
            foreach (CheckBox chbox in this.Controls.OfType<CheckBox>())
            {
                if (chbox.Checked == true)
                {
                    ingr = chbox.Text + " ";
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
                bool repeat = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[1].Value.ToString() == ingridients[i])
                    {
                        repeat = true;
                    }
                }
                if (repeat == false)
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
            }
            //Увеличивает окно, если чекбоксов слишком много
            if (startLocation > 440)
            {
                this.Size = new Size(596, startLocation + 50);
            }
        }

        private void saveExit_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string type = "";
            string count = "";
            int boxTrue = 0;
            string[] ingridients = (File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8));
            //Если начальная строчка пустая - удалить её из массива
            try
            {
                if (ingridients[0] == "" || ingridients[0] == " " || ingridients[0] == null)
                    ingridients = ingridients.Skip(1).ToArray();
            }
            catch { }
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int n = 0;
                foreach (string i in ingridients)
                {
                    n++;
                    if (i == row.Cells[1].Value.ToString())
                    {
                        boxTrue++;
                        ingr += n + " ";
                        string r = "";
                        string rr = "";
                        try
                        {
                            r = row.Cells[2].Value.ToString().Trim();
                        }
                        catch
                        {
                            r = "---";
                        }
                        try
                        {
                            rr = row.Cells[3].Value.ToString();
                        }
                        catch
                        {
                            rr = "---";
                        }
                        count += r + " ";
                        type += rr + "|";
                        break;
                    }
                }

            }

            if (boxTrue == 0)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Выберите ингредиенты");
            }
            else
            {
                try
                {
                    if (comboBox2.SelectedItem == null)
                        comboBox2.SelectedIndex = 0;

                    category = comboBox2.SelectedItem.ToString();
                    this.Cursor = Cursors.Default;
                    Form2.OriginalName = name;
                    Form2.OriginalDescription = description;
                    //-----------------------------------------------------------------------------------------------------------------------------------------
                    AddName2 AD = new AddName2(ingr, count, type, name, description, rowNumber, imageDirection, category);
                    AD.StartPosition = FormStartPosition.Manual;
                    AD.Location = this.Location;
                    this.Hide();
                    AD.ShowDialog();
                    this.Close();
                    //-----------------------------------------------------------------------------------------------------------------------------------------
                }
                catch
                {
                    category = "";
                    this.Cursor = Cursors.Default;
                    Form2.OriginalName = name;
                    Form2.OriginalDescription = description;
                    //-----------------------------------------------------------------------------------------------------------------------------------------
                    AddName2 AD = new AddName2(ingr, count, type, name, description, rowNumber, imageDirection, category);
                    AD.StartPosition = FormStartPosition.Manual;
                    AD.Location = this.Location;
                    this.Hide();
                    AD.ShowDialog();
                    this.Close();
                    //-----------------------------------------------------------------------------------------------------------------------------------------
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
                {
                    dataGridView1.BeginEdit(true);
                }
                else if (e.ColumnIndex == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Удалить этот игредиент из таблицы?", "Мы удаляем?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        comboBoxSearch.Items.Add(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                        comboBoxSearch.Sorted = true;
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                        comboBoxSearch.Items.Add(AddCheckBox.name);
                        comboBoxSearch.Sorted = true;
                    }
                }
            }
            catch
            {
            }
        }

        private void Edit_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (CheckBox chbox in this.Controls.OfType<CheckBox>())
            {
                if (chbox.Checked == true)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells["colIngridients"].Value = chbox.Text;
                    comboBoxSearch.Items.Remove(chbox.Text);
                    chbox.Checked = false;
                    chbox.Visible = false;
                    chbox.Enabled = false;
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] ingridientsFile = (File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8));
            string ing = "";
            for (int a = 0; a< ingridientsFile.Count(); a++)
            {
                ing += ingridientsFile[a] + "\r";
            }
            bool exists = Directory.Exists(@"C:\asd\");
            if (!exists)
            {
                Directory.CreateDirectory(@"C:\RecipeBackup");

            }
            File.WriteAllText(@"C:\RecipeBackup\Ingridients.txt", String.Empty);
            File.WriteAllText(@"C:\RecipeBackup\Ingridients.txt", ing.Substring(0, ing.Length - 1));
        }

        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить новую категорию будет НЕВОЗМОЖНО!!!\nХотите продолжить?", "ВНИМАНИЕ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                AddCategory aC = new AddCategory();
                aC.StartPosition = FormStartPosition.Manual;
                aC.Location = this.Location;
                aC.ShowDialog();
                try
                {
                    backgroundWorker2.RunWorkerAsync(); //TODO: Сохранение в директорию "C:\Program Files"
                }
                catch
                {
                    backgroundWorker2.RunWorkerAsync();
                }
                comboBox2.Items.Add(AddCategory.categoryName);
                comboBox2.Sorted = true;
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] categoryFile = (File.ReadAllLines(pathToFile + @"Cccategory.txt", Encoding.UTF8));
            string cat = "";
            for (int a = 0; a < categoryFile.Count(); a++)
            {
                cat += categoryFile[a] + "\r";
            }
            bool exists = Directory.Exists(@"C:\RecipeBackup");
            if (!exists)
            {
                Directory.CreateDirectory(@"C:\RecipeBackup");
            }
            File.WriteAllText(@"C:\RecipeBackup\Cccategory.txt", String.Empty);
            File.WriteAllText(@"C:\RecipeBackup\Cccategory.txt", cat.Substring(0, cat.Length - 1));
        }

        private void Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Хочешь отменить изменения?", "Отменить изменения?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                e.Cancel = true;
        }
    }
}