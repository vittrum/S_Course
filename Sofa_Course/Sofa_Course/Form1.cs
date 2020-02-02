using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sofa_Course {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            Init();
        }
        private void Init() {
            FillDgvStaffRequests2();
            requester.Show_Students_Request(factory, dgvStudentRequest, login);
        }
        Requester requester = new Requester();
        Factory factory = new Factory("127.0.0.1", "5432", "postgres", "1", "sofa");
        string login = "201";

        #region Student
        private void BtnShowStudents_Click(object sender, EventArgs e) {
            FillDgvStudents();
            requester.Show_Living_Students(factory, dgvShowStudents, tbNameStudent.Text, tbSurnameStudent.Text);
        }
        private void BtnCreateRequestStudent_Click(object sender, EventArgs e) {
            requester.Create_Repair_Request(factory, login, tbTypeOfRepair.Text);
            FillDgvStaffRequests2();
            requester.Show_Students_Request(factory, dgvStudentRequest, login);
        }
        private void BtnConfirmStudent_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow row in dgvStudentRequest.SelectedRows) {
                requester.Confirm_repairs(factory, login, row.Cells["id_req"].Value.ToString(), dateRequest.Value.ToShortDateString());
                dgvStudentRequest.Rows.Remove(row);
            }
        }
        #endregion

        #region DgvFill

        public void FillDgvStudents() {
            dgvShowStudents.Columns.Clear();
            dgvShowStudents.Columns.Add("id", "Номер");
            dgvShowStudents.Columns.Add("name", "Имя");
            dgvShowStudents.Columns.Add("lastname", "Фамилия");
            dgvShowStudents.Columns.Add("patr", "Отчество");
            dgvShowStudents.Columns.Add("fac", "Факультет");
            dgvShowStudents.Columns.Add("spec", "Специальность");
        }

        public void FillDgvStaffRequests() {
            dgvStaffShowRequests.Columns.Clear();
            dgvStaffShowRequests.Columns.Add("id_req", "Номер заявки");
            dgvStaffShowRequests.Columns.Add("id_room", "Номер комнаты");
            dgvStaffShowRequests.Columns.Add("text", "Тема");
            dgvStaffShowRequests.Columns.Add("dateb", "Дата подачи");
            dgvStaffShowRequests.Columns.Add("datee", "Дата вып");
        }
        public void FillDgvStaffRequests2() {
            dgvStudentRequest.Columns.Clear();
            dgvStudentRequest.Columns.Add("id_req", "Номер заявки");
            dgvStudentRequest.Columns.Add("id_room", "Номер комнаты");
            dgvStudentRequest.Columns.Add("text", "Тема");
            dgvStudentRequest.Columns.Add("dateb", "Дата подачи");
            dgvStudentRequest.Columns.Add("datee", "Дата вып");
        }

        public void FillDgvLinens() {
            dgvLinens.Columns.Clear();
            dgvLinens.Columns.Add("id_lin", "Номер белья");
            dgvLinens.Columns.Add("id_stud", "Номер билета");
            dgvLinens.Columns.Add("date_", "Дата выдачи");
            //dgvLinens.Columns.Add("room", "Номер комнаты");
        }

        public void FillDgvWatcher() {
            dgvWatchIdFind.Columns.Clear();
            dgvWatchIdFind.Columns.Add("id", "Номер");
            dgvWatchIdFind.Columns.Add("name", "Имя");
            dgvWatchIdFind.Columns.Add("lastname", "Фамилия");
            dgvWatchIdFind.Columns.Add("patr", "Отчество");
            dgvWatchIdFind.Columns.Add("fac", "Факультет");
            dgvWatchIdFind.Columns.Add("spec", "Специальность");
        }

        public void FillDgvWatchGuests() {
            dgvWatchGuests.Columns.Clear();
            dgvWatchGuests.Columns.Add("id_stud", "Номер студента");
            dgvWatchGuests.Columns.Add("name", "Имя");
            dgvWatchGuests.Columns.Add("room", "Комната");
            dgvWatchGuests.Columns.Add("reg", "Прописка");
            dgvWatchGuests.Columns.Add("date", "Время");
        }


        #endregion

        // Техперсонал
        private void BtnStaffRefresh_Click(object sender, EventArgs e) {
            FillDgvStaffRequests();
            requester.Show_Repair_Requests(factory, dgvStaffShowRequests);
        }
        // Завхоз
        private void BtnGuveLinens_Click(object sender, EventArgs e) {
            requester.Give_Linens(factory, tbLinensStudent.Text,
                tbLinensId.Text,
                dateLinensGive.Value.ToShortDateString());
            FillDgvLinens();
            requester.GetLinens(factory, dgvLinens);
        }

        private void BtnGetLinens_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow row in dgvLinens.SelectedRows)
                requester.Return_Linens(factory, row.Cells["id_lin"].Value.ToString());
            FillDgvLinens();
            requester.GetLinens(factory, dgvLinens);
        }
        // Вахтёр
        private void BtnPassStudent_Click(object sender, EventArgs e) {
            FillDgvWatcher();
            requester.Pass_student(factory, dgvWatchIdFind, tbWatchIdFind.Text);
            
            //requester.Show_Living_Students(factory, dgvWatchIdFind);
        }

        private void BtnPassGuest_Click(object sender, EventArgs e) {
           /** requester.Pass_Guest(factory, tbGuestId.Text, tbGuestName.Text, tbGuestSurname.Text,
                tbGuestPatr.Text, tbGuestHome.Text);
            FillDgvWatchGuests();
            requester.Show_Guests(factory, dgvWatchGuests);*/
        }

        private void BtnShowGuests_Click(object sender, EventArgs e) {
           /* FillDgvWatchGuests();
            requester.Show_Guests(factory, dgvWatchGuests);*/
        }
        #region Zaveduyuschii
        private void BtnSettle_Click(object sender, EventArgs e) {
            requester.Settle_Student(factory, 
                tbZavName.Text, 
                tbZavSurname.Text,
                tbZavPatr.Text,
                tbZavStudNum.Text, 
                tbPaycheck.Text,
                dateSani.Value.ToShortDateString(), 
                tbRoomNum.Text, 
                tbZavFac.Text, 
                tbZavSpec.Text, 
                comboPrivName.SelectedItem.ToString(),
                dateSettle.Value.ToShortDateString());
        }
        private void BtnSetPen_Click(object sender, EventArgs e) {
            requester.Set_Penalty(factory, comboOtrabotki.SelectedItem.ToString(), tbSetPen.Text);
        }
        private void BtnKick_Click(object sender, EventArgs e) {
            requester.Kick_Student(factory, tbIdKick.Text);
        }

        #endregion
        // Заявка о нарушении
        private void BtnSendReport_Click(object sender, EventArgs e) {
            requester.Send_Report(factory, tbReportNum.Text, tbTextReport.Text, dateViolation.Value.ToShortDateString());
        }

        private void label9_Click(object sender, EventArgs e) {

        }
    }
}
