using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Course.Tables {
    class Student {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string FatherName { get; set; }
        public string Specialty { get; set; }
        public string Course { get; set; }
        public string Invoice { get; set; }
        public string SanitaryPass { get; set; }
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }

        public Student(
            string id, 
            string name, 
            string lastname,
            string fatherName, 
            string specialty,
            string course,
            string invoice, 
            string sanPass,
            string categoryId,
            string categoryName) {
            ID = id;
            Name = name;
            Lastname = lastname;
            FatherName = fatherName;
            Specialty = specialty;
            Course = course;
            Invoice = invoice;
            SanitaryPass = sanPass;
            CategoryID = categoryId;
            CategoryName = categoryName;
        }
        public Student(
            string id,
            string name,
            string lastname,
            string fatherName,
            string specialty,
            string course)
        {
            ID = id;
            Name = name;
            Lastname = lastname;
            FatherName = fatherName;
            Specialty = specialty;
            Course = course;
        }
    }
}
