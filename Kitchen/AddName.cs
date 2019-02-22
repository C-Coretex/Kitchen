using System;
using System.Windows.Forms;

namespace Kitchen
{
    public partial class AddName : Form
    {
        int i = 1;
        string ingr = "";
        string count = "";
        string type = "";
        string imageDirection = "";
        string category = "";
        public AddName(string Ingridients, string Count, string Type, string Category)
        {
            InitializeComponent();
            ingr = Ingridients;
            count = Count;
            type = Type;
            category = Category;
            description.ScrollBars = ScrollBars.Both;
        }

        private void saveExit_Click(object sender, EventArgs e)
        {
            if (name.Text == "")
            {
                MessageBox.Show("Впишите название рецепта");
            }
            else if (description.Text == "" || description.Text == "1. " || description.Text == "1. \r\n")
            {
                MessageBox.Show("Впишите описание рецепта");
            }
            else{
                RecipeList.Serialization(name.Text, description.Text, ingr, count, type, imageDirection, category);
                this.Close();
            }
        }

        private void AddName_Shown(object sender, EventArgs e)
        {
            description.Text = i + ". ";
            сщгте.Text = Convert.ToString(i);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i++;
            description.Text = description.Text + "\r\n\r\n" + i + ". ";
            сщгте.Text = Convert.ToString(i);
            description.Focus();
            SendKeys.Send("{RIGHT}");
        }

        private void сщгте_TextChanged(object sender, EventArgs e)
        {
            try
            {
                i = Convert.ToInt16(сщгте.Text);
            }
            catch
            {
                MessageBox.Show("Сюда можно вписывать только цифры");
                сщгте.Text = Convert.ToString(i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if(fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageDirection = fileDialog.FileName;
                pictureBox1.ImageLocation = imageDirection;
            }
        }
    }
}
