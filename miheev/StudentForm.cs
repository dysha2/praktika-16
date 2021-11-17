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
    public partial class StudentForm : Form
    {
        List<StudentsGroup> Groups = new List<StudentsGroup>();
        AddStudentForm addStudForm;
        AddGroupForm addGroupForm;
        public StudentForm()
        {
            InitializeComponent();
            addStudForm = new AddStudentForm(this);
            addGroupForm = new AddGroupForm(this);
        }

        private void ThisClose(object sender, FormClosingEventArgs e)
        {
            addStudForm.Close();
            addGroupForm.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            addGroupForm.ShowDialog();
        }
        public void AddGroup(string GroupName)
        {
            StudentsGroup group = new StudentsGroup(GroupName);
            Groups.Add(group);
            UpdateListBox();
        }
        public void AddStudent(Student student)
        {
            if (listBox1.SelectedItem != null)
            {
                Groups[listBox1.SelectedIndex].AddStudent(student);
                UpdateDataGrid();
            }
            else
            {
                MessageBox.Show("Выберите группу");
            }
        }
        public void FindStudent(string surname)
        {

        }
        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            Groups.ForEach(x => listBox1.Items.Add(x.Group));
        }
        private void UpdateDataGrid()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < Groups[listBox1.SelectedIndex].Students.Count;i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i].Clone(); 
                row.Cells[0].Value = Groups[listBox1.SelectedIndex].Students[i].surname; 
                row.Cells[1].Value = Groups[listBox1.SelectedIndex].Students[i].name;
                row.Cells[2].Value = Groups[listBox1.SelectedIndex].Students[i].patronymic;
                row.Cells[3].Value = Groups[listBox1.SelectedIndex].Students[i].dateofbirth;
                row.Cells[4].Value = Groups[listBox1.SelectedIndex].Students[i].phonenumber;
                dataGridView1.Rows.Add(row);
            }
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                UpdateDataGrid();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem!=null)
            {
                addStudForm.ShowDialog();
            } else
            {
                MessageBox.Show("Выберите группу");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                if (radioButton1.Checked) Groups[listBox1.SelectedIndex].SortStudentsByName();
                else if (radioButton2.Checked) Groups[listBox1.SelectedIndex].SortStudentsBySurname();
                else if (radioButton3.Checked) Groups[listBox1.SelectedIndex].SortStudentsByDateOfBirth();
                UpdateDataGrid();
            }
            else
            {
                MessageBox.Show("Выберите группу");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((dataGridView1.CurrentRow!=null)&&(dataGridView1.CurrentRow.Index< Groups[listBox1.SelectedIndex].Students.Count))
            {
                Groups[listBox1.SelectedIndex].RemoveStudent(dataGridView1.CurrentRow.Index);
                UpdateDataGrid();
            }
            else
            {
                MessageBox.Show("Выберите строку со студентом");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Groups[listBox1.SelectedIndex].FindStudentBySurname(textBox1.Text)!=-1)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++) dataGridView1.Rows[i].Selected = false;
                dataGridView1.Rows[Groups[listBox1.SelectedIndex].FindStudentBySurname(textBox1.Text)].Selected = true;
            }
        }
    }
}
