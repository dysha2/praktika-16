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
    public partial class AddressAdd : Form
    {
        AddressesOfOrganizations form;
        public AddressAdd(AddressesOfOrganizations f)
        {
            InitializeComponent();
            form = f;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text!="")&&(textBox2.Text != "") &&(textBox3.Text != ""))
            {
                OrganizationAddress obj = new OrganizationAddress {City=textBox1.Text,Street=textBox2.Text,Number=textBox3.Text };
                form.AddElementToDataGrid(obj);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            } else
            {
                MessageBox.Show("Введите все данные", "ОШИБКА");
            }
        }

        private void AddressAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
