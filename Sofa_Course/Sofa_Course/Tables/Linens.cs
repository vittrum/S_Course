using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Course.Tables {
    class Linens {
        public string Id { get; set; }
        public string Id_stud { get; set; }
        public string Date { get; set; }

        public Linens (string id, string stud, string date) {
            Id = id;
            Id_stud = stud;
            Date = date;
        }
    }
}
