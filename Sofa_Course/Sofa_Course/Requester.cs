using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Windows.Forms;


namespace Sofa_Course {
    class Requester {
        #region zaveduyschii
        public void Settle_Student(Factory factory, string name, string surname,
            string patronymic, string id, string id_pay, string sanitar, string id_room) {

        }
        public void Kick_Student(Factory factory, string id_stud) {

        }
        public void Set_Penalty(Factory factory, string id_pen, string type) {

        }
        #endregion

        #region vachter

        public void Pass_student (Factory factory, string id_stud) {

        }

        public void Pass_Guest (Factory factory, string id_stud, string name, 
            string surname, string patronymic, string place) {

        }
        public void Leave_Guest (Factory factory, string leavetime, string id_visit) {

        }
        public void Create_Violation (Factory factory, string id_stud, string type, 
            string date) {

        }
        #endregion

        #region zavchoz

        public void Give_Linens(Factory factory, string id_stud, string id_linens, string date) {

        }

        public void Return_Linens(Factory factory, string id_linens) {

        }

        public void GetLinens(Factory factory, DataGridView dgv) {

        }
        #endregion

        #region student 

        public void Show_Living_Students(Factory factory, DataGridView dgv) {

        }

        public void Create_Repair_Request(Factory factory, string id_stud, string repair_text) {

        }

        public void Confirm_repairs (Factory factory, string id_stud, string id_repair) {

        }

        #endregion

        // Techpersonal

        public void Show_Repair_Requests(Factory factory, DataGridView dgv) {

        }

        // Остальное
        public void Send_Report (Factory factory, string id_stud, string text) {

        }

        public void Show_Guests(Factory factory, DataGridView dgv) {

        }


    }
}
