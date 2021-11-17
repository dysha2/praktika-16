using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miheev
{
    public partial class IndicatorsForm : Form
    {
        List<Indicator> indicators = new List<Indicator>();
        public IndicatorsForm()
        {
            InitializeComponent();
        }

        private void IndicatorsForm_Load(object sender, EventArgs e)
        {

        }
        public void AddIndicator(Indicator ind)
        {
            indicators.Add(ind);
            UpdateListBox();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string file = textBox1.Text;
            if (!file.EndsWith(".txt")) file += ".txt";
            if (File.Exists(file)) {
                indicators.AddRange(Indicator.GetIntoFile(file));
                UpdateListBox();
            } else
            {
                MessageBox.Show("Текстовый файл с таким именем не найден");
            }

        }
        private void UpdateListBox()
        {
            int selIndex=listBox1.SelectedIndex;
            listBox1.Items.Clear();
            indicators.ForEach(x => listBox1.Items.Add(x.GetIndicator()));
            listBox1.SelectedIndex = selIndex;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddIndicator form = new AddIndicator(this);
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem!=null)
            {
                uint page;
                if (uint.TryParse(textBox2.Text,out page))
                {
                    indicators[listBox1.SelectedIndex].RemovePage(page);
                    UpdateListBox();
                }
            }
        }
    }
}
