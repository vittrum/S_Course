using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Course.Tables {
    class Student {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Faculty { get; set; }
        public string Specialty { get; set; }

        public Student(string id, string name, string surname,
            string patronymic, string faculty, string specialty) {
            ID = id;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Faculty = faculty;
            Specialty = specialty;
        }
    }
}
