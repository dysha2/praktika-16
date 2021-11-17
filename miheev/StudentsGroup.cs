using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miheev
{
    class StudentsGroup
    {
        private string group;
        private List<Student> ListStudents = new List<Student>();

        public string Group
        {
            get => group;
        }
        public List<Student> Students
        {
            get => ListStudents;
        }
        public StudentsGroup (string groupName)
        {
            group = groupName;
        }
        public int FindStudentBySurname(string surname)
        {
            int count = 0;
            foreach (Student st in ListStudents)
            {
                if (st.surname.ToLower().StartsWith(surname.ToLower())) return count;
                ++count;
            }
            return -1;
        }
        public void SortStudentsBySurname()
            => ListStudents = ListStudents.OrderBy(student => student.surname).ToList();
        public void SortStudentsByName()
            => ListStudents = ListStudents.OrderBy(student => student.name).ToList();
        public void SortStudentsByDateOfBirth()
            => ListStudents=ListStudents.OrderBy(student => student.dateofbirth).ToList();
        public void AddStudent(Student st) => ListStudents.Add(st);
        public void RemoveStudent(Student st) => ListStudents.Remove(st);
        public void RemoveStudent(int index) => ListStudents.RemoveAt(index);
    }
}
