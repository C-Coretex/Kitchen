using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitchen
{
    public partial class Show : Form
    {
        public Show(string Name, string Ingridients, string Descriprion)
        {
            InitializeComponent();
            name.Text = Name;
            ingridients.Text = Ingridients;
            description.Text = Descriprion;
        }

        private void edit_Click(object sender, EventArgs e)
        {
            //rowIndex = 0;
            //rowNumber = 0;
           // Edit ed = new Edit();
           // ed.StartPosition = FormStartPosition.Manual;
           // ed.Location = this.Location;
          //  ed.ShowDialog();
           // this.Close();
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
        }

        private void ingridients_TextChanged(object sender, EventArgs e)
        {
        }

        private void description_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
