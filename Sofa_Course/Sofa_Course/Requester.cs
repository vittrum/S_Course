using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Windows.Forms;


namespace Sofa_Course {
    class Requester {
        
        #region admin
        public void SettleStudent(Factory factory, string name, string lastname,
            string father_name, int course, string specialty, string invoice,
            string sanpass, int category, int room
            ) {
            factory.admin.SettleStudent(name, lastname, father_name, course,
                    specialty, invoice, sanpass, category, room);
        }

        internal void ShowStudents(Factory factory, DataGridView dgvCareStudents)
        {
            foreach (var i in factory.watchman.PassStudent("", ""))
            {
                dgvCareStudents.Rows.Add(i.ID, i.Name, i.Lastname, i.FatherName, i.Specialty, i.Course);
            }
        }
        public void KickStudent(Factory factory, int student_id) {
            factory.admin.KickStudent(student_id);
        }
        public void SetPenalty(Factory factory, int violation_id, string penalty) {
            factory.admin.SetPenalty(violation_id, penalty);
        }
        public void GetViolations(Factory factory, DataGridView dataGridView)
        {
            //foreach (var i in factory.admin.GetViolations())
            {

            }
        }        
        #endregion 
        
        #region watchman
        public void PassStudent (Factory factory, DataGridView dgv, string name, string lastname) {   
            foreach (var i in factory.watchman.PassStudent(name, lastname))
            {
                dgv.Rows.Add(i.ID, i.Name, i.Lastname, i.FatherName, i.SanitaryPass, i.Specialty);
            }
        }
        
        public void PassGuest (Factory factory, string name, 
            string lastname, string father_name, string adress, int room_id) {
            factory.watchman.PassGuest(name, lastname, father_name, adress, room_id);
        }
        
        #endregion

        
        #region caretaker

        public void GiveLinens(Factory factory, string student_id, string linens_id) {
            factory.caretaker.GiveLinens(linens_id, student_id);
        }

        public void ReturnLinens(Factory factory, string linens_id) {
            factory.caretaker.ReturnLinens(linens_id);
        }

        public void GetLinens(Factory factory, DataGridView dgv) {
            foreach (var i in factory.caretaker.GetLinens())
            {
                dgv.Rows.Add(i.Id, i.IdStud, i.GrantDate, i.RevokeDate);                
            }
        }

        public void GetFreeLinens(Factory factory, ComboBox combo)
        {
            foreach (var i in factory.caretaker.GetFreeLinens())
            {
                combo.Items.Add(i);
            }
        }
        #endregion

        
        #region student 

        public void ShowLivingStudents(Factory factory, DataGridView dgv, string course, string specialty) {
            foreach (var i in factory.student.GetStudentByFilters(course, specialty))
            {
                dgv.Rows.Add(i.ID, i.Name, i.Lastname, i.FatherName, i.Course, i.Specialty);
            }
        }

        public void CreateRepairRequest(Factory factory, string stud_id, string repair_text, string type) {
            factory.student.CreateRepairRequest(stud_id, repair_text, type);
        }

        public void ConfirmRepairs (Factory factory, string repair_id) {
            factory.student.ConfirmRepairs(repair_id);
        }
        
        public void ShowStudentsRequest(Factory factory, DataGridView dgv, string stud_id) {
            foreach (var i in factory.student.ShowStudentsRequest(stud_id))
            {
                dgv.Rows.Add(i.Id, i.Type, i.Desc, i.Date_App);
            }
        }

        #endregion

        // Techpersonal
        public void ShowRepairRequests(Factory factory, DataGridView dgv) {
            foreach (var i in factory.staff.GetAllRequests())
            {
                dgv.Rows.Add(i.Id, i.Id_room, i.Type, i.Desc, i.Date_App, i.Date_Comp);
            }
        }

        // Violation 
        public void CreateViolation(Factory factory, string id_stud, string type, string fact)
        {
            factory.violation.CreateReport(id_stud, type, fact);
        }

        // Auth
        internal string GetId(Factory factory, string role, string login)
        {
            return factory.login.GetId(login, role);
        }

        internal string CheckRole(Factory factory, string login)
        {
            return factory.login.Check_Role(login);
        }
    }
}
