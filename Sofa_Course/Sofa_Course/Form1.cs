using System;
using System.Windows.Forms;

namespace Sofa_Course
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            Init();
        }
        private void Init() {
            FillDgvStudentRequests(dgvStudentRequest);
            requester.ShowStudentsRequest(factory, dgvStudentRequest, login);
        }
        Requester requester = new Requester();
        Factory factory = new Factory("127.0.0.1", "5432", "postgres", "1", "dormitory");
        string login = "1";

        #region Student
        private void BtnShowStudents_Click(object sender, EventArgs e) {
            FillDgvStudentsShort(dgvShowStudents);
            string course = ComboStudCourse.Text;
            string specialty = ComboStudSpec.Text;
            requester.ShowLivingStudents(factory, dgvShowStudents, course, specialty);
        }
        private void BtnCreateRequestStudent_Click(object sender, EventArgs e) {
            requester.CreateRepairRequest(factory, login, tbTypeOfRepair.Text, "поломка");
            FillDgvStudentRequests(dgvStudentRequest);
            requester.ShowStudentsRequest(factory, dgvStudentRequest, login);
        }
        private void BtnConfirmStudent_Click(object sender, EventArgs e) {
            string repair_id = dgvStudentRequest.SelectedRows[0].Cells[0].Value.ToString();
            if (repair_id != "")
            {
                requester.ConfirmRepairs(factory, repair_id);
                FillDgvStudentRequests(dgvStudentRequest);
                requester.ShowStudentsRequest(factory, dgvStudentRequest, login);
            }            
        }
        #endregion

        #region DgvFill

        // Для студентов, завхоза, вахтёра, заведующего
        public void FillDgvStudentsShort(DataGridView dgv) {
            dgv.Columns.Clear();
            dgv.Columns.Add("id", "Номер");
            dgv.Columns.Add("name", "Имя");
            dgv.Columns.Add("lastname", "Фамилия");
            dgv.Columns.Add("patr", "Отчество");
            dgv.Columns.Add("fac", "Факультет");
            dgv.Columns.Add("spec", "Курс");
        }
        // Для Техперсонала
        public void FillDgvStaffRequests(DataGridView dgv) {
            dgv.Columns.Clear();
            dgv.Columns.Add("id_req", "Номер заявки");
            dgv.Columns.Add("id_room", "Номер комнаты");
            dgv.Columns.Add("type", "Тип");
            dgv.Columns.Add("theme", "Тема");
            dgv.Columns.Add("date_b", "Дата подачи");
            dgv.Columns.Add("date_e", "Дата выполнения");
        }
        // Для студентов
        public void FillDgvStudentRequests(DataGridView dgv) {
            dgv.Columns.Clear();
            dgv.Columns.Add("id_req", "Номер заявки");
            dgv.Columns.Add("type", "Тип");
            dgv.Columns.Add("theme", "Тема");
            dgv.Columns.Add("date_b", "Дата подачи");
        }
        // Для завхоза
        public void FillDgvLinens(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.Columns.Add("id_lin", "Номер белья");
            dgv.Columns.Add("id_stud", "Номер билета");
            dgv.Columns.Add("grant_date", "Дата выдачи");
            dgv.Columns.Add("revoke_date", "Дата приема");
        }
        // Для списка нарушений
        public void FillDgvViolations(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.Columns.Add("id", "Номер нарушения");
            dgv.Columns.Add("date", "Дата");
            dgv.Columns.Add("type", "Тип");
            dgv.Columns.Add("penalty", "Наказание");
        }
        



        #endregion

        // Техперсонал
        private void BtnStaffRefresh_Click(object sender, EventArgs e) {
            //FillDgvStaffRequests();
            requester.ShowRepairRequests(factory, dgvStaffShowRequests);
        }
        // Завхоз
        private void BtnGuveLinens_Click(object sender, EventArgs e) {
        }

        private void BtnGetLinens_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow row in dgvLinens.SelectedRows)
                requester.ReturnLinens(factory, row.Cells["id_lin"].Value.ToString());
            //FillDgvLinens();
            requester.GetLinens(factory, dgvLinens);
        }
        // Вахтёр
        private void BtnPassStudent_Click(object sender, EventArgs e) {
            //FillDgvWatcher();
            string name = tbWatchStudName.Text;
            string lastname = tbWatchStudLast.Text;
            requester.PassStudent(factory, dgvWatchFind, name, lastname);
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
            
        }
        private void BtnSetPen_Click(object sender, EventArgs e) {
           // requester.Set_Penalty(factory, comboOtrabotki.SelectedItem.ToString(), tbSetPen.Text);
        }
        private void BtnKick_Click(object sender, EventArgs e) {
            //requester.Kick_Student(factory, tbIdKick.Text);
        }

        #endregion
        // Заявка о нарушении
        private void BtnSendReport_Click(object sender, EventArgs e) {
            //requester.Send_Report(factory, tbReportNum.Text, tbTextReport.Text, dateViolation.Value.ToShortDateString());
        }

        private void label9_Click(object sender, EventArgs e) {

        }

        private void tabCon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
