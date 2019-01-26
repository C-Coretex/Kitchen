using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace Kitchen
{
    public partial class Form1 : Form
    {
        string ingrTrue = "";
        int i;//Количество CheckBox'ов
        CheckBox box; //Обьявляю для того, чтобы можно было использовать чекбоксы ВЕЗДЕЕЕЕЕЕЕЕЕЕЕ
        static public string pathToFile = "";
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Ctrl+Shift+V " + " Shift+Tab");
            this.Cursor = Cursors.WaitCursor;
            #region 1-st TAB
            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            // string o = System.AppDomain.CurrentDomain.BaseDirectory;
            //string pathToFile = @o + "\";
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
            #endregion 
            string[] ingridients = (File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8));
            List<string> firstLetters = new List<string>();
            List<string> allIngridients = new List<string>();
            foreach (string a in ingridients)
            {
                allIngridients.Add(a.ToString());
                if (firstLetters.Contains(a.Substring(0, 1)))
                { }
                else
                {
                    firstLetters.Add(a.Substring(0, 1));
                }
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

        #region 1-st TAB entrails
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
        }


        private void comboBoxSearch_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void comboBoxSearch_SelectedIndexChanged_2(object sender, EventArgs e)
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
            Hide();
            Form2.saveMyIng = ingrTrue;
            f2.ShowDialog();
            Close();//Закрывает ПЕРВУЮ форму
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

        }
        #endregion

        private void Form1_Shown(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000 * 60 * 5);
            timer.AutoReset = true; // the key is here so it repeats
            timer.Elapsed += timer_elapsed;
            timer.Start();
        }

        private void timer_elapsed(object sender, ElapsedEventArgs e)
        {
            NotifyIcon notifyIcon = new NotifyIcon();
            notifyIcon.Visible = true;
            notifyIcon.BalloonTipTitle = "Ээээй";
            notifyIcon.BalloonTipText = "Есть тут кто?";
            notifyIcon.Icon = SystemIcons.Application;
            notifyIcon.ShowBalloonTip(5000);
        }
    }
}