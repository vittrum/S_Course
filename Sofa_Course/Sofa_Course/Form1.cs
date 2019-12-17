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
        }

        Requester requester = new Requester();
        Factory factory = new Factory();
        string login;

        #region Student
        private void BtnShowStudents_Click(object sender, EventArgs e) {
            FillDgvStudents();
            requester.Show_Living_Students(factory, dgvShowStudents);
        }
        private void BtnCreateRequestStudent_Click(object sender, EventArgs e) {
            requester.Create_Repair_Request(factory, login, tbTypeOfRepair.Text);
        }
        private void BtnConfirmStudent_Click(object sender, EventArgs e) {
            requester.Confirm_repairs(factory, login, comboMyRepairs.SelectedItem.ToString());
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
            dgvStaffShowRequests.Columns.Add("date", "Дата подачи");
            dgvStaffShowRequests.Columns.Add("text", "Тема");
        }

        public void FillDgvLinens() {
            dgvLinens.Columns.Clear();
            dgvLinens.Columns.Add("id_lin", "Номер белья");
            dgvLinens.Columns.Add("id_stud", "Номер билета");
            dgvLinens.Columns.Add("date_", "Дата выдачи");
            dgvLinens.Columns.Add("room", "Номер комнаты");

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
            dgvWatchGuests.Columns.Add("lname", "Фамилия");
            dgvWatchGuests.Columns.Add("patr", "Отчество");
            dgvWatchGuests.Columns.Add("place", "Прописка");
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
                comboLinensId.SelectedItem.ToString(),
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
            requester.Pass_student(factory, tbWatchIdFind.Text);
            FillDgvWatcher();
            requester.Show_Living_Students(factory, dgvWatchIdFind);
        }

        private void BtnPassGuest_Click(object sender, EventArgs e) {
            requester.Pass_Guest(factory, tbGuestId.Text, tbGuestName.Text, tbGuestSurname.Text,
                tbGuestPatr.Text, tbGuestHome.Text);
            FillDgvWatchGuests();
            requester.Show_Guests(factory, dgvWatchGuests);
        }

        private void BtnShowGuests_Click(object sender, EventArgs e) {
            FillDgvWatchGuests();
            requester.Show_Guests(factory, dgvWatchGuests);
        }
        #region Zaveduyuschii
        private void BtnSettle_Click(object sender, EventArgs e) {
            requester.Settle_Student(factory, tbZavName.Text, tbZavSurname.Text,
                tbZavPatr.Text, tbZavStudNum.Text, tbPaycheck.Text,
                tbSanprop.Text, tbRoomNum.Text);
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
            requester.Send_Report(factory, tbReportNum.Text, tbTextReport.Text);
        }

        
    }
}
