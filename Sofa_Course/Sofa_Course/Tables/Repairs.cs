using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Course.Tables {
    class Repairs {
        public string Id { get; set; }
        public string Id_room { get; set; }
        public string Type { get; set; }
        public string Desc { get; set; }
        public string Date_App { get; set; }
        public string Date_Comp { get; set; }
        public string IdStud { get; set; }

        public Repairs (string id, string id_room, string type, string desc,
            string bdate, string edate) {
            Id = id;
            Id_room = id_room;
            Desc = desc;
            Type = type;
            Date_App = bdate;
            Date_Comp = edate;
        }
        public Repairs(string id, string type, string theme, string request_date, string student_id) {
            Id = id;
            IdStud = student_id;
            Desc = theme;
            Type = type;
            Date_App = request_date;
        }
    }
}
