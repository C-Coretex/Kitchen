﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Kitchen
{
    public partial class EditByName : Form
    {
        static public string name_ = "";
        string originalName;
        int i;//Количество CheckBox'ов
        string pathToFile = Form1.pathToFile;
        public EditByName(string Name, string Ingridients, string Descriprion, string Count, string Type, string lack, string imageDirection)
        {
            InitializeComponent();
            this.Cursor = Cursors.WaitCursor;
            description.ScrollBars = ScrollBars.Both;
            originalName = Name;// Нужно для поиска правильного обьекта
            labelName.Text = Name;
            description.Text = Descriprion;
            //labelDescription.Text = Descriprion;
            var objects = new List<RecipeList>();
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream fs = File.Open(pathToFile + "Recipe.dat", FileMode.OpenOrCreate))
            {
                int a = 0;
                fs.Position = 0;
                while (fs.Position < fs.Length)
                {
                    a++;
                    objects.Add((RecipeList)formatter.Deserialize(fs));
                }
            }
            string[] subStr = Ingridients.Split(new string[] { "\r " }, StringSplitOptions.None);
            string[] subCount = Count.Split(' ');
            string[] subType = Type.Split('|');
            string[] subLack = lack.Split(new string[] { "\r " }, StringSplitOptions.None);
            for (i = 0; i < subStr.Length-1; i++)
            {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = subStr[i];
               foreach (string subSubLack in subLack)
                    if (subSubLack == subStr[i])
                        {
                            dataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightCoral;
                             dataGridView1.Rows[n].Cells[0].Style.ForeColor = Color.DarkRed;
                            dataGridView1.Rows[n].Cells[1].Style.BackColor = Color.LightCoral;
                             dataGridView1.Rows[n].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightCoral;
                             dataGridView1.Rows[n].Cells[2].Style.ForeColor = Color.DarkRed;
                            break;
                        }
                else
                {
                    dataGridView1.Rows[n].Cells[0].Style.BackColor = Color.YellowGreen;
                      dataGridView1.Rows[n].Cells[0].Style.ForeColor = Color.DarkGreen;
                    dataGridView1.Rows[n].Cells[1].Style.BackColor = Color.YellowGreen;
                      dataGridView1.Rows[n].Cells[1].Style.ForeColor = Color.DarkGreen;
                    dataGridView1.Rows[n].Cells[2].Style.BackColor = Color.YellowGreen;
                      dataGridView1.Rows[n].Cells[2].Style.ForeColor = Color.DarkGreen;
                }
            }
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[1].Value = subCount[i];
                dataGridView1.Rows[i].Cells[2].Value = subType[i];
            }
            SendKeys.Send("{TAB}");
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            pictureBox1.ImageLocation = imageDirection;
            this.Cursor = Cursors.Default;
        }

        private void EditByName_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
