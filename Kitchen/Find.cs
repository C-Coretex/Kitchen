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
        string ingrTrue;
        string pathToFile = Form1.pathToFile;
        public Find(string IngrTrue)
        {
            InitializeComponent();
            this.Cursor = Cursors.WaitCursor;
                ingrTrue = IngrTrue;
            string[] allIngridients = File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8);
            //Наполнение ВСЕМИ рацептами (если ничего не выбрано)
            //---------------------------------------------------------------------------------------------------------------------------
            if (ingrTrue.Length == 0)
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

                            string[] subStr = r.Ingridients.Split(' ');
                            for (uint i = 0; i < subStr.Length-1; i++)
                            {
                                string together = dataGridView.Rows[n].Cells["colNotEnough"].Value + "\r " + allIngridients[Convert.ToInt16(subStr[i])-1];
                                dataGridView.Rows[n].Cells["colNotEnough"].Value = together;
                            }

                            dataGridView.Rows[n].Cells["colEqualsProcents"].Value = "0%";
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
//---------------------------------------------------------------------------------------------------------------------------
                using (Stream fs = File.Open(Form1.pathToFile + "Recipe.dat", FileMode.OpenOrCreate))
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

                        //Записываю выбранные ингредиенты во множество
                        HashSet<uint> ingrTrueSet = new HashSet<uint>();
                        string[] subStr = ingrTrue.Split(' ');
                        for (uint i = 0; i < subStr.Length - 1; i++)
                        {
                            // Записать во множество числа
                            ingrTrueSet.Add(Convert.ToUInt16(subStr[i]));
                        }
                        //Записываю выбранные ингредиенты во множество

                        //Записываю ингредиенты из конкретного рецепта во множество
                        string[] ingrOrder = r.Ingridients.Split(' ');
                        HashSet<uint> ingrCountEVER = new HashSet<uint>();
                            for (uint n = 0; n < ingrOrder.Length-1; n++)
                            {
                                ingrCountEVER.Add(Convert.ToUInt32(ingrOrder[n]));
                            }
                        //Записываю ингредиенты из конкретного рецепта во множество

                        //Если оба множества пересекаются, конкретный рецепт записывается в таблицу
                            List<uint> equals = new List<uint>();
                            float ingrTrueSetCount = ingrCountEVER.Count;
                            ingrTrueSet.IntersectWith(ingrCountEVER);
                            equals = ingrTrueSet.ToList();
                            if (equals.Count != 0)
                            {
                                int n = dataGridView.Rows.Add();
                                dataGridView.Rows[n].Cells["colName"].Value = r.Name;
                                ingrTrueSetCount = (equals.Count / ingrTrueSetCount) * 100;
                                dataGridView.Rows[n].Cells["colEqualsProcents"].Value = Convert.ToInt16(ingrTrueSetCount) + "%";
                            equals = ingrCountEVER.Except(equals).ToList();
                            if (equals.Count != 0)
                            {
                                for (int i = 0; i < equals.Count; i++)
                                {
                                    string together = dataGridView.Rows[n].Cells["colNotEnough"].Value + "\r " + allIngridients[Convert.ToInt16(equals[i]) - 1];
                                    //string a = Convert.ToString(dataGridView.Rows[n].Cells["colNotEnough"].Value) + " " + equals[i];
                                    dataGridView.Rows[n].Cells["colNotEnough"].Value = together;
                                }
                            }
                            else
                            {
                                dataGridView.Rows[n].Cells["colNotEnough"].Value = "Все ингридиенты куплены";
                                dataGridView.Rows[n].Cells["colNotEnough"].Style.BackColor = Color.YellowGreen;
                                dataGridView.Rows[n].Cells["colNotEnough"].Style.ForeColor = Color.DarkGreen;
                            }
                                dataGridView.Rows[n].Cells["colDescription"].Value = r.Description;
                        }
                    }
                }
                dataGridView.Sort(dataGridView.Columns[0], ListSortDirection.Ascending);
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            //var ingridientsList = new List<string>();
            //int lastIndex = 0;
            //int maxLength = 0;
            ////Наполнение ВСЕМИ рацептами (если ничего не выбрано)
            ////---------------------------------------------------------------------------------------------------------------------------
            //if (ingrTrue.Length == 0)
            //{
            //    using (Stream fs = File.Open(Form1.pathToFile + "Recipe.dat", FileMode.OpenOrCreate))
            //    {
            //        try
            //        {
            //            BinaryFormatter formatter = new BinaryFormatter();

            //            RecipeList RL = new RecipeList();
            //            var objects = new List<RecipeList>();

            //            fs.Position = 0;
            //            while (fs.Position < fs.Length)
            //            {
            //                objects.Add((RecipeList)formatter.Deserialize(fs));
            //            }
            //            foreach (RecipeList r in objects)
            //            {
            //                int n = dataGridView.Rows.Add();
            //                dataGridView.Rows[n].Cells["colName"].Value = r.Name;
            //                dataGridView.Rows[n].Cells["colIngridients"].Value = r.Ingridients;
            //                dataGridView.Rows[n].Cells["colNumber"].Value = n + 1;
            //                dataGridView.Rows[n].Cells["colDescription"].Value = r.Description;
            //            }
            //        }
            //        catch
            //        {
            //        }
            //    }
            //}
            ////---------------------------------------------------------------------------------------------------------------------------
            //else
            //{
            //    while (0 < ingrTrue.Length)
            //    {
            //        lastIndex = ingrTrue.IndexOf("\r");
            //        if (lastIndex <= 0)
            //        {
            //            lastIndex = ingrTrue.Length;
            //        }
            //        ingrTrue = ingrTrue.Remove(lastIndex, 0).Trim();
            //        string subIngr = ingrTrue.Substring(0, lastIndex);
            //        if (subIngr.Length > maxLength)
            //        {
            //            maxLength = subIngr.Length;
            //        }
            //        ingrTrue = ingrTrue.Remove(0, lastIndex).Trim();
            //        ingridientsList.Add(subIngr);
            //        //   MessageBox.Show("" + ingridientsList.Last());
            //    }
            //    // int wordCount = ingrTrue.Length;
            //    using (Stream fs = File.Open(pathToFile + "Recipe.dat", FileMode.OpenOrCreate))
            //    {
            //        BinaryFormatter formatter = new BinaryFormatter();

            //        RecipeList RL = new RecipeList();
            //        var objects = new List<RecipeList>();

            //        fs.Position = 0;
            //        while (fs.Position < fs.Length)
            //        {
            //            objects.Add((RecipeList)formatter.Deserialize(fs));
            //        }

            //        foreach (RecipeList r in objects)
            //        {
            //            int a = 0;
            //            for (int i = 0; i < ingridientsList.Count; i++)
            //            {
            //                bool equals = false;

            //                for (a = 0; a + ingridientsList[i].Length <= r.Ingridients.Length; a++)
            //                {
            //                    if (ingridientsList[i].Equals(r.Ingridients.Substring(a, ingridientsList[i].Length), StringComparison.InvariantCultureIgnoreCase))
            //                    {
            //                        equals = true;
            //                    }
            //                    if (equals == true)
            //                    {
            //                        a = r.Ingridients.Length;//Находит ТОЛЬКО ОДНО совпадение
            //                        a = ingridientsList.Count + 1;
            //                        int n = dataGridView.Rows.Add();
            //                        dataGridView.Rows[n].Cells["colName"].Value = r.Name;
            //                        dataGridView.Rows[n].Cells["colIngridients"].Value = r.Ingridients;
            //                        dataGridView.Rows[n].Cells["colNumber"].Value = n + 1;
            //                        dataGridView.Rows[n].Cells["colDescription"].Value = r.Description;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            this.Cursor = Cursors.Default;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
