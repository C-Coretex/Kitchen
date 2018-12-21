using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitchen
{
    public partial class Form1 : Form
    {
        string ingr = "";
        int boxTrue = 0;
        int i;//Количество CheckBox'ов
        CheckBox box; //Обьявляю для того, чтобы можно было использовать чекюоксы везде
        static public string pathToFile = "";
        public Form1()
        {
            InitializeComponent();

            // string o = System.AppDomain.CurrentDomain.BaseDirectory;
            //string pathToFile = @o + "\";
            //РАБОТАЕТ ТОЛЬКО ПОСЛЕ ИНСТАЛЯТОРА(должно)
            pathToFile = @"C:\Users\valer\Desktop\Programming\Kitchen\";

            FindRecepts.TabStop = false;
            FindRecepts.FlatStyle = FlatStyle.Flat;
            FindRecepts.FlatAppearance.BorderSize = 0;
            BrowseRecepts.TabStop = false;
            BrowseRecepts.FlatStyle = FlatStyle.Flat;
            BrowseRecepts.FlatAppearance.BorderSize = 0;
            string[] ingridients = (File.ReadAllLines(pathToFile + @"Ingridients.txt", Encoding.UTF8));
            int startLocation = 0;//Локация "генерирования" чекбокса (y)
            int chboxTrueCount = 0;
            for (i = 0; i < ingridients.Length; i++)
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
        
        private void FindRecepts_Click(object sender, EventArgs e)
        {
            int boxTrue = 0;
            int n = 0;
            foreach (CheckBox chbox in this.Controls.OfType<CheckBox>())
            {
                n++;
                if (chbox.Checked)
                {
                    boxTrue++;
                    MessageBox.Show("Ты выбрал " + chbox.Text);
                    ingr += n;
                }
            }
            Find find = new Find(ingr);
            find.StartPosition = FormStartPosition.Manual;
            find.Location = this.Location;
            find.ShowDialog();
        }

        private void BrowseRecepts_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.StartPosition = FormStartPosition.Manual;
            f2.Location = this.Location;
            Hide();
            Form2.saveMyIng = ingr;
            f2.ShowDialog();
            Close();//Закрывает ПЕРВУЮ форму
        }
        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
