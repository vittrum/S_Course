using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Course.Tables {
    class Linens {
        public string Id { get; set; }
        public string GrantDate { get; set; }
        public string RevokeDate { get; set; }
        public string IdStud { get; set; }
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }


        public Linens (string id, string stud, string grant_date, string revoke_date,
            string name, string lastname) {
            Id = id;
            IdStud = stud;
            GrantDate = grant_date;
            RevokeDate = revoke_date;
            StudentName = name;
            StudentLastName = lastname;
        }
    }
}
