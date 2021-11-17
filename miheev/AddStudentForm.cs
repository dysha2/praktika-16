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
    public partial class AddStudentForm : Form
    {
        StudentForm form;
        public AddStudentForm(StudentForm f)
        {
            InitializeComponent();
            form = f;
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {

        }
        private void ThisClose(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text!="") &&(textBox2.Text != "")&&(textBox3.Text != "")&&(textBox4.Text != ""))
            {
                Student st = new Student();
                st.dateofbirth = dateTimePicker1.Text;
                st.name = textBox1.Text;
                st.surname = textBox2.Text;
                st.patronymic = textBox3.Text;
                st.phonenumber = textBox4.Text;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                form.AddStudent(st);
            } else
            {
                MessageBox.Show("Заполните все поля. Если нечем заполнять, то поставьте прочерк");
            }

        }
    }
}
