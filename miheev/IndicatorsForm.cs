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
            int check = 0;
            foreach (Indicator i in indicators)
            {
                if (i.GetWord().ToLower() == ind.GetWord().ToLower()) ++check;
            }
            if (check==0)
            {
                indicators.Add(ind);
                UpdateListBox();
            }else
            {
                MessageBox.Show("Указатель с таким словом уже имеется");
            }

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string file = textBox1.Text;
            if (!file.EndsWith(".txt")) file += ".txt";
            if (File.Exists(file)) {
                if (indicators.Count>0)
                {
                    List<Indicator> inds = Indicator.GetIntoFile(file);
                    for (int i = 0; i < inds.Count; i++)
                    {
                        if (indicators.Exists(x => x == inds[i])) indicators.Add(inds[i]);
                    }
                } else indicators.AddRange(Indicator.GetIntoFile(file));

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
                } else
                {
                    MessageBox.Show("Введите в поле ниже номер страницы");
                }
            } else
            {
                MessageBox.Show("Выберите указатель из списка");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text!="")
            {
                if (Indicator.GetPagesByWord(indicators, textBox3.Text).Length!=0)
                {
                    uint[] pages = Indicator.GetPagesByWord(indicators, textBox3.Text);
                    string pagess = "";
                    foreach (uint page in pages)
                    {
                        if (page != 0) pagess += page.ToString() + " ";
                    }
                    MessageBox.Show($"Страницы на которых встречается введённое слово\n{pagess}");
                } else { 
                    MessageBox.Show("Введённое слово не найдено");
                }
            } else
            {
                MessageBox.Show("Введите слово в поле ниже");
            }
        }
    }
}
