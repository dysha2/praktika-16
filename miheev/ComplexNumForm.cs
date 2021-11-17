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
    public partial class ComplexNumForm : Form
    {
        public ComplexNumForm()
        {
            InitializeComponent();
        }

        private void ComplexNumForm_Load(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = radioButton2.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = radioButton3.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != ""))
            {
                int a, b;
                if ((int.TryParse(textBox1.Text,out a))&& (int.TryParse(textBox2.Text, out b)))
                {
                    ComplexNumber nComplex = new ComplexNumber { Num1 = a, Num2 = b };
                    switch (label2.Text)
                    {
                        case "+":
                            textBox3.Text = nComplex.Addition().ToString()+"i";
                            break;
                        case "-":
                            textBox3.Text = nComplex.Subtraction().ToString() + "i";
                            break;
                        case "*":
                            textBox3.Text = nComplex.Multiplication().ToString();
                            break;
                        default: MessageBox.Show("Выберете действие");
                            break;
                    }
                } else
                {
                    MessageBox.Show("Вводите только целые числа");
                }
            } else
            {
                MessageBox.Show("Заполните оба поля");
            }
        }
    }
}
