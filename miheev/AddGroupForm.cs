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
    public partial class AddGroupForm : Form
    {
        StudentForm form;
        public AddGroupForm(StudentForm f)
        {
            InitializeComponent();
            form = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                form.AddGroup(textBox1.Text);
                this.Close();
            } else
            {
                MessageBox.Show("Введите название группы");
            }
        }

        private void AddGroupForm_Load(object sender, EventArgs e)
        {

        }
    }
}
