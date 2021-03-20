using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Windows.Forms;


namespace Sofa_Course {
    class Requester {
        //++
        #region admin
        public void SettleStudent(Factory factory, string name, string lastname,
            string father_name, int course, string specialty, string invoice,
            string sanpass, int category, int room
            ) {
            factory.student.SettleStudent(
                    name,
                    lastname,
                    father_name,
                    course,
                    specialty,
                    invoice,
                    sanpass,
                    category,
                    room);
        }
        public void KickStudent(Factory factory, string student_id) {
            //factory.student.Kick_Student(id_stud);
        }
        public void SetPenalty(Factory factory, string violation_id, string penalty) {
            //factory.report.SetPenalty(id_pen, type);
        }
        #endregion 
        // 
        #region watchman
        public void PassStudent (Factory factory, DataGridView dgv, string name, string lastname) {   
            //
        }
        
        public void PassGuest (Factory factory, string name, 
            string lastname, string father_name, string adress, string room_id) {
            //factory.guest
        }
        
        #endregion
        //
        #region caretaker

        public void GiveLinens(Factory factory, string student_id, string linens_id) {
            //factory.linens.GiveLinens(id_linens, id_stud, date);
        }

        public void ReturnLinens(Factory factory, string linens_id) {
           // factory.linens.ReturnLinens(id_linens);
        }

        public void GetLinens(Factory factory, DataGridView dgv) {
            //
        }
        #endregion
        //
        #region student 

        public void ShowLivingStudents(Factory factory, DataGridView dgv, string course, string specialty) {
            //foreach (var i in factory.student.Get_Student_By_Name(name, surname))
            //    dgv.Rows.Add(i.ID, i.Name, i.Lastname, i.FatherName, i.Faculty, i.Specialty);
        }

        public void CreateRepairRequest(Factory factory, string stud_id, string repair_text, string type) {
            //factory.repair.CreateRequest(id_stud, repair_text);
        }

        public void ConfirmRepairs (Factory factory, string repair_id) {
            //factory.repair.Confirm_request(id_repair, date);
        }
        
        public void ShowStudentsRequest(Factory factory, DataGridView dgv, string stud_id) {
            
        }

        #endregion

        // Techpersonal
        public void ShowRepairRequests(Factory factory, DataGridView dgv) {
            //foreach (var i in factory.repair.GetRepairs()) {
            //    //MessageBox.Show("Working in requester");
            //    dgv.Rows.Add(i.Id, i.Id_room, i.Desc, i.Date_App, i.Date_Comp);
            //}
        }

        public void CreateViolation(Factory factory, string id_stud, string type, string fact)
        {

        }
    }
}
