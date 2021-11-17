using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miheev
{
    public partial class EditForm : Form
    {
        AddressesOfOrganizations form = new AddressesOfOrganizations();
        DataGridViewCell cell;
        public EditForm(AddressesOfOrganizations f, DataGridViewCell c)
        {
            InitializeComponent();
            form = f;
            cell = c;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                cell.Value = textBox1.Text;
                form.EditElementInDataGrid(cell);
                this.Close();
            } else
            {
                MessageBox.Show("Введите элемент");
            }
        }
    }
}
