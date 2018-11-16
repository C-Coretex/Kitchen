using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitchen
{
    public partial class Find : Form
    {
        string pathToFile = Form1.pathToFile;
        public Find(string Ingr)
        {
            InitializeComponent();
            this.Cursor = Cursors.WaitCursor;
            string ingr = Ingr.Trim();
            var list = new List<string>();
            int lastIndex = 0;
            int maxLength = 0;
            if (ingr.Length == 0)
            {
                using (Stream fs = File.Open(Form1.pathToFile + "Recipe.dat", FileMode.OpenOrCreate))
                {
                    try
                    {
                        BinaryFormatter formatter = new BinaryFormatter();

                        RecipeList RL = new RecipeList();
                        var objects = new List<RecipeList>();

                        fs.Position = 0;
                        while (fs.Position < fs.Length)
                        {
                            objects.Add((RecipeList)formatter.Deserialize(fs));
                        }
                        foreach (RecipeList r in objects)
                        {
                            int n = dataGridView.Rows.Add();
                            dataGridView.Rows[n].Cells["colName"].Value = r.Name;
                            dataGridView.Rows[n].Cells["colIngridients"].Value = r.Ingridients;
                            dataGridView.Rows[n].Cells["colNumber"].Value = n + 1;
                            dataGridView.Rows[n].Cells["colDescription"].Value = r.Description;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                while (0 < ingr.Length)
                {
                    lastIndex = ingr.IndexOf("\r");
                    if (lastIndex <= 0)
                    {
                        lastIndex = ingr.Length;
                    }
                    ingr = ingr.Remove(lastIndex, 0).Trim();
                    string subIngr = ingr.Substring(0, lastIndex);
                    if (subIngr.Length > maxLength)
                    {
                        maxLength = subIngr.Length;
                    }
                    ingr = ingr.Remove(0, lastIndex).Trim();
                    list.Add(subIngr);
                    MessageBox.Show("" + list.Last());
                }
                //int wordCount = ingr.
                using (Stream fs = File.Open(pathToFile + "Recipe.dat", FileMode.OpenOrCreate))
                {
                        BinaryFormatter formatter = new BinaryFormatter();

                        RecipeList RL = new RecipeList();
                        var objects = new List<RecipeList>();

                        fs.Position = 0;
                        while (fs.Position < fs.Length)
                        {
                            objects.Add((RecipeList)formatter.Deserialize(fs));
                        }

                        foreach (RecipeList r in objects)
                        {
                            int a = 0;
                            for (int i = 0; i < list.Count; i++)
                            {
                                bool equals = false;

                                for (a = 0; a + list[i].Length <= r.Ingridients.Length; a++)
                                {
                                    if (list[i].Equals(r.Ingridients.Substring(a, list[i].Length), StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        equals = true;
                                    }
                                    if (equals == true)
                                    {
                                        a = r.Ingridients.Length;//Находит ТОЛЬКО ОДНО совпадение
                                                                 // a = list.Count + 1;
                                        int n = dataGridView.Rows.Add();
                                        dataGridView.Rows[n].Cells["colName"].Value = r.Name;
                                        dataGridView.Rows[n].Cells["colIngridients"].Value = r.Ingridients;
                                        dataGridView.Rows[n].Cells["colNumber"].Value = n + 1;
                                         dataGridView.Rows[n].Cells["colDescription"].Value = r.Description;
                                        r.Name = "";
                                        r.Description = "";
                                        r.Ingridients = "";
                                    }
                                }
                            }
                        }
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void Find_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView.CurrentRow.Index;
            string Name = dataGridView.Rows[row].Cells["colName"].Value.ToString();
            string Ingridients = dataGridView.Rows[row].Cells["colIngridients"].Value.ToString();
            string Description = dataGridView.Rows[row].Cells["colDescription"].Value.ToString();
            Show sh = new Show(Name, Ingridients, Description);
            sh.StartPosition = FormStartPosition.Manual;
            sh.Location = this.Location;
            sh.Show();
        }
    }
}
