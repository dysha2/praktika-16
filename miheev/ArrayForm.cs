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
    public partial class ArrayForm : Form
    {
        List<Array> arrays = new List<Array>();
        public ArrayForm()
        {
            InitializeComponent();
        }

        private void ArrayForm_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem!=null)
            {
                textBox1.Text = arrays[listBox1.SelectedIndex].ForPrint();
            } else
            {
                textBox1.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint a;
            if (uint.TryParse(textBox5.Text,out a))
            {
                Array arr = new Array(a);
                arrays.Add(arr);
                listBoxUpdate();
            } else
            {
                MessageBox.Show("В поле некорректные данные");
            }
        }
        private void listBoxUpdate()
        {
            listBox1.Items.Clear();
            int count = 1;
            foreach (Array arr in arrays)
            {
                listBox1.Items.Add($"{count} массив");
                count++;
            }
            if (listBox1.SelectedItem != null)
            {
                textBox1.Text = arrays[listBox1.SelectedIndex].ForPrint();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem!=null)
            {
                int a;
                if (int.TryParse(textBox3.Text, out a))
                {
                    textBox4.Text=arrays[listBox1.SelectedIndex].GetElement(a).ToString();
                    textBox3.Clear();
                } else
                {
                    MessageBox.Show("В поле некорректные данные");
                }
            } else
            {
                MessageBox.Show("Выберите массив");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                int num,index;
                if ((int.TryParse(textBox2.Text, out index))&& (int.TryParse(textBox6.Text, out num)))
                {
                    arrays[listBox1.SelectedIndex].AddElement(num,index);
                    int listindex = listBox1.SelectedIndex;
                    listBoxUpdate();
                    listBox1.SelectedIndex = listindex;
                    textBox2.Clear();
                    textBox6.Clear();
                }
                else
                {
                    MessageBox.Show("В поле некорректные данные");
                }
            }
            else
            {
                MessageBox.Show("Выберите массив");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                int num;
                if (int.TryParse(textBox7.Text, out num))
                {
                    arrays[listBox1.SelectedIndex].MultiplicationOnNumb(num);
                    int listindex = listBox1.SelectedIndex;
                    listBoxUpdate();
                    listBox1.SelectedIndex = listindex;
                    textBox7.Clear();
                }
                else
                {
                    MessageBox.Show("В поле некорректные данные");
                }
            }
            else
            {
                MessageBox.Show("Выберите массив");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                textBox9.Text = listBox1.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Выберите массив");
            }
            if ((textBox8.Text != "") && (textBox9.Text != "")) button7.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                textBox8.Text = listBox1.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Выберите массив");
            }
            if ((textBox8.Text != "") && (textBox9.Text != "")) button7.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                int[] mas = Array.AdditionArrays(
                    arrays[int.Parse(textBox9.Text[0].ToString()) - 1],
                    arrays[int.Parse(textBox8.Text[0].ToString()) - 1]);
                Array arr = new Array(uint.Parse(mas.Length.ToString()));
                arr.SetMas(mas);
                arrays.Add(arr);

            } else
            {
                if (radioButton1.Checked)
                {
                    int[] mas = Array.SubtractionArrays(
                    arrays[int.Parse(textBox9.Text[0].ToString()) - 1],
                    arrays[int.Parse(textBox8.Text[0].ToString()) - 1]);
                    Array arr = new Array(uint.Parse(mas.Length.ToString()));
                    arr.SetMas(mas);
                    arrays.Add(arr);
                }
            }
            textBox8.Clear();
            textBox9.Clear();
            listBoxUpdate();
            button7.Enabled = false;
        }
    }
}
