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
        string ingr;
        string pathToFile = Form1.pathToFile;
        public Find(string Ingr)
        {
            InitializeComponent();
            this.Cursor = Cursors.WaitCursor;
            ingr = Ingr;
            var ingridientsList = new List<string>();
            int lastIndex = 0;
            int maxLength = 0;
            //Наполнение ВСЕМИ рацептами (если ничего не выбрано)
//---------------------------------------------------------------------------------------------------------------------------
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
//---------------------------------------------------------------------------------------------------------------------------
            else
            {
                while (0 < ingr.Length)
                {
                    string subIngr = ingr.Substring(0, 1);
                    ingr = ingr.Remove(0, 1);
                    ingridientsList.Add(subIngr);
                }
               // int wordCount = ingr.Length;
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
                        for (int i = 0; i < ingridientsList.Count; i++)
                        {
                            bool equals = false;

                            for (a = 0; a + ingridientsList[i].Length <= r.Ingridients.Length; a++)
                            {
                                if (ingridientsList[i].Equals(r.Ingridients.Substring(a, ingridientsList[i].Length), StringComparison.InvariantCultureIgnoreCase))
                                {
                                    equals = true;
                                }
                                if (equals == true)
                                {
                                    a = r.Ingridients.Length;//Находит ТОЛЬКО ОДНО совпадение
                                                              a = ingridientsList.Count + 1;
                                    int n = dataGridView.Rows.Add();
                                    dataGridView.Rows[n].Cells["colName"].Value = r.Name;
                                    dataGridView.Rows[n].Cells["colIngridients"].Value = r.Ingridients;
                                    dataGridView.Rows[n].Cells["colNumber"].Value = n + 1;
                                    dataGridView.Rows[n].Cells["colDescription"].Value = r.Description;
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
            EditByName ed = new EditByName(Name, Ingridients, Description);
            ed.StartPosition = FormStartPosition.Manual;
            ed.Location = this.Location;
            ed.Show();


            this.Cursor = Cursors.WaitCursor;
            var ingridientsList = new List<string>();
            int lastIndex = 0;
            int maxLength = 0;
            //Наполнение ВСЕМИ рацептами (если ничего не выбрано)
            //---------------------------------------------------------------------------------------------------------------------------
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
            //---------------------------------------------------------------------------------------------------------------------------
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
                    ingridientsList.Add(subIngr);
                    //   MessageBox.Show("" + ingridientsList.Last());
                }
                // int wordCount = ingr.Length;
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
                        for (int i = 0; i < ingridientsList.Count; i++)
                        {
                            bool equals = false;

                            for (a = 0; a + ingridientsList[i].Length <= r.Ingridients.Length; a++)
                            {
                                if (ingridientsList[i].Equals(r.Ingridients.Substring(a, ingridientsList[i].Length), StringComparison.InvariantCultureIgnoreCase))
                                {
                                    equals = true;
                                }
                                if (equals == true)
                                {
                                    a = r.Ingridients.Length;//Находит ТОЛЬКО ОДНО совпадение
                                    a = ingridientsList.Count + 1;
                                    int n = dataGridView.Rows.Add();
                                    dataGridView.Rows[n].Cells["colName"].Value = r.Name;
                                    dataGridView.Rows[n].Cells["colIngridients"].Value = r.Ingridients;
                                    dataGridView.Rows[n].Cells["colNumber"].Value = n + 1;
                                    dataGridView.Rows[n].Cells["colDescription"].Value = r.Description;
                                }
                            }
                        }
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
