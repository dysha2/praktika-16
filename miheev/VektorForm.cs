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
    public partial class VektorForm : Form
    {
        List<Vektors> vektors = new List<Vektors>();
        public VektorForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void VektorForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x1, y1, z1, x2, y2, z2;
            if ((int.TryParse(textBox1.Text,out x1))&& 
                (int.TryParse(textBox2.Text, out y1))&& 
                (int.TryParse(textBox3.Text, out z1))&& 
                (int.TryParse(textBox4.Text, out x2))&& 
                (int.TryParse(textBox5.Text, out y2))&& 
                (int.TryParse(textBox6.Text, out z2)))
            {
                Vektors vector = new Vektors(x1, y1, z1, x2, y2, z2);
                vektors.Add(vector);
                textBoxesClear();
                ListBoxUpdate();
            } else
            {
                MessageBox.Show("Заполните все поля целыми числами");
            }
        }
        private void textBoxesClear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }
        private void ListBoxUpdate()
        {
            listBox1.Items.Clear();
            int count = 1;
            foreach( Vektors vect in vektors)
            {
                listBox1.Items.Add($"{count} вектор: x={vect.X} y={vect.Y} z={vect.Z}");
                count++;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                vektors.Add(Vektors.Addition(
                    vektors[int.Parse(textBox7.Text[0].ToString())-1], 
                    vektors[int.Parse(textBox8.Text[0].ToString())-1]));
                ListBoxUpdate();
            } else
            {
                if (radioButton2.Checked)
                {
                    vektors.Add(Vektors.Subtraction(
                        vektors[int.Parse(textBox7.Text[0].ToString()) - 1],
                        vektors[int.Parse(textBox8.Text[0].ToString()) - 1]));
                    ListBoxUpdate();
                } else
                {
                    if (radioButton3.Checked)
                    {
                        double otv = Vektors.scalarMultiplication(
                            vektors[int.Parse(textBox7.Text[0].ToString()) - 1],
                            vektors[int.Parse(textBox8.Text[0].ToString()) - 1]);
                        MessageBox.Show($"Скалярное произведение 2 выбранных векторов =\n{otv}");
                    } else
                    {
                        if (radioButton4.Checked)
                        {
                            double otv = Vektors.Cos(
                                vektors[int.Parse(textBox7.Text[0].ToString()) - 1],
                                vektors[int.Parse(textBox8.Text[0].ToString()) - 1]);
                            MessageBox.Show($"Косинус угла между 2 выбранными векторами =\n{otv}");
                        }
                    }
                }
            }
            textBoxesClear();
            button4.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((listBox1.SelectedItem!=null)||(textBox7.Text!=""))
            {
                textBox7.Text = listBox1.SelectedItem.ToString();
            } else
            {
                MessageBox.Show("Выберете вектор из таблицы");
            }
            if ((textBox7.Text!="")&&(textBox8.Text!=""))
            {
                button4.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((listBox1.SelectedItem != null) || (textBox8.Text != ""))
            {
                textBox8.Text = listBox1.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Выберете вектор из таблицы");
            }
            if ((textBox7.Text != "") && (textBox8.Text != ""))
            {
                button4.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            { 
                MessageBox.Show($"Длина выбранного вектора =\n{vektors[int.Parse(listBox1.SelectedItem.ToString()[0].ToString())-1].GetLength()}");
            }
            else
            {
                MessageBox.Show("Выберете вектор из таблицы");
            }
        }
    }
}
