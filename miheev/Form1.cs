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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddressesOfOrganizations form = new AddressesOfOrganizations();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ComplexNumForm form = new ComplexNumForm();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VektorForm form = new VektorForm();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ArrayForm form = new ArrayForm();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StudentForm form = new StudentForm();
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IndicatorsForm form = new IndicatorsForm();
            form.ShowDialog();
        }
    }
}
