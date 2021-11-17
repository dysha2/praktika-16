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
    public partial class AddressesOfOrganizations : Form
    {
        AddressAdd form;
        public AddressesOfOrganizations()
        {
            InitializeComponent();
            form = new AddressAdd(this);
        }

        private void AddressesOfOrganizations_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ThisFormClosing(object sender, FormClosingEventArgs e)
        {
            form.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            } catch { MessageBox.Show("Выделите строку"); }
        }

        public void AddElementToDataGrid(OrganizationAddress obj)
        {
            dataGridView1.Rows.Add(obj.City, obj.Street, obj.Number);
        }

        public void EditElementInDataGrid(DataGridViewCell cell)
        {
            dataGridView1.CurrentCell = cell;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.Value!=null)
            {
                try
                {
                    EditForm EdF = new EditForm(this, dataGridView1.CurrentCell);
                    EdF.ShowDialog();
                }
                catch { MessageBox.Show("Выберете ячейку"); }
            } else
            {
                MessageBox.Show("Ячейка пуста");
            }
        }
    }
}
