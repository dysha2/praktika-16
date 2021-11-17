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
    public partial class AddIndicator : Form
    {
        IndicatorsForm form = new IndicatorsForm();
        TextBox[] textBoxes = new TextBox[10];
        public AddIndicator(IndicatorsForm f)
        {
            InitializeComponent();
            textBoxes[0] = textBox2;
            textBoxes[1] = textBox3;
            textBoxes[2] = textBox4;
            textBoxes[3] = textBox5;
            textBoxes[4] = textBox6;
            textBoxes[5] = textBox7;
            textBoxes[6] = textBox8;
            textBoxes[7] = textBox9;
            textBoxes[8] = textBox10;
            textBoxes[9] = textBox11;
            form = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                Indicator ind = new Indicator(textBox1.Text);
                foreach(TextBox s in textBoxes)
                {
                    uint page;
                    if (uint.TryParse(s.Text, out page)) ind.AddPage(page);
                }
                form.AddIndicator(ind);
                this.Close();
            } else
            {
                MessageBox.Show("Введите слово");
            }
        }
    }
}
