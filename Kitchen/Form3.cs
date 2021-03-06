﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Kitchen
{
    public partial class Form3 : Form
    {
        int startLocation = 115;//Локация "генерирования" чекбокса (y)
        string ingr = "";
        int i;//Количество CheckBox'ов
        string pathToFile = Form1.pathToFile;
        CheckBox box; //Обьявляю для того, чтобы можно было использовать чекбоксы везде
        public Form3()
        {
            InitializeComponent();
            this.Cursor = Cursors.WaitCursor;
            string[] ingridients = (File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8));
            List<string> firstLetters = new List<string>();
            List<string> allIngridients = new List<string>();
            foreach (string a in ingridients)
            {
                try
                {
                    if (a != "" && a!=" " && a!= null)
                    {
                        allIngridients.Add(a.ToString());
                        if (!firstLetters.Contains(a.Substring(0, 1)))
                        {
                            firstLetters.Add(a.Substring(0, 1));
                        }
                    }
                }
                catch { }
            }//Changed
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

            string[] category = (File.ReadAllLines(pathToFile + @"Cccategory.txt", Encoding.UTF8));
            foreach (string a in category)
            {
                comboBox2.Items.Add(a);
            }
            firstLetters.Sort();
            comboBox2.Sorted = true;


            this.Cursor = Cursors.Default;
        }

        private void saveExit_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string type = "";
            string count = "";
            int boxTrue = 0;
            string[] ingridients = (File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8));
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
                MessageBox.Show("Выберите ингридиенты");
            }
            else
            {
                try
                {
                    if (comboBox2.SelectedItem == null)
                        comboBox2.SelectedIndex = 0;

                    this.Cursor = Cursors.Default;
                    //-----------------------------------------------------------------------------------------------------------------------------------------
                    AddName AD = new AddName(ingr, count, type, comboBox2.SelectedItem.ToString());
                    AD.StartPosition = FormStartPosition.Manual;
                    AD.Location = this.Location;
                    this.Hide();
                    AD.ShowDialog();
                    this.Close();
                    //-----------------------------------------------------------------------------------------------------------------------------------------
                }
                catch
                {
                    this.Cursor = Cursors.Default;
                    //-----------------------------------------------------------------------------------------------------------------------------------------
                    AddName AD = new AddName(ingr, count, type, "");
                    AD.StartPosition = FormStartPosition.Manual;
                    AD.Location = this.Location;
                    this.Hide();
                    AD.ShowDialog();
                    this.Close();
                    //-----------------------------------------------------------------------------------------------------------------------------------------
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e) => this.Close();

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] ingrid = (File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8));
            startLocation = 115;
            foreach (CheckBox chbox in this.Controls.OfType<CheckBox>())
            {
                chbox.Visible = false;
                chbox.Enabled = false;
            }
            List<string> ingridients = new List<string>();
            foreach (string a in ingrid)
            {
                if (a != "" && a != null && a!=" ")
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
                    }
                }
            }
            catch
            {
            }
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
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

        private void comboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells["colIngridients"].Value = comboBoxSearch.SelectedItem.ToString();
                comboBoxSearch.Items.Remove(comboBoxSearch.SelectedItem);
            }
            catch
            {
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
            bool exists = Directory.Exists(@"C:\RecipeBackup");
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

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Хочешь отменить изменения?", "Отменить изменения?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                e.Cancel = true;
        }
    }
}