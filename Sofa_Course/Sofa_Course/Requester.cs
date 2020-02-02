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
        #region zaveduyschii
        public void Settle_Student(Factory factory, string name, string surname,
            string patronymic, string id, string id_pay, string sanitar, string id_room,
            string fac, string spec, string priv, string set_date) {
            factory.student.Settle_Student(name, surname, patronymic, id, id_pay, sanitar,
                id_room, fac, spec, priv, set_date);
        }
        public void Kick_Student(Factory factory, string id_stud) {
            factory.student.Kick_Student(id_stud);
        }
        public void Set_Penalty(Factory factory, string id_pen, string type) {
            factory.report.SetPenalty(id_pen, type);
        }
        #endregion 
        // 1?????????
        #region vachter

        public void Pass_student (Factory factory, DataGridView dgv, string id_stud) {
            foreach (var i in factory.student.Get_Student_By_Pass(id_stud))
                dgv.Rows.Add(i.ID, i.Name, i.Surname, i.Patronymic, i.Faculty, i.Specialty);            
        }
        /*
        public void Pass_Guest (Factory factory, string id_stud, string name, 
            string surname, string patronymic, string place) {
            //factory.guest
        }
        public void Leave_Guest (Factory factory, string leavetime, string id_visit) {

        }*/
        public void Create_Violation (Factory factory, string id_stud, string type, 
            string date) {

        }
        #endregion
        //
        #region zavchoz

        public void Give_Linens(Factory factory, string id_stud, string id_linens, string date) {
            factory.linens.GiveLinens(id_linens, id_stud, date);
        }

        public void Return_Linens(Factory factory, string id_linens) {
            factory.linens.ReturnLinens(id_linens);
        }

        public void GetLinens(Factory factory, DataGridView dgv) {
            foreach (var i in factory.linens.GetLinens())
                dgv.Rows.Add(i.Id, i.Id_stud, i.Date);
        }
        #endregion
        //
        #region student 

        public void Show_Living_Students(Factory factory, DataGridView dgv, string name, string surname) {
            foreach (var i in factory.student.Get_Student_By_Name(name, surname))
                dgv.Rows.Add(i.ID, i.Name, i.Surname, i.Patronymic, i.Faculty, i.Specialty);
        }

        public void Create_Repair_Request(Factory factory, string id_stud, string repair_text) {
            factory.repair.CreateRequest(id_stud, repair_text);
        }

        public void Confirm_repairs (Factory factory, string id_stud, string id_repair, string date) {
            factory.repair.Confirm_request(id_repair, date);
            MessageBox.Show(id_repair);
            MessageBox.Show(date);
        }
        public void Show_Students_Request(Factory factory, DataGridView dgv, string id) {
            foreach (var i in factory.repair.GetRepairsById(id)) {
                //MessageBox.Show("Working in requester");
                dgv.Rows.Add(i.Id, i.Id_room, i.Desc);
            }
        }

        #endregion

        // Techpersonal

        public void Show_Repair_Requests(Factory factory, DataGridView dgv) {
            foreach (var i in factory.repair.GetRepairs()) {
                //MessageBox.Show("Working in requester");
                dgv.Rows.Add(i.Id, i.Id_room, i.Desc, i.Date_App, i.Date_Comp);
            }
        }

        // Остальное
        public void Send_Report (Factory factory, string id_stud, string text, string date) {
            factory.report.CreateReport(id_stud, text, date);
        }

        public void Show_Guests(Factory factory, DataGridView dgv) {

        }


    }
}
