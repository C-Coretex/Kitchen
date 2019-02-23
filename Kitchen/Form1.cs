using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace Kitchen
{
    public partial class Form1 : Form
    {
        System.Timers.Timer timer = new System.Timers.Timer(1000 * 60 * 10);
        string ingrTrue = "";
        int i;//Количество CheckBox'ов
        CheckBox box; //Обьявляю для того, чтобы можно было использовать чекбоксы ВЕЗДЕЕЕЕЕЕЕЕЕЕЕ
        static public string pathToFile = "";
        bool findTextChanged = false;
        public Form1()
        {
            InitializeComponent();
            this.Cursor = Cursors.WaitCursor;

            #region 1-st TAB
            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            // string o = System.AppDomain.CurrentDomain.BaseDirectory;
            //pathToFile = @o + "\";
            //РАБОТАЕТ ТОЛЬКО ПОСЛЕ ИНСТАЛЯТОРА(должно)
            pathToFile = @"C:\Users\valer\OneDrive\Desktop\Programming\Kitchen\";
            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            FileStream fs = new FileStream(pathToFile + "Ingridients.txt", FileMode.OpenOrCreate);
            fs.Close();
            #region Interface setting
            FindRecepts.TabStop = false;
            FindRecepts.FlatStyle = FlatStyle.Flat;
            FindRecepts.FlatAppearance.BorderSize = 0;
            BrowseRecepts.TabStop = false;
            BrowseRecepts.FlatStyle = FlatStyle.Flat;
            BrowseRecepts.FlatAppearance.BorderSize = 0;
            WhatsHappening.TabStop = false;
            WhatsHappening.FlatStyle = FlatStyle.Flat;
            WhatsHappening.FlatAppearance.BorderSize = 0;
            #endregion 
            string[] ingridients = (File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8));
            List<string> firstLetters = new List<string>();
            List<string> allIngridients = new List<string>();
            foreach (string a in ingridients)
            {
                allIngridients.Add(a.ToString());
                if (!firstLetters.Contains(a.Substring(0, 1)))
                    firstLetters.Add(a.Substring(0, 1));
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
            //metroTabControl1.SelectTab(0);
            #endregion

            this.Cursor = Cursors.Default;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.CenterToScreen();
            dataGridViewSQL.RowHeadersWidth = 20;
            dataGridViewSQL.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            timer.AutoReset = true; // the key is here so it repeats
            timer.Elapsed += timer_elapsed;
            timer.Start();
        }

        #region 1-st TAB entrails
        private void WhatsHappening_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.google.com/document/d/1amQcHizBYU3zBE8kxdD8qqusnPvJHRfP69d5dyJaur8/edit?usp=sharing");
        }

        private void comboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells["colIngridients"].Value = comboBoxSearch.SelectedItem.ToString();
            comboBoxSearch.Items.Remove(comboBoxSearch.SelectedItem);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string[] ingrid = (File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8));
            int startLocation = 75;
            foreach (CheckBox chbox in this.Controls.OfType<CheckBox>())
            {
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
                    box.BringToFront();
                }
            }
            //Увеличивает окно, если чекбоксов слишком много
            if (startLocation > 220)
            {
                this.Size = new Size(596, startLocation + 50);
            }
        }

        private void FindRecepts_Click_1(object sender, EventArgs e)
        {
            ingrTrue = "";
            string ingrTrueInt = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                ingrTrue += row.Cells[1].Value.ToString() + " ";
            }
            string[] ingridients = (File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8));
            uint n = 0;
            foreach (string ing in ingridients)
            {
                n++;
                if (ingrTrue.Contains(ing))
                    ingrTrueInt += n + " ";
            }
            Find find = new Find(ingrTrueInt);
            find.StartPosition = FormStartPosition.Manual;
            find.Location = this.Location;
            find.ShowDialog();
        }

        private void BrowseRecepts_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.StartPosition = FormStartPosition.Manual;
            f2.Location = this.Location;
            Form2.saveMyIng = ingrTrue;
            this.Hide();
            f2.ShowDialog();
            this.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    comboBoxSearch.Items.Add(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    comboBoxSearch.Sorted = true;
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch
            {
            }
        }
        #endregion

        #region 2-nd TAB
        private void Reload_Click(object sender, EventArgs e)
        {
           // try
            {
                if (metroToggle1.Checked == false)
                {
                    dataGridViewSQL.Rows.Clear();
                    BinaryFormatter formatter = new BinaryFormatter();
                    var objectsBackup = new List<RecipeList>();
                    using (Stream fs = File.Open(@"C:\RecipeBackup\" + "RecipeBackup.dat", FileMode.OpenOrCreate))
                    {
                        int a = 0;
                        fs.Position = 0;
                        while (fs.Position < fs.Length)
                        {
                            a++;
                            objectsBackup.Add((RecipeList)formatter.Deserialize(fs));
                            int n = dataGridViewSQL.Rows.Add();
                            //int o = Convert.ToUInt16(objectsBackup[objectsBackup.Count - 1].Ingridients) - 1;
                            dataGridViewSQL.Rows[n].Cells["colIngredients"].Value = objectsBackup[objectsBackup.Count - 1].Ingridients;
                            dataGridViewSQL.Rows[n].Cells["colName"].Value = objectsBackup[objectsBackup.Count - 1].Name;
                            dataGridViewSQL.Rows[n].Cells["colNumber"].Value = a;
                        }
                        foreach (DataGridViewRow row in dataGridViewSQL.Rows)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                            row.DefaultCellStyle.ForeColor = Color.DarkRed;
                        }
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
                else
                {
                    dataGridViewSQL.Rows.Clear();
                    BinaryFormatter formatter = new BinaryFormatter();
                    var objectsBackup = new List<RecipeList>();
                    using (Stream fs = File.Open(@"C:\RecipeBackup\" + "RecipeBackup.dat", FileMode.OpenOrCreate))
                    {
                        int a = 0;
                        fs.Position = 0;
                        while (fs.Position < fs.Length)
                        {
                            a++;
                            objectsBackup.Add((RecipeList)formatter.Deserialize(fs));
                            int n = dataGridViewSQL.Rows.Add();
                            //int o = Convert.ToUInt16(objectsBackup[objectsBackup.Count - 1].Ingridients) - 1;
                            dataGridViewSQL.Rows[n].Cells["colIngredients"].Value = objectsBackup[objectsBackup.Count - 1].Ingridients;
                            dataGridViewSQL.Rows[n].Cells["colName"].Value = objectsBackup[objectsBackup.Count - 1].Name;
                            dataGridViewSQL.Rows[n].Cells["colNumber"].Value = a;
                        }
                    }
                    foreach (DataGridViewRow row in dataGridViewSQL.Rows)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    backgroundWorker2.RunWorkerAsync();
                }
                    dataGridViewSQL.ClearSelection();
            }
           // catch
            {
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
            findTextChanged = true;
        }

        private void Find_Click(object sender, EventArgs e)
        {
            if (dataGridViewSQL.RowCount != 0)
            {
                if (findText.Text != "")
                {
                    bool contains = false;
                    this.Cursor = Cursors.WaitCursor;

                    if (dataGridViewSQL.CurrentRow.Index == dataGridViewSQL.RowCount - 1)
                    {
                        Reload.PerformClick();
                        SendKeys.Send("{TAB}");
                        SendKeys.Send("{TAB}");
                        SendKeys.Send("{TAB}");
                        SendKeys.Send("{TAB}");
                        SendKeys.Send("{TAB}");
                    }
                    int i = 0;
                    if (findTextChanged)
                    {
                        i = 0;
                        findTextChanged = false;
                    }
                    else
                    {
                        i = dataGridViewSQL.CurrentRow.Index;
                    }
                    for (i = i + 1 ; i < dataGridViewSQL.RowCount; i++)
                    {
                        string name = dataGridViewSQL.Rows[i].Cells[2].Value.ToString();
                        int cursor;
                        for (cursor = 0; cursor + findText.Text.Length <= name.Length; cursor++)
                        {
                            if (name.Substring(cursor, findText.Text.Length).Equals(findText.Text, StringComparison.InvariantCultureIgnoreCase))
                            {
                                contains = true;

                                Reload.PerformClick();
                                dataGridViewSQL.ClearSelection();
                                SendKeys.Send("{TAB}");
                                SendKeys.Send("{TAB}");
                                SendKeys.Send("{TAB}");
                                SendKeys.Send("{TAB}");

                                for (int n = 0; n < i; n++)
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
                        Reload.PerformClick();
                        SendKeys.Send("{TAB}");
                        SendKeys.Send("{TAB}");
                        SendKeys.Send("{TAB}");
                        SendKeys.Send("{TAB}");
                    }
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void dataGridViewSQL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                        this.Cursor = Cursors.WaitCursor;
            //try
            {
                if (e.ColumnIndex == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Удалить этот игредиент НАВСЕГДА?", "Мы удаляем?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string name = dataGridViewSQL.Rows[e.RowIndex].Cells[2].Value.ToString();
                        string ingridients = dataGridViewSQL.Rows[e.RowIndex].Cells[3].Value.ToString();
                        dataGridViewSQL.Rows.RemoveAt(e.RowIndex);

                        BinaryFormatter formatter = new BinaryFormatter();
                        var objectsBackup = new List<RecipeList>();
                        using (Stream fs = File.Open(@"C:\RecipeBackup\" + "RecipeBackup.dat", FileMode.OpenOrCreate))
                        {
                            fs.Position = 0;
                            while (fs.Position < fs.Length)
                            {
                                objectsBackup.Add((RecipeList)formatter.Deserialize(fs));
                                if (objectsBackup[objectsBackup.Count - 1].Name == name && objectsBackup[objectsBackup.Count - 1].Ingridients == ingridients)
                                {
                                    objectsBackup.RemoveAt(objectsBackup.Count - 1);
                                }
                            }
                        }
                        File.WriteAllText(@"C:\RecipeBackup\RecipeBackup.dat", String.Empty);
                        foreach (RecipeList recipe in objectsBackup)
                        {
                            RecipeList.Serialization2(recipe.Name, recipe.Description, recipe.Ingridients, recipe.Count, recipe.Type, "", recipe.Category);
                        }
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                                    bool exist = false;
                                    string name = dataGridViewSQL.Rows[e.RowIndex].Cells[2].Value.ToString();
                                    string ingridients = dataGridViewSQL.Rows[e.RowIndex].Cells[3].Value.ToString();
                                    var objects = new List<RecipeList>();
                                    {
                                        BinaryFormatter formatter = new BinaryFormatter();
                                        using (Stream fs = File.Open(pathToFile + "Recipe.dat", FileMode.OpenOrCreate))
                                        {
                                            fs.Position = 0;
                                            while (fs.Position < fs.Length)
                                            {
                                                objects.Add((RecipeList)formatter.Deserialize(fs));
                                                if (objects[objects.Count -1].Name == name && objects[objects.Count - 1].Ingridients == ingridients)
                                                {
                                                    exist = true;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                    if (exist == false)
                    {
                        DialogResult dialogResult = MessageBox.Show("Хочешь восстановить игредиент?", "Мы восстанавливаем?", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            var objectsBackup = new List<RecipeList>();
                            using (Stream fs = File.Open(@"C:\RecipeBackup\" + "RecipeBackup.dat", FileMode.OpenOrCreate))
                            {
                                fs.Position = 0;
                                while (fs.Position < fs.Length)
                                {
                                    objectsBackup.Add((RecipeList)formatter.Deserialize(fs));
                                    if (objectsBackup[objectsBackup.Count - 1].Name == name && objectsBackup[objectsBackup.Count - 1].Ingridients == ingridients)
                                    {
                                        var RC = objectsBackup[objectsBackup.Count - 1];
                                        RecipeList.Serialization(RC.Name, RC.Description, RC.Ingridients, RC.Count, RC.Type, RC.ImageDirection, RC.Category);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //catch
            {
            }
                        this.Cursor = Cursors.Default;
        }

        private void RestoreAll_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Хочешь восстановить АБСОЛЮТНО всё?", "Мы восстанавливаем ВСЁ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                    this.Cursor = Cursors.WaitCursor;
                BinaryFormatter formatter = new BinaryFormatter();
                var objectsBackup = new List<RecipeList>();
                using (Stream fs = File.Open(@"C:\RecipeBackup\" + "RecipeBackup.dat", FileMode.OpenOrCreate))
                {
                    fs.Position = 0;
                    while (fs.Position < fs.Length)
                    {
                        objectsBackup.Add((RecipeList)formatter.Deserialize(fs));
                        var RC = objectsBackup[objectsBackup.Count - 1];
                        bool exist = false;
                                    var objects = new List<RecipeList>();
                                    using (Stream fsss = File.Open(pathToFile + "Recipe.dat", FileMode.OpenOrCreate))
                                    {
                                        fsss.Position = 0;
                                        while (fsss.Position < fsss.Length)
                                        {
                                            objects.Add((RecipeList)formatter.Deserialize(fsss));
                                        }
                                    }
                        foreach (RecipeList recipe in objects)
                        {
                            if (recipe.Name == RC.Name && recipe.Description == RC.Description)
                            {
                                exist = true;
                                break;
                            }
                        }
                        if (exist == false)
                        {
                            RecipeList.Serialization(RC.Name, RC.Description, RC.Ingridients, RC.Count, RC.Type, RC.ImageDirection, RC.Category);
                        }
                    }
                }

                    string[] ingridientsFile = File.ReadAllLines(@"C:\RecipeBackup\Ingridients.txt", Encoding.UTF8);
                    File.WriteAllText(pathToFile + @"Ingridients.txt", String.Empty);
                string ing = "";
                for (int a = 0; a < ingridientsFile.Count(); a++)
                {
                    ing += ingridientsFile[a] + "\r";
                }
                File.WriteAllText(pathToFile + @"Ingridients.txt", ing.Substring(0, ing.Length - 1));

                string[] categoryFile = File.ReadAllLines(@"C:\RecipeBackup\Category.txt", Encoding.UTF8);
                File.WriteAllText(pathToFile + @"Category.txt", String.Empty);
                string cat = "";
                for (int a = 0; a < categoryFile.Count(); a++)
                {
                    cat += ingridientsFile[a] + "\r";
                }
                File.WriteAllText(pathToFile + @"Ingridients.txt", cat.Substring(0, ing.Length - 1));

                this.Cursor = Cursors.Default;
            }
         }

        private void dataGridViewSQL_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string name = dataGridViewSQL.Rows[e.RowIndex].Cells[2].Value.ToString();
                string ingridients = dataGridViewSQL.Rows[e.RowIndex].Cells[3].Value.ToString();

                BinaryFormatter formatter = new BinaryFormatter();
                RecipeList objectBackupEdit = new RecipeList();
                using (Stream fs = File.Open(@"C:\RecipeBackup\" + "RecipeBackup.dat", FileMode.OpenOrCreate))
                {
                    var objectsBackup = new List<RecipeList>();
                    fs.Position = 0;
                    while (fs.Position < fs.Length)
                    {
                        objectsBackup.Add((RecipeList)formatter.Deserialize(fs));
                        if (objectsBackup[objectsBackup.Count - 1].Name == name && objectsBackup[objectsBackup.Count - 1].Ingridients == ingridients)
                        {
                            objectBackupEdit = objectsBackup[objectsBackup.Count - 1];
                            break;
                        }
                    }
                }
                string[] IngredientsNumbers = objectBackupEdit.Ingridients.Split(' ');
                string[] ingridientsList = (File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8));
                string ingr = "";
                for (int i = 0; i < IngredientsNumbers.Count() - 1; i++)
                {
                    ingr += ingridientsList[Convert.ToUInt16(IngredientsNumbers[i]) - 1] + "\r ";
                }
                EditByName ed = new EditByName(objectBackupEdit.Name, ingr, objectBackupEdit.Description, objectBackupEdit.Count, objectBackupEdit.Type, "Все ингредиенты куплены", objectBackupEdit.ImageDirection);
                ed.StartPosition = FormStartPosition.Manual;
                ed.Location = this.Location;
                ed.Show();
            }
            catch
            {
            }
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            Reload.PerformClick();
        }
        #endregion

        private void timer_elapsed(object sender, ElapsedEventArgs e)
        {
            NotifyIcon notifyIcon = new NotifyIcon();
            notifyIcon.Visible = true;
            notifyIcon.BalloonTipTitle = "Ээээй";
            notifyIcon.BalloonTipText = "Есть тут кто?";
            notifyIcon.Icon = SystemIcons.Application;
            notifyIcon.ShowBalloonTip(5000);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            using (Stream fsss = File.Open(pathToFile + "Recipe.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter formatterr = new BinaryFormatter();

                var objects = new List<RecipeList>();

                fsss.Position = 0;
                string[] allIngridients = File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8);
                while (fsss.Position < fsss.Length)
                {
                    objects.Add((RecipeList)formatterr.Deserialize(fsss));
                    foreach (DataGridViewRow row in dataGridViewSQL.Rows)
                        if ((row.Cells[2].Value.ToString() == objects[objects.Count - 1].Name) && (row.Cells[3].Value.ToString() == objects[objects.Count - 1].Ingridients))
                        {
                            row.DefaultCellStyle.BackColor = Color.YellowGreen;
                            row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                            break;
                        }
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            using (Stream fsss = File.Open(pathToFile + "Recipe.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter formatterr = new BinaryFormatter();

                var objects = new List<RecipeList>();

                fsss.Position = 0;
                string[] allIngridients = File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8);
                while (fsss.Position < fsss.Length)
                {
                    objects.Add((RecipeList)formatterr.Deserialize(fsss));
                    foreach (DataGridViewRow row in dataGridViewSQL.Rows)
                        if ((row.Cells[2].Value.ToString() == objects[objects.Count - 1].Name) && (row.Cells[3].Value.ToString() == objects[objects.Count - 1].Ingridients))
                        {
                            dataGridViewSQL.Invoke(new Action(() => { dataGridViewSQL.Rows.Remove(row); }));//Иначе ошибка - меняю ядро, из которого была запущена ассинхронная функция
                            break;
                        }
                }
            }
            dataGridViewSQL.ClearSelection();
        }

        private void metroTabPage1_MouseMove(object sender, MouseEventArgs e)
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Close();
            System.Diagnostics.Process self = System.Diagnostics.Process.GetCurrentProcess();
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses().Where(p => p.Id != self.Id))
            {
                p.Close();
            }
        }
    }
}