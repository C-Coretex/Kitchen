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
        public Find(string Ingr)
        {
            InitializeComponent();
            this.Cursor = Cursors.WaitCursor;
            string ingr = Ingr;
            var list = new List<string>();
                int firstIndex = 0;
            while (firstIndex < ingr.Length)
            {
                //MessageBox.Show(""+ ingr.Take(' '));
                int lastIndex = ingr.IndexOf("\r");
                    if (lastIndex < 0)
                    {
                        lastIndex = ingr.Length;
                    }
                string subIngr = ingr.Substring(firstIndex, lastIndex);
                    firstIndex = subIngr.Length;
                    MessageBox.Show("" + subIngr);
                 ingr = ingr.Remove(0, lastIndex);
                 ingr = ingr.Replace("\r", "");
                //MessageBox.Show("ingr  " + ingr);
                //list.Add(ingr.Split(' '))
            }
            //int wordCount = ingr.
            using (Stream fs = File.Open(Form2.pathToFile + "Recipe.dat", FileMode.OpenOrCreate))
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
                        for (int i = 0; i + ingr.Length <= r.Ingridients.Length; i++)
                        {
                            //while ()
                            {
                                

                            if (ingr == r.Ingridients.Substring(i, ingr.Length))
                            {
                                int n = dataGridView.Rows.Add();
                                dataGridView.Rows[n].Cells[1].Value = r.Name;
                                dataGridView.Rows[n].Cells[2].Value = r.Ingridients;
                                dataGridView.Rows[n].Cells[0].Value = n + 1;
                                break;
                            }
                        }
                    }
                    }
                }
                catch
                {
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void Find_Load(object sender, EventArgs e)
        {

        }
    }
}
